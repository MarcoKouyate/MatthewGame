using UnityEngine;
using System.Collections;

public class mainSceneInput : MonoBehaviour {
	GameObject myCanvas;
	// Use this for initialization
	void Start () {
		myCanvas = GameObject.Find ("MENU");
		myCanvas.SetActive(false);

	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("m"))
		{
			//myCanvas.SetActive(true);
			if(myCanvas.activeInHierarchy == false){
				myCanvas.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				
			}else{
				myCanvas.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
			}
			
			Debug.Log("touche m");
			
		}
	}
}
