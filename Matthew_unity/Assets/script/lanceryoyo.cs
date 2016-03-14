using UnityEngine;
using System.Collections;

public class lanceryoyo : MonoBehaviour {
	
	public float delay;
	public float longueur;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		bool right = player.GetComponent<Player> ().facingRight;

		Vector3 targPos = gameObject.transform.position;



		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		Debug.Log (y);

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
		ht.Add("time", delay );
		ht.Add("oncomplete", "Retourner");





		iTween.MoveTo(gameObject, ht);
	}
	

	void Update(){
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist > longueur + longueur / 2) {
			//Stop();
			Retourner ();
		}
	}

	void Stop () {

		player.GetComponent<Player> ().lancer = false;

		Destroy (gameObject);

	}

	void Retourner(){
		GameObject player = GameObject.Find ("Player"); 
		Vector3 targPos = player.transform.position;

		Hashtable ht = new Hashtable();
		ht.Add("position", targPos );
		ht.Add("time", delay/10);
		ht.Add("oncomplete", "Stop");

		iTween.MoveTo(gameObject, ht);

	}
}
