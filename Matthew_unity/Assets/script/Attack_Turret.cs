using UnityEngine;
using System.Collections;

public class Attack_Turret : MonoBehaviour {

	public abeille abeille;
	public bool isLeft = false;

	void Awake(){

		abeille = gameObject.GetComponentInParent<abeille>();
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {

			if(isLeft){
				abeille.Attack (false);
			}
			else{
				abeille.Attack (true);
			}
		}

	}
}
