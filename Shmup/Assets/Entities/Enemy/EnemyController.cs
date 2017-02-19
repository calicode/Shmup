using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public static int maxHealth = 10;
	public static int currentHealth;
	public GameObject laserEnemy;
	public int shotCooldown;
	ScoreKeeper scoreKeeper;
	Jukebox jukebox;
	// Use this for initialization
	void Start ()
	{
		jukebox = GameObject.FindObjectOfType<Jukebox> ();
		scoreKeeper = GameObject.Find ("Score").GetComponent <ScoreKeeper> ();
		shotCooldown = Random.Range (60, 240);
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (shotCooldown > 0) {
			shotCooldown--;
		} else {
			FireWeapon ();
		}

	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		Laser laserHit = trigger.GetComponent <Laser> ();
		if (laserHit) {

			takeDamage (laserHit.getDamage ());
			laserHit.killMe ();

		}
	}

	void takeDamage (int damageAmount)
	{
		currentHealth -= damageAmount;
		if (currentHealth <= 0) {
			jukebox.PlayJukeboxTrack ("enemyDeath", transform.position);
			scoreKeeper.Score (4);
			Destroy (gameObject);
		}
	}



	public void FireWeapon ()
	{
		GameObject thisLaser = Instantiate (laserEnemy, new Vector3 (transform.position.x, transform.position.y - .2f, 0), Quaternion.identity);
		Rigidbody2D rb = thisLaser.GetComponent <Rigidbody2D> ();
		rb.velocity = new Vector2 (0f, (Random.value - 5f));
		shotCooldown = Random.Range (60, 180);
		jukebox.PlayJukeboxTrack ("enemyShot", transform.position);

	}
}
