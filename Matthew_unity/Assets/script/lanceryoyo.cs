using UnityEngine;
using System.Collections;

public class lanceryoyo : MonoBehaviour {
	
	public float delay;
	public float longueur;
	Vector3 startPos;
	GameObject yoyObject;
	LineRenderer lineRenderer;
    Vector3 teleportPoint;
	Rigidbody2D rb;
	GameObject player;
	Player controller;
	bool stop = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		yoyObject = GameObject.Find ("collider");
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
		} else {
			targPos.x -= longueur;
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
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist > longueur + longueur / 2) {
			if (controller.teleport == true){
				Teleportation();
			} else {
				Retourner ();
			}
		}

		lineRenderer.SetPosition(0, player.transform.position);
		lineRenderer.SetPosition(1, transform.position);
		lineRenderer.sortingLayerName = "Foreground";
		
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
		rb.position = transform.position;
		//rb.isKinematic = true;
		Stop ();

	}
	

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("sol")){

			Retourner();
			Debug.Log (other);

		}
	}
}
