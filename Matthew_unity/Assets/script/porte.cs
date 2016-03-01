using UnityEngine;
using System.Collections;

public class porte : MonoBehaviour {

	public Animator anim;
	public bool key;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		key = GameObject.Find("Player").GetComponent<Player>().key;
	}

	void FixedUpdate(){

		anim.SetBool ("key", key);
		
	}
	

}
