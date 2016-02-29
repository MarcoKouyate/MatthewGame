using UnityEngine;
using System.Collections;

public class GantScript : MonoBehaviour {

	public Sprite GantTextureFalse;
	public Sprite GantTextureTrue;


	// Use this for initialization
	void Start () {

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = GantTextureFalse;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("Player").GetComponent<Player>().grounded == true) {

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = GantTextureTrue;
		} else {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = GantTextureFalse;
		}

	
	}
}
