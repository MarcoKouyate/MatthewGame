#pragma strict

import UnityEngine.UI;

var anim : Animator;
var speed : float  = 50;

var checkSol : Transform;
var toucheSol : boolean = false;
var rayonSol : float = 0.3f;
var Sol : LayerMask; //dire a Unity ce qu'est le sol 

var coins :int;


function Start () {
	anim = GetComponent.<Animator>();
}

function FixedUpdate(){
		toucheSol = Physics2D.OverlapCircle (checkSol.position, rayonSol, Sol); //es-ce que mon cercle touche quelque chose entre la position du game object chechSo, le rayon et le mask sol
		anim.SetBool ("sol", toucheSol);
	}

function Update () {
	var x : float = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs(x));

		if (toucheSol && Input.GetButtonDown ("Jump")) {
			GetComponent.<Rigidbody2D>().AddForce(new Vector2(0, 600));
		}

		if(x > 0){
			transform.Translate (x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2 (0,0);
	}
		if(x < 0){
			transform.Translate (-x * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2(0,180);
		}
}

function OnCollisionEnter2D(coll: Collision2D){
		if(coll.gameObject.tag == "Sol"){
			Debug.Log("Ennemi");
			GameObject.Find("MainCamera").transform.FindChild("Canvas").FindChild("BarVie").GetComponent.<Image>().fillAmount -= 0.1f;
		
		}
	}