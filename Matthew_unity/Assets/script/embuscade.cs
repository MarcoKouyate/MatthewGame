using UnityEngine;
using System.Collections;

public class embuscade : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			Embuscade(other);
		}
	}

	void Embuscade(Collider2D other){
		for (int i = 0; i < 2; i++) {
			Vector3 location = new Vector3(other.transform.position.x - 3.5f + 7 * i ,other.transform.position.y+0.5f,other.transform.position.z);
			Instantiate (enemy, location, other.transform.rotation);
		}
		Destroy (this.gameObject);
	}
}
