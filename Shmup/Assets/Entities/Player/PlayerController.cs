using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerSpeed = 4.0f;
	float hInput;
	Vector3 leftmost;
	Vector3 rightmost;
	public float padding = .5f;
	public GameObject laser;
	public float shotSpeed = 5f;
	int shotMaxCooldown = 15;
	int shotCooldown = 0;
	int maxHealth, currentHealth;
	static int maxLives = 5;
	static int currentLives = maxLives;



	// Use this for initialization
	void Start ()
	{
		maxHealth = 20;
		currentHealth = maxHealth;
		// setup for clamping player to screen bounds, determines bounds automatically. 
	
		float distance = transform.position.z - Camera.main.transform.position.z;	
		leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));	
		rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		// i do not fully understand how this works yet. 
	}

	// Update is called once per frame
	void Update ()
	{


		hInput = Input.GetAxis ("Horizontal");
		float hMovement = (hInput * playerSpeed) * Time.deltaTime;
		transform.Translate (new Vector3 (hMovement, 0, 0));
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, leftmost.x + padding, rightmost.x - padding), transform.position.y, 0);

		if (shotCooldown > 0) {
			shotCooldown--;
		}
		if (Input.GetButton ("Fire1") && shotCooldown <= 0) {
			FireWeapon ();
		}
	}


	public void FireWeapon ()
	{
		GameObject thisLaser = Instantiate (laser, new Vector3 (transform.position.x, transform.position.y + 1f, 0), Quaternion.identity);
		Rigidbody2D rb = thisLaser.GetComponent <Rigidbody2D> ();
		rb.velocity = new Vector2 (0f, shotSpeed);
		shotCooldown = shotMaxCooldown;
	}



	public void TakeDamage (int damageAmount)
	{
		print ("player taking damage in amount of " + damageAmount + "curr health is" + currentHealth + "Curr lives are " + currentLives); 
		
		currentHealth -= damageAmount;
		if (currentHealth <= 0) {
			HandleDeath ();
		}


	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		EnemyShot laserHit = trigger.GetComponent <EnemyShot> ();
		if (laserHit) {

			TakeDamage (laserHit.getDamage ());
			laserHit.killMe ();

		}
	}

	void HandleDeath ()
	{
		currentLives--;
		if (currentLives > 0) {
			Instantiate (gameObject);
			Destroy (gameObject);
		} else {
			print ("Out of lives"); 
			Destroy (gameObject);
		}
	}
}
