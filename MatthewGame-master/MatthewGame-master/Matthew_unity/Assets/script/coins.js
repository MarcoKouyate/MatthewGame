#pragma strict

//var coin : int =1;


var player : int;

function Start () {
	//coin = 1;

//player = GameObject.Find("Sonic").GetComponent(Player);
}

function Update () {

}

function OnCollisionEnter2D(coll: Collision2D){
		if(coll.gameObject.tag == "Player"){
			Debug.Log("Coin");
			Destroy(gameObject);
			//player.coins += 1;
			//tmpVie = BarVie.fillAmount - 0.1f;
			//SetColor (BarVie.fillAmount);
		}
	}