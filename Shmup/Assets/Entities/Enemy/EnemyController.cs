using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public static int maxHealth = 10;
	public static int currentHealth;
	public GameObject laserEnemy;
	public int shotCooldown;
	public ScoreKeeper scoreKeeper;
	AudioSource shotSoundClip;
	public AudioSource deathClip;
	AudioSource[] audioSources;
	// Use this for initialization
	void Start ()
	{
		
		audioSources = GetComponents <AudioSource> ();
		Debug.Log (audioSources [0].priority);
		if (audioSources [0].priority > 128) {
			deathClip = audioSources [0];
			shotSoundClip = audioSources [1];
		} else {
			deathClip = audioSources [1];
			shotSoundClip = audioSources [0];
		}
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
			deathClip.Play ();
			print ("i should have played a sound but i didn't deahtclip priority is" + deathClip.priority); 
			scoreKeeper.Score (4);
			ohJustDie ();
		}

	}

	void ohJustDie ()
	{
		Destroy (gameObject);
	}


	public void FireWeapon ()
	{
		GameObject thisLaser = Instantiate (laserEnemy, new Vector3 (transform.position.x, transform.position.y - 1f, 0), Quaternion.identity);
		Rigidbody2D rb = thisLaser.GetComponent <Rigidbody2D> ();
		rb.velocity = new Vector2 (0f, -5f);
		shotCooldown = Random.Range (60, 180);
		shotSoundClip.Play ();
	}
}
