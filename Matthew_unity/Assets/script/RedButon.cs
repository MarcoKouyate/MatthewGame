using UnityEngine;
using System.Collections;

public class RedButon : MonoBehaviour {


	public Animator anim;
	public bool push;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		push = GameObject.Find("Player").GetComponent<Player>().redButon;

	
	}

	void FixedUpdate(){
		push = GameObject.Find("Player").GetComponent<Player>().redButon;
		anim.SetBool ("push", push);
		
	}

}
