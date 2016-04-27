using UnityEngine;
using System.Collections;

public class lanceryoyo : MonoBehaviour {
	
	public float delay;
	public float longueur;
	public float recul;
	public float spin;

	Vector3 startPos;
	//GameObject yoyObject;
	LineRenderer lineRenderer;
    Vector3 teleportPoint;
	Rigidbody2D rb;
	GameObject player;
	Player controller;
	Scan scan;
	bool stop = false;
	GameObject ennemi;
	Rigidbody2D rigidEnemy;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		controller = player.GetComponent<Player> ();
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetWidth(0.02F, 0.02F);
		rb = player.GetComponent<Rigidbody2D> ();
		bool right = controller.facingRight;
		bool air = controller.sol;

		Vector3 spawnPos = gameObject.transform.position;
		Vector3 targPos = spawnPos;



		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		if (controller.sol == false) {
			longueur = longueur * 1.5f;
			//delay = delay * 2.0f;
		}

		if (right == true) {
			targPos.x += longueur;
			//Debug.Log ("droite");
		} else {
			targPos.x -= longueur;
			//Debug.Log ("gauche");
		}

		if (y > 0) {
			targPos.y += longueur;
		} else if (y < 0) {
			targPos.y -= longueur;
		} else {
			targPos.y-= 0;
		}


		Hashtable ht = new Hashtable();
		ht.Add("position", targPos );
		ht.Add ("onupdate", "Transfert");
		ht.Add("time", delay);
		if (controller.teleport == true) {
			ht.Add ("oncomplete", "Teleportation");
		} else {
			ht.Add ("oncomplete", "Retourner");
		}

		iTween.MoveTo(gameObject, ht);
	}
	

	void Update(){

		rangeCheck ();
		lineRenderer.SetPosition(0, transform.position);
		lineRenderer.SetPosition(1, player.transform.position);
		lineRenderer.sortingLayerName = "Foreground";
		transform.Rotate (new Vector3 (0, 0, 25 * spin) * Time.deltaTime);
		
	}

	void rangeCheck(){
		float dist = Vector3.Distance(player.transform.position, transform.position);
		
		if (dist > (longueur + longueur / 2) || dist < -(longueur + longueur / 2) ) {
			if (controller.teleport == true){
				Teleportation();
			} else {
				Stop ();
				//Debug.Log ("MONEY");
			}
		}

	}

	void Stop(){
		stop = true; 
		controller.lancer = false;
		Destroy (gameObject);
	}

	void Retourner(){
		Vector3 targPos = player.transform.position;

		Hashtable ht = new Hashtable();
		ht.Add("position", targPos );
		ht.Add("time", delay/5);
		ht.Add("oncomplete", "Stop");

		iTween.MoveTo(gameObject, ht);

	}

	void Teleportation(){
		rb.isKinematic = false;
		rb.position = transform.position + Vector3.up * 0.3f;
		//rb.isKinematic = true;
		Stop ();

	}
	

	void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag("sol") || other.CompareTag("mur")  ){
			if (controller.teleport == true) {
				Teleportation();
			} else {
				Retourner();
			}
			//Debug.Log (other);
		}

		if (other.CompareTag("Ennemi")){
			Retourner();
			//Debug.Log (other);

			if (ennemi != other.gameObject){
				ennemi = other.gameObject;
				scan = ennemi.GetComponent<Scan> ();
				rigidEnemy = ennemi.GetComponent<Rigidbody2D> ();
			}

			if (transform.position.x >= ennemi.transform.position.x){
				rigidEnemy.AddForce(Vector3.left * recul);
			} else if (transform.position.x <= ennemi.transform.position.x){
				rigidEnemy.AddForce(Vector3.right * recul);
			}

			scan.vie -= 25;
			
		}


		if(other.CompareTag("coin")){
					controller.coins = controller.coins +1;
					Destroy(other.gameObject);
			}

		if (other.CompareTag("key")) {
				controller.key = true;
				GUI.Label( new Rect(200, 200, 85, 25), "KEY");
				Destroy(other.gameObject);		
		}
	
			//Debug.Log (other);

	}
	
}
