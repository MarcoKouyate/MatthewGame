﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Image=UnityEngine.UI.Image;

public class Player : MonoBehaviour {


	public float movementSpeed = 20f;
	public Animator anim;
	public float speed = 30f;

	public float jumpHeight;
	public float jumpPushForce = 1f;
	public bool facingRight = true;

	bool wallJumped = false;

	public bool mur = false;
	public bool sol = false;
	public bool water = false;

	public int coins = 0;

	public GameObject shot;
	public Transform shotSpawn;
	
	public bool lancer = false;
	public bool teleport = false;

	public Transform checkSol;
	public bool toucheSol = false;
	bool hurt = false;
	public int cooldown;
	int colddown;
	public bool grounded = false;
	public Transform groundCheck;
	public float rayonSol = 0f;
	public LayerMask Sol; //dire a Unity ce qu'est le sol 
	public LayerMask Mur; //dire a Unity ce qu'est le mur 


	public Color goodColor;
	public Color middleColor;
	public Color badColor;
	Image BarVie;
	public float tmpVie=1;

	public bool key = false;
	public Texture ImgKey;

	public AudioClip jumpSound;

	//public bool redButon = false;

	bool yoyo = false;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		BarVie = GameObject.Find("MainCamera").transform.FindChild("Canvas").FindChild("BarVie").GetComponent<Image>();
		SetColor (1);
	}

	void FixedUpdate(){


		toucheSol = Physics2D.OverlapCircle (checkSol.position, rayonSol, Sol); //es-ce que mon cercle touche quelque chose entre la position du game object chechSo, le rayon et le mask sol
		anim.SetBool ("sol", toucheSol);
		if (sol == true && lancer == false) {
			teleport = false; 
			Debug.Log ("SOOL");
		}



		if(wallJumped)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(jumpPushForce * (facingRight ? -1:1), jumpHeight);
			wallJumped = false;
			facingRight = !facingRight;

		}
	}
	
	// Update is called once per frame
	void Update () {

		bool wallSliding = false;



		BarVie.fillAmount = tmpVie;

		float x = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs(x));

		if (toucheSol && sol && Input.GetButtonDown ("Jump") && hurt == false|| water && Input.GetButtonDown ("Jump") ) {

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
			anim.SetTrigger("jump");


		}
		else if (grounded && mur && Input.GetButtonDown ("Jump")) {

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
			wallJumped = true;
		}
	

		if (Input.GetButtonDown ("Jump")) {
			GetComponent<Rigidbody2D>().isKinematic = false;
			transform.parent = null;
		}

		if(x > 0 && hurt == false){
			facingRight = true;
			transform.Translate (x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2 (0,0);
			GetComponent<Rigidbody2D>().isKinematic = false;

		}
		if(x < 0 && hurt == false){
			facingRight = false;
			transform.Translate (-x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2(0,180);
			GetComponent<Rigidbody2D>().isKinematic = false;

		}

		if (Input.GetKeyDown ("x") && lancer == false) {
			lancer = true;
			teleport = false;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
		
		
		if (Input.GetKeyDown ("c") && lancer == false && teleport == false) {
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			lancer = true;
			teleport = true;
		}

		if (hurt==true) {
			colddown--;
		} else {
			colddown = cooldown;
		}

		if (colddown <= 0) { 
			hurt = false;
			colddown = cooldown;
			anim.SetTrigger ("repos");
		} else if (cooldown == colddown) {
			anim.SetTrigger ("repos");
		}
	}


	void OnCollisionEnter2D(Collision2D coll){

		if(coll.gameObject.tag == "pique"){
			Debug.Log("pique");
			Application.LoadLevel("scene");
		}
		if(coll.gameObject.tag == "coin"){
			Debug.Log("Coin");
			coins = coins +1;
			
		}

		if (coll.gameObject.tag == "key") {
			key = true;
			GUI.Label( new Rect(200, 200, 85, 25), "KEY");

		}

		if (coll.transform.tag == "platform") 
		{
			GetComponent<Rigidbody2D>().isKinematic=true;
			transform.parent = coll.transform;
		}
	

	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "bullet"){
			Debug.Log("bullet");
			tmpVie = BarVie.fillAmount - 0.1f;
			SetColor (BarVie.fillAmount);
			hurt = true;
			anim.SetTrigger("hurt");

		}

		if(other.gameObject.tag == "coin"){
			Debug.Log("Coin");
			coins = coins +1;
			
		}

		if(other.gameObject.name == "DeathZone"){
			Application.LoadLevel("scene");
		}

		if (other.gameObject.name == "Water") {
			water = true;
			GetComponent<Rigidbody2D>().drag = 14f;
			//jumpHeight = 1;
			anim.SetBool("water" , water);

		}
		if (other.gameObject.name == "Gant" || other.CompareTag("Gant")) {
			grounded = true;
			Destroy(other.gameObject);
		}

		if (other.gameObject.name == "MUR") {
			mur = true;
		}
		if (other.gameObject.name == "Sol") {
			sol = true;
		}
		if (other.gameObject.name == "TrigerPorte" && key==true) {
			GameObject.Find("Porte").GetComponent<porte>().key = true;
		}

		if (other.CompareTag ("Soin")) {
			tmpVie = BarVie.fillAmount + 0.5f;
			SetColor (BarVie.fillAmount);
			Destroy(other.gameObject);
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Water") {
			water = false;
			GetComponent<Rigidbody2D>().drag = 0;
			jumpHeight = 7;
			anim.SetBool("water" , water);
		}

		if (other.gameObject.name == "MUR") {
			mur = false;
		}
		if (other.gameObject.name == "Sol") {
			sol = false;
		}
	
	}

	void SetColor(float value){
		if (value >= 0.5f) {
			BarVie.color = goodColor;
		} else if (value >= 0.25f && value < 0.5f) {
			BarVie.color = middleColor;
		} else if(value > 0.1f && value < 0.25f) {
			BarVie.color = badColor;
		}else {
			BarVie.fillAmount = 0f;
			Destroy(this.gameObject);
			Application.LoadLevel("scene");
		}
	}

	void OnGUI(){

		GUI.Label( new Rect(150, 175, 85, 25), " "+coins);

		if (key == true) {
			GUI.DrawTexture(new Rect(90, 190, 60, 60), ImgKey, ScaleMode.StretchToFill, true, 10.0F);

		}

	}

	void Flip()
	{      
		facingRight = !facingRight;
		
		//Vector3 theScale = transform.localScale;
		//theScale.x *= -1;
		//transform.localScale = theScale;
	}





}