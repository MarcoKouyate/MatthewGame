using UnityEngine;
using System.Collections;

public class AfterBoss : MonoBehaviour {

	public Transform target;
	public GameObject loot;

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			other.transform.position = target.transform.position; 
			Instantiate(loot, target.transform.position + new Vector3 (2,0,0), target.transform.rotation);
		}
	}
}
