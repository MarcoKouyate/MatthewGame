using UnityEngine;
using System.Collections;

public class NavigationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuitGame()
	{
		Application.Quit();
		
	}
	public void GoToScene()
	{
		Application.LoadLevel("scene");
	}
}
