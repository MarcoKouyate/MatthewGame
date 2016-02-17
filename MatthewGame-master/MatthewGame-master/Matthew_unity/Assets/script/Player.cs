using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Image=UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Animator anim;
	public float speed = 50;

	public int coins = 0;

	public Transform checkSol;
	bool toucheSol = false;
	float rayonSol = 0.3f;
	public LayerMask Sol; //dire a Unity ce qu'est le sol 

	public Color goodColor;
	public Color middleColor;
	public Color badColor;
	Image BarVie;
	float tmpVie=1;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		BarVie = GameObject.Find("MainCamera").transform.FindChild("Canvas").FindChild("BarVie").GetComponent<Image>();
		SetColor (1);

	}

	void FixedUpdate(){
		toucheSol = Physics2D.OverlapCircle (checkSol.position, rayonSol, Sol); //es-ce que mon cercle touche quelque chose entre la position du game object chechSo, le rayon et le mask sol
		anim.SetBool ("sol", toucheSol);
	}
	
	// Update is called once per frame
	void Update () {

		BarVie.fillAmount = tmpVie;

		float x = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs(x));

		if (toucheSol && Input.GetButtonDown ("Jump")) { 	// Sauter
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1300));
		}

		if(x > 0){		// Avancer
			transform.Translate (x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2 (0,0);
	}
		if(x < 0){ 		// Reculer
			transform.Translate (-x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2(0,180);
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
			coins += 1;
			//Destroy(GameObject.Find("coin1"));
		}
		if(coll.gameObject.tag == "Lave"){
			Debug.Log("Lave");
			BarVie.fillAmount = 0;
			tmpVie = BarVie.fillAmount;
			SetColor (BarVie.fillAmount);
			SceneManager.LoadScene ("game-over");

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
			Destroy(GameObject.Find("Sonic"));
		}
	}

	void OnGUI(){

		GUI.Label( new Rect(80, 82, 85, 25), " "+coins);
	}




}