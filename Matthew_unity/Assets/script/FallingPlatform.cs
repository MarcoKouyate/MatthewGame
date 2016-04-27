using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
	bool startCount = false;
	public float startTime = 0.0f;
	//public float faillDelay;

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update(){

		if(startCount == true)
		{
			Debug.Log ("StartCount");

			Debug.Log (startTime);

			if(startTime + 0.2f < Time.time)
			{
				Debug.Log ("StartTime");
				rb2d.isKinematic = false;
				GetComponent<Collider2D> ().isTrigger = true;
			}
		}
	}


	void OnCollisionEnter2D(Collision2D col){

		if (col.collider.CompareTag ("Player")) {
			startCount = true;
			startTime = Time.time;
			Debug.Log("FaillPlatform");

		}

	}
	void OnCollisionExit2D(Collision2D col){
		
		if (col.collider.CompareTag ("Player")) {
			startCount = false;
			Debug.Log("NoFaillPlatform");
			
		}
		
	}


	/*IEnumerator Fall(){


		yield return 0;
	}*/
	

}
