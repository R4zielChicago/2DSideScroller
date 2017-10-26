using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHit : MonoBehaviour {

	PlayerController myPController;
	public GameObject explosionEffect;

	Animator myAnim;

	public float swordDamage;
	float attackType;
	// Use this for initialization
	void Start(){

		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){

		if (Input.GetButtonDown ("Fire1")) {
			//GetComponent<BoxCollider2D> ().enabled = true;
			myAnim.SetTrigger ("attackSword");
		}
	}

	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			Instantiate (explosionEffect, transform.position, transform.rotation);

			if (other.tag == "Enemy") {
				EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();
				enemyHealth.addDamage (swordDamage);
			}
		}

	}

//	void OnTriggerStay2D(Collider2D other){
//
//		if(Input.GetAxisRaw ("Fire1") > 0){
//
//			if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")){
//
//
//				Instantiate (explosionEffect, transform.position, transform.rotation);
//				//GetComponent<BoxCollider2D> ().enabled = false;
//			}
//		}
//		//GetComponent<BoxCollider2D> ().enabled = true;
//	}
}
