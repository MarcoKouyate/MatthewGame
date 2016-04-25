using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour {

	GameObject myCanvas;
	// Use this for initialization
	void Start () {
		myCanvas = GameObject.Find ("WIN");
		myCanvas.SetActive(false);
		//Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1;

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			myCanvas.SetActive(true);
			//Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0;
		}
	}
}
