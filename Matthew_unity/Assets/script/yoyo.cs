using UnityEngine;
using System.Collections;

public class yoyo : MonoBehaviour {

	bool lancer = false;
	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		if (Input.GetKeyDown ("x")) {
			lancer = true;
			//anim.SetBool ("yoyo", yoyo);
			Vector3 targPos = gameObject.transform.position;
			targPos.x += 50;
			iTween.MoveFrom(gameObject, targPos, 3);
			                //iTween.Hash("x", 40, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 1));
			
			//this.transform.position = Vector2(200,0);
			
		} else {
			lancer = false;
			//anim.SetBool ("yoyo", yoyo);
		}
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
