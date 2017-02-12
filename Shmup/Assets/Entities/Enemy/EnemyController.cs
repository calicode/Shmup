using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public static int maxHealth = 10;
	public static int currentHealth;

	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		print ("collision happaned with" + trigger.gameObject.name); 
		Laser laserHit = trigger.GetComponent <Laser> ();
		if (laserHit) {

			takeDamage (Laser.getDamage ());

		}
	}

	void takeDamage (int damageAmount)
	{
		currentHealth -= damageAmount;
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}

	}
}
