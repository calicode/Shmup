using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{

	public  AudioClip playerShot;
	public AudioClip playerDeath;
	public AudioClip enemyShot;
	public AudioClip enemyDeath;
	public AudioSource bgMusic;
	static Jukebox instance = null;

	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}

		bgMusic = GetComponent <AudioSource> ();
		bgMusic.Play ();
		bgMusic.loop = true;

	}



	public void PlayJukeboxTrack (string clip, Vector3 location)
	{
		print ("got request to play at" + location);

		switch (clip) {
		case "playerShot":

			AudioSource.PlayClipAtPoint (playerShot, location);
			break;

		case "enemyDeath":
			AudioSource.PlayClipAtPoint (enemyDeath, location);
			break;

		case "enemyShot":
			AudioSource.PlayClipAtPoint (enemyShot, location);
			break;
		case "playerDeath":
			AudioSource.PlayClipAtPoint (playerDeath, location);
			break;
		default:

			print ("some wierd stuff got passed to jukebox" + clip);
			break;
		} 
	
	}







}
