using UnityEngine;
using System.Collections;

public class Scan : MonoBehaviour {

	public int vie;
	public int maxVie;
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		vie = maxVie;
	}
	
	// Update is called once per frame
	void Update () {

		if (vie <= 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}	
}
