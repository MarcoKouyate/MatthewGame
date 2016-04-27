using UnityEngine;
using System.Collections;

public class Slim : MonoBehaviour {
	
	
	public float distance;
	public float wakeRange;
	
	public bool awake = false;
	public bool lookingRight = true;

	GameObject target;

	public float moveSpeed = 1f;
	public bool parent = true;
	private Vector2 velocity;

	public bool grounded = false;
	public Transform groundCheck;
	public float rayonSol = 0f;
	public LayerMask Sol; //dire a Unity ce qu'est le sol 
	public LayerMask Mur;
	public Transform checkSol;
	public bool toucheSol = false;

	public GameObject slimane;
	Scan scan;
	
	
	

	
	void Start(){
		scan = gameObject.GetComponent<Scan>();
		target = GameObject.Find ("Player");
	}
	
	void Update(){
		

		RangeCheck ();
		
		if (target.transform.position.x > transform.position.x) {
			lookingRight = true;
			transform.eulerAngles = new Vector3(0, 0, 0);
			//transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			//Debug.Log ("target1");
		}
		if (target.transform.position.x < transform.position.x) {
			lookingRight = false;
			transform.eulerAngles = new Vector3(0, 180, 0);
			//Debug.Log ("target2");
			//ennemi = target.transform.position.x;
		}

		if (scan.vie <= 50 && parent == true) {
			slimane.transform.localScale = new Vector3( transform.localScale.x/2, transform.localScale.y/2, transform.localScale.z/2);
			Instantiate (slimane, transform.position, transform.rotation);
			slimane.transform.position = new Vector3( transform.position.x + 0.5f, transform.position.y, transform.position.z);
			Instantiate (slimane, slimane.transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
	
	void RangeCheck(){
		
		distance = Vector3.Distance (transform.position, target.transform.position);
		
		if (distance < wakeRange) {
			awake = true;
			//Debug.Log ("distance<wakeRange");
			float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref velocity.x, 3f);
			transform.position = new Vector3(posX, transform.position.y, transform.position.z);
			//GetComponent<Rigidbody2D>().velocity = (target.transform.position - transform.position) * moveSpeed;
		}
		
		if (distance > wakeRange) {
			awake = false;
			//Debug.Log ("distance>wakeRange");
			
		}
	}



	/*void chase(){
		MoveDirection = transform.forward;
		//MoveDirection *= moveSpeed;
		//controller.Move (MoveDirection * Time.deltaTime);

	}*/
	

	
	void OnTriggerEnter2D (Collider other){
		if (other.CompareTag("Weapon")){
			
		}
	}
}
