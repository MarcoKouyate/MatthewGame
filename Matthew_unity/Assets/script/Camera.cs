using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	int coins;
	bool key;
	Texture ImgKey;


	void Start () {
	
		player = GameObject.Find("Player");
		coins = GameObject.Find("Player").GetComponent<Player> ().coins;
		key = GameObject.Find("Player").GetComponent<Player> ().key;
		ImgKey = GameObject.Find("Player").GetComponent<Player> ().ImgKey;

	}

	void FixedUpdate(){
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX,posY, transform.position.z);

		if (bounds) {
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
			                                 Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
			                                 Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}

		/*if(GameObject.Find("RedButon").GetComponent<RedButon>().push == true){
			//Vector3 tarPos = gameObject.transform.position;
			transform.position = new Vector3 (Mathf.SmoothDamp (player.transform.position.x, 0, ref velocity.x, smoothTimeX),posY,transform.position.z);
			//tarPos.x = 100;
		 }*/
	}

	/*void OnGUI(){
		
		GUI.Label( new Rect(130, 145, 85, 25), " " + coins);
		
		if (key == true) {
			Debug.Log ("KEYCamera");
			GUI.DrawTexture(new Rect(100, 120, 60, 60), ImgKey, ScaleMode.StretchToFill, true, 10.0F);
			
		}
		
	}*/

	void update(){


	}
	

}
