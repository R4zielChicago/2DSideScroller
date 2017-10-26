using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	public float speed;

	Animator enemyAnim;

	public GameObject enemyGraphic;

	//Flipping 
	bool canFlip = true;
	bool facingRight = false;

	float flipTime = 5f;
	float nextFlipChance = 0f;

	//Attacking
	public float chargeTime;
	float startChargeTime;
	bool charging;
	Rigidbody2D enemyRb;


	// Use this for initialization
	void Start () {
		enemyAnim = GetComponentInChildren<Animator> ();
		enemyRb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextFlipChance){

			if(Random.Range (0, 10) >= 5)
				FlipFacing ();
			nextFlipChance = Time.time + flipTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			
			if (facingRight && other.transform.position.x < transform.position.x) {
				
				FlipFacing ();
			} else if (!facingRight && other.transform.position.x > transform.position.x){

				FlipFacing ();
			}
		}
		canFlip = false;
		charging = true;
		startChargeTime = Time.time + chargeTime;
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.tag == "Player"){

			if(startChargeTime < Time.time){

				if(!facingRight){
					enemyRb.AddForce (new Vector2(-1,0) * speed);
				}else
					enemyRb.AddForce (new Vector2(1,0) * speed);
				enemyAnim.SetBool ("isCharging", charging);
				Debug.Log ("Charging = " + charging);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
	
		if(other.tag == "Player"){

			canFlip = true;
			charging = false;
			enemyRb.velocity = new Vector2 (0f, 0f);
			enemyAnim.SetBool ("isCharging", charging);
			Debug.Log ("Charging = " + charging);
		}
	}

	void FlipFacing(){
		
		if (!canFlip) {
			return;
		}
			
		float facingX = enemyGraphic.transform.localScale.x;
		facingX *= -1f;
		enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
		facingRight = !facingRight;
	}
}
