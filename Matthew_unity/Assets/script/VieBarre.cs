using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Image=UnityEngine.UI.Image;

public class VieBarre : MonoBehaviour {

	//public GameObject vieBar;
	public Color goodColor;
	public Color middleColor;
	public Color badColor;
	Image BarVie;
	float tmpVie=1;
	

	// Use this for initialization
	void Start () {
		BarVie = GameObject.Find("MainCamera").transform.FindChild("Canvas").FindChild("BarVie").GetComponent<Image>();
		SetColor (1);
		//player = GameObject.Find("Sonic");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




	void SetColor(float value){
		if (BarVie.fillAmount >= 0.5f) {
			BarVie.color = goodColor;
		} else if (BarVie.fillAmount >= 0.25f && BarVie.fillAmount < 0.5f) {
			BarVie.color = middleColor;
		} else if(BarVie.fillAmount >0.1f && BarVie.fillAmount < 0.25f) {
			BarVie.color = badColor;
		}else {
			Destroy(GameObject.Find("Sonic"));
		}
	}
}
