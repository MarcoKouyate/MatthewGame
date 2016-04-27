using UnityEngine;
using System.Collections;

public class secretRoom : MonoBehaviour {
	public GameObject room;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			room.SetActive(false);
		}
	}
}
