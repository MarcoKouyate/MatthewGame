using UnityEngine;
using System.Collections;

public class abeille : MonoBehaviour {

	
	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;
	
	public bool awake = false;
	public bool lookingRight = true;
	
	public GameObject bullet;
	public Transform target;
	public Transform ennemi;
	public Animator anim;
	public Transform shootPointLeft;
	public Transform shootPointRight;

	public float moveSpeed = 1f;
	private Vector2 velocity;


	
	void Awake(){
		anim = gameObject.GetComponent<Animator> ();

		//ennemi = transform.position.x;
	}
	
	void Start(){

	}
	
	void Update(){
		
		anim.SetBool ("Awake", awake);
		anim.SetBool ("LookingRight", lookingRight);
		
		RangeCheck ();
		
		if (target.transform.position.x > transform.position.x) {
			lookingRight = true;
			//transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			//Debug.Log ("target1");
		}
		if (target.transform.position.x < transform.position.x) {
			lookingRight = false;
			//
			//Debug.Log ("target2");
			//ennemi = target.transform.position.x;
		}
	}
	
	void RangeCheck(){
		
		distance = Vector3.Distance (transform.position, target.transform.position);
		
		if (distance < wakeRange) {
			awake = true;
			//Debug.Log ("distance<wakeRange");
			float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref velocity.x, 1.5f);
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
	
	public void Attack(bool attackingRight){
		
		bulletTimer += Time.deltaTime;
		
		if (bulletTimer >= shootInterval) {
			
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();

			
			if(!attackingRight){
				GameObject bulletClone;
				bulletClone  = Instantiate(bullet,shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				//transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
				bulletTimer = 0;
			}
			
			if(attackingRight){
				GameObject bulletClone;
				bulletClone  = Instantiate(bullet,shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				//transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
				bulletTimer = 0;
			}
		}
		
	}

	void OnTriggerEnter2D (Collider other){
		if (other.CompareTag("Mur")){
			velocity = Vector3.zero;
		}
	}

}
