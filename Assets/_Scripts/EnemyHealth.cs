using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	public float enemyMaxHealth;

	public GameObject enemyDeathFX;
	public Slider enemyHealthSlider;

	float currentHealth;

	public bool dropsItem;

	public GameObject itemDrop;

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
		enemyHealthSlider.maxValue = enemyMaxHealth;
		enemyHealthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){

		enemyHealthSlider.gameObject.SetActive (true);
		currentHealth -= damage;
		enemyHealthSlider.value = currentHealth;
		Debug.Log ("Current enemey health = " + enemyHealthSlider.value);

		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Death(){

		if(dropsItem){

			Instantiate (itemDrop, transform.position, transform.rotation);
		}
		Destroy (gameObject);
		Instantiate (enemyDeathFX, transform.position, transform.rotation);
	}
}

