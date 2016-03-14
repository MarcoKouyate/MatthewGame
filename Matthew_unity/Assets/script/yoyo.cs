using UnityEngine;
using System.Collections;

public class yoyo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "key"){
			GameObject.Find("Player").GetComponent<Player>().key = true;
			GUI.Label( new Rect(200, 200, 85, 25), "KEY");
			GameObject.Find("Porte").GetComponent<porte>().key = true;
		}

		
		
	}
}
