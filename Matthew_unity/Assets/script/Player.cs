using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Image=UnityEngine.UI.Image;

public class Player : MonoBehaviour {


	public float movementSpeed = 20f;
	public Animator anim;
	public float speed = 30f;

	public float jumpHeight;
	public float jumpPushForce = 1f;
	bool facingRight = true;

	bool wallJumped = false;

	public bool mur = false;
	public bool sol = false;
	public bool water = false;

	public int coins = 0;

	public Transform checkSol;
	public bool toucheSol = false;
	public bool grounded = false;
	public Transform groundCheck;
	public float rayonSol = 0f;
	public LayerMask Sol; //dire a Unity ce qu'est le sol 
	public LayerMask Mur; //dire a Unity ce qu'est le mur 


	public Color goodColor;
	public Color middleColor;
	public Color badColor;
	Image BarVie;
	float tmpVie=1;

	public bool key = false;
	public Texture ImgKey;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		BarVie = GameObject.Find("MainCamera").transform.FindChild("Canvas").FindChild("BarVie").GetComponent<Image>();
		SetColor (1);


	}

	void FixedUpdate(){


		toucheSol = Physics2D.OverlapCircle (checkSol.position, rayonSol, Sol); //es-ce que mon cercle touche quelque chose entre la position du game object chechSo, le rayon et le mask sol
		anim.SetBool ("sol", toucheSol);


		if (wallJumped) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (jumpPushForce * (facingRight ? -1 : 1), jumpHeight);
			wallJumped = false;
			if (GetComponent<Rigidbody2D> ().velocity.x > 0 && !facingRight) {
				Flip ();
			} else if (GetComponent<Rigidbody2D> ().velocity.x < 0 && facingRight) {
				Flip ();
			}

		} else {
			
		}


	

	}
	
	// Update is called once per frame
	void Update () {

		bool wallSliding = false;


		BarVie.fillAmount = tmpVie;

		float x = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs(x));

		if (toucheSol && sol && Input.GetButtonDown ("Jump") || water && Input.GetButtonDown ("Jump") ) {

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);

		}
		else if (grounded && mur && Input.GetButtonDown ("Jump")) {

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
			wallJumped = true;
		}
	

		if (Input.GetButtonDown ("Jump")) {
			GetComponent<Rigidbody2D>().isKinematic = false;
			transform.parent = null;
		}

		if(x > 0){

			transform.Translate (x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2 (0,0);
			GetComponent<Rigidbody2D>().isKinematic = false;

		}
		if(x < 0){

			transform.Translate (-x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2(0,180);
			GetComponent<Rigidbody2D>().isKinematic = false;

		}


	}


	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Ennemi"){
			Debug.Log("Ennemi");
			tmpVie = BarVie.fillAmount - 0.1f;
			SetColor (BarVie.fillAmount);
		}
		if(coll.gameObject.tag == "coin"){
			Debug.Log("Coin");
			coins = coins +1;

		}
		if (coll.gameObject.tag == "key") {
			key = true;
			GUI.Label( new Rect(200, 200, 85, 25), "KEY");
			GameObject.Find("Porte").GetComponent<porte>().key = true;
		}

		if (coll.transform.tag == "platform") 
		{
			GetComponent<Rigidbody2D>().isKinematic=true;
			transform.parent = coll.transform;
		}


	}

	void OnCollisionExit2D(Collision2D coll){


	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Water") {
			water = true;
			GetComponent<Rigidbody2D>().gravityScale = 0.2f;
			jumpHeight = 1;
			Debug.Log("water");
		}
		if (other.gameObject.name == "Objet_jump") {
			grounded = true;
			Destroy(GameObject.Find("Objet_jump"));

		}

		if (other.gameObject.name == "MUR") {
			mur = true;
		}
		if (other.gameObject.name == "Sol") {
			sol = true;
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Water") {
			water = false;
			GetComponent<Rigidbody2D>().gravityScale = 2;
			jumpHeight = 7;
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
		}
	}

	void OnGUI(){

		GUI.Label( new Rect(150, 100, 85, 25), " "+coins);

		if (key == true) {
			GUI.DrawTexture(new Rect(100, 120, 60, 60), ImgKey, ScaleMode.StretchToFill, true, 10.0F);

		}

	}

	void Flip()
	{      
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}





}