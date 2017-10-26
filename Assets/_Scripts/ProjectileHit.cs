using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour {
	public float skillDamage;

	ProjectileController myPcontroller;

	float attackType;

	public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {
		myPcontroller = GetComponentInParent<ProjectileController> ();
	
	}

	void Start(){

		if(gameObject.tag == "FireBall"){

			attackType = 0;
		}
		if(gameObject.tag == "SwordHit"){

			attackType = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.layer == LayerMask.NameToLayer ("Shootable")){

			myPcontroller.removeForce ();

			Instantiate (explosionEffect, transform.position, transform.rotation);

			Destroy (gameObject);

			if(other.tag == "Enemy"){

				EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();

				if(attackType == 0.0f){
					enemyHealth.addDamage (skillDamage);
//					Debug.Log ("enemyHealth = " + enemyHealth);
				}

				//Debug.Log ("Enemy Health = " + enemyHealth);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.gameObject.layer == LayerMask.NameToLayer ("Shootable")){

			myPcontroller.removeForce ();

			Instantiate (explosionEffect, transform.position, transform.rotation);

			Destroy (gameObject);

			if(other.tag == "Enemy"){

				EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();

				if(attackType == 0.0f){
					enemyHealth.addDamage (skillDamage);
				}
			}
		}
	}
}
