using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {


	public float gainHealthAmount;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("OnTriggerEnter2d"); 
		if(other.tag == "Player"){
			PlayerHealth theHealth = other.gameObject.GetComponent<PlayerHealth> ();
			theHealth.addHealth (gainHealthAmount);
			Destroy (gameObject);
		}
	}
}
