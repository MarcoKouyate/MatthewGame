using UnityEngine;
using System.Collections;

public class PorteEnd : MonoBehaviour {

	public Animator anim;
	public bool door;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		door = GameObject.Find("RedButon").GetComponent<RedButon>().push;
	}
	
	void FixedUpdate(){
		door = GameObject.Find("RedButon").GetComponent<RedButon>().push;
		anim.SetBool ("door", door);
		
	}
}
