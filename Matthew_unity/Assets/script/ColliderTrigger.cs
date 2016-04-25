using UnityEngine;
using System.Collections;

public class ColliderTrigger : MonoBehaviour {

	private BoxCollider2D playerCollider;
	private BoxCollider2D checkSol;
	private BoxCollider2D groundCheck;

	[SerializeField]
	private BoxCollider2D platformCollider;
	[SerializeField]
	private BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start () {
	
		playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D> ();
		checkSol = GameObject.Find("checkSol").GetComponent<BoxCollider2D> ();;
		groundCheck = GameObject.Find("groundCheck").GetComponent<BoxCollider2D> ();;
		Physics2D.IgnoreCollision (platformCollider, platformTrigger, true);


	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
			Physics2D.IgnoreCollision(platformCollider, checkSol, true);
			Physics2D.IgnoreCollision(platformCollider, groundCheck, true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
			Physics2D.IgnoreCollision(platformCollider, checkSol, false);
			Physics2D.IgnoreCollision(platformCollider, groundCheck, false);
		}
	}
}
