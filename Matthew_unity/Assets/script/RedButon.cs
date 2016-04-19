using UnityEngine;
using System.Collections;

public class RedButon : MonoBehaviour {


	public Animator anim;
	public bool push;


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

		}
		
		
	}

	void OnCollisionExit2D(Collision2D coll){
		if(coll.transform.tag == "box"){
			push = false;
			GameObject.Find("RedButon").GetComponent<RedButon>().push = false;
		}
		if(coll.transform.tag == "Player"){
			push = false;
			GameObject.Find("RedButon").GetComponent<RedButon>().push = false;
		}
		
	}


}
