using UnityEngine;
using System.Collections;

public class RedButon : MonoBehaviour {


	public Animator anim;
	public bool push;
	public GameObject boite;
	bool first = true;
	bool done = false;


	//public bool redButon = false;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		//push = GameObject.Find("Player").GetComponent<Player>().redButon;

	
	}

	void FixedUpdate(){
		//push = GameObject.Find("Player").GetComponent<Player>().redButon;
		anim.SetBool ("push", push);
		
	}

	void OnCollisionEnter2D(Collision2D coll){

		if(coll.transform.tag == "box"){
			//redButon = true;
			push = true;
		}
		if(coll.transform.tag == "Player"){
			//redButon = true;
			push = true;
			if (first == false) {
				Vector3 location = new Vector3 (transform.position.x + 3, transform.position.y + 2, transform.position.z);
				Instantiate(boite, location, transform.rotation);
				done = true;
				first = true;
			}

		}
		
		
	}

	void OnCollisionExit2D(Collision2D coll){
		if(coll.transform.tag == "box"){
			push = false;
			GameObject.Find("RedButon").GetComponent<RedButon>().push = false;
		}
		if(coll.transform.tag == "Player"){
			push = false;
			if (done == false){
				first = false; 
			}
			GameObject.Find("RedButon").GetComponent<RedButon>().push = false;
		}
		
	}


}
