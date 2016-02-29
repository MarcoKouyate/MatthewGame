using UnityEngine;
using System.Collections;

public class scrooler : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeX;

    public Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
		transform.position = transform.position + Vector3.left * (scrollSpeed/1000);
		float ecart = startPosition.x - transform.position.x;
		if(ecart >tileSizeX){
			transform.position = startPosition;
		}

	}
}
