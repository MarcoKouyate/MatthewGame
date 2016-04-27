using UnityEngine;
using System.Collections;

public class Scan : MonoBehaviour {

	public int vie;
	public int maxVie;
	public GameObject explosion;
	public bool loot = false; //sauf si inspecteur dit le contraire !
	public GameObject recompense;
	
	// Use this for initialization
	void Start () {
		vie = maxVie;
	}
	
	// Update is called once per frame
	void Update () {

		if (vie <= 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			if (loot == true){
				Instantiate (recompense, recompense.transform.position, recompense.transform.rotation);
			}
			Destroy(this.gameObject);
		}
	}	
}
