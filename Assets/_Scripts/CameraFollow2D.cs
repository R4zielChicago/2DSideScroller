using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour {

	//What the camera is following
	public Transform target;

	//Dampening effect of the camera following
	public float smoothing;

	Vector3 offset; //Difference between the camera and the player

	float lowY; //Lowest point the camera can go on the Y axis

	// Use this for initialization
	void Start () {
	
		offset = transform.position - target.position;
		lowY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){

		Vector3 targetCamPos = target.position + offset;

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

		if (transform.position.y < lowY){

			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}
}
