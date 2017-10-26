using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public float maxHealth;
	float currentHealth;


	public GameObject deathFX;

	PlayerController pController;


	//Hud Variables
	public Slider healthSlider;
	public Image damageScreen;

	bool damaged = false;
	Color damagedColor = new Color (0f,0f,0f,.5f);
	float smoothColor = 5f;

	// Use this for initialization
	void Start () {
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;
		currentHealth = maxHealth;


		pController = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(damaged){
			damageScreen.color = damagedColor;
		}else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColor * Time.deltaTime);

		}
		damaged = false;
	}

	public void addDamage(float damage){

		if (damage <= 0)
			return;
		currentHealth -= damage;
		healthSlider.value = currentHealth;
		damaged = true;
		//Debug.Log ("CurrentHealth =" + currentHealth);

		if (currentHealth <= 0)
			Death ();
	}

	public void addHealth(float gainHealthAmount){

		currentHealth += gainHealthAmount;

		if(currentHealth > maxHealth){

			currentHealth = maxHealth;
		}
		healthSlider.value = currentHealth;
	}

	public void Death(){

		Instantiate (deathFX,transform.position, transform.rotation);
		Destroy (gameObject);
	}
}


