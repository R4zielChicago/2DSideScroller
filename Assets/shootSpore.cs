using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpore : MonoBehaviour {
	public GameObject projectile;
	public float shootTime;
	public int chanceToShoot;
	public Transform shootFrom;

	float nextShootTime;
	Animator cannonAnim;


	// Use this for initialization
	void Start () {
		cannonAnim = GetComponentInChildren<Animator> ();
		nextShootTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		 

		if (other.tag == "Player" && nextShootTime < Time.time){

			nextShootTime = Time.time + shootTime;

			if(Random.Range (0f, 10f) >= chanceToShoot){

				Instantiate (projectile, shootFrom.position, Quaternion.identity);
				cannonAnim.SetTrigger ("CannonShoot");
			}
		}
			
	}
}
