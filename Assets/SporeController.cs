using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeController : MonoBehaviour {

	public float sporeSpeedMax;
	public float sporeSpeedMin;
	public float sporeAngle;
	public float sporeTorqueAngle;

	Rigidbody2D sporeRb;



	// Use this for initialization
	void Start () {
		sporeRb = GetComponent<Rigidbody2D> ();
		sporeRb.AddForce (new Vector2(Random.Range (-sporeAngle, sporeAngle), 
			Random.Range (sporeSpeedMin, sporeSpeedMax)), ForceMode2D.Impulse);
		sporeRb.AddTorque (Random.Range (-sporeTorqueAngle, sporeTorqueAngle));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
