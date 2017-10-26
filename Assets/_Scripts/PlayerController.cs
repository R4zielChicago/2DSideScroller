using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed, jumpHeight;

	private Rigidbody2D rigidBody;
	Animator myAnim;


	bool facingRight;


	bool grounded = false;

	float move;

	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;

	//Dash
	public float dashDistance;
	float buttonPress;

	//Sword Variables
	BoxCollider2D swordCollider;
	GameObject swordHand;
	public float swordAttackRate = .5f;
	float nextSwordAttack = 0f;



	//Skill Variables
	public Transform handSkillPos;
	public GameObject skill;
	public float fireRate = 5f;
	float nextFire = 0f;




	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponentInChildren<Animator> ();
		swordHand = GameObject.FindGameObjectWithTag ("SwordHit");
		swordCollider = swordHand.GetComponent<BoxCollider2D> ();
		swordCollider.enabled = false;
		facingRight = true;

	}
	
	// Update is called once per frame
	void Update () {



	}

	void FixedUpdate(){

		//Check if we are grounded Physics2d.overlapCircle draws a circle and checks for a condition
		//It takes a position, a radius, and a LayerMask
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool ("isGrounded", grounded);
		//Debug.Log ("grounded = " + grounded);

		myAnim.SetFloat ("verticalSpeed", rigidBody.velocity.y);

		move = Input.GetAxis ("Horizontal");

		myAnim.SetFloat ("Speed", Mathf.Abs(move));

		//Movement
		rigidBody.velocity = new Vector2 (move * maxSpeed, rigidBody.velocity.y);

		if (move > 0 && !facingRight){

			flip ();
		} else if(move < 0 && facingRight){

			flip ();
		}

		// Jumping
		if (grounded && Input.GetAxis ("Jump") > 0) {

			grounded = false;
			myAnim.SetBool ("isGrounded", grounded);
			rigidBody.AddForce (new Vector2 (0, jumpHeight));
		}


		//Player Skill
		if (Input.GetButtonDown ("Fire2")){
			swordCollider.enabled = true;
			Skill (); 
		}

		//Player Sword
		if (Input.GetButtonDown ("Fire1")){
			swordCollider.enabled = true;
			Sword ();
		}

		if(Input.GetButtonUp ("Fire1")){

			swordCollider.enabled = false;
		}


		//Crouching
		if (Input.GetButtonDown ("Vertical")) {
			buttonPress++;
			Crouch ();
		}
			
		if(Input.GetButtonUp ("Vertical")){

			myAnim.SetTrigger ("backToIdle");
		}

	}
	//Flip sprite when not facing right to face left
	void flip(){

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Skill(){
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;

			if (facingRight){
					
				myAnim.SetTrigger ("attackSkill");
				Instantiate (skill, handSkillPos.position, Quaternion.Euler (new Vector3 (0, 0, 0)));

			}else if (!facingRight){

				myAnim.SetTrigger ("attackSkill");
				Instantiate (skill, handSkillPos.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));

			}
		}
	}

	void Sword(){

		if (Time.time > nextSwordAttack){
			nextSwordAttack = Time.time + swordAttackRate;

			if (facingRight){

				myAnim.SetTrigger ("attackSword");
			}
			if (!facingRight){

				myAnim.SetTrigger ("attackSword");
			}
		}
	}

	void Crouch(){

		myAnim.SetTrigger ("crouch");

		if (buttonPress >= 2){

			myAnim.SetTrigger ("crouchDash");

			//myAnim.SetFloat ("buttonPress", Mathf.Abs(buttonPress));
			//rigidBody.AddForce (new Vector2 (10f, 0));
			//rigidBody.velocity. = (new Vector2 (move * dashDistance, 0));
			//rigidBody.AddForce (new Vector2 (1, 0) * dashDistance);
			buttonPress = 0;
		}


	}
}
