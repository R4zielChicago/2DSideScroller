using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {


	public float damage;
	public float damageRate;
	public float pushBackForce;

	float nextDamage;

	// Use this for initialization
	void Start () {
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.tag == "Player" && nextDamage < Time.time){
			PlayerHealth pHealth = other.gameObject.GetComponent<PlayerHealth> ();

			pHealth.addDamage (damage);
			nextDamage = Time.time + damageRate;

			PushBack (other.transform);

		}
	}

	void PushBack(Transform pushedObject){

		Vector2 pushDirection = new Vector2 (0, (pushedObject.position.y - transform.position.y)).normalized;

		pushDirection *= pushBackForce;

		Rigidbody2D pushRigidBody = pushedObject.gameObject.GetComponent<Rigidbody2D> ();

		pushRigidBody.velocity = Vector2.zero;

		pushRigidBody.AddForce (pushDirection, ForceMode2D.Impulse);

	}
}
