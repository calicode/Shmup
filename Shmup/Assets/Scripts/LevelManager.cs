using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static int lastPlayedLevel;

	public static void LoadLevel (string name)
	{


		Debug.Log ("Loading level " + name);

		if (name == "lastPlayedLevel") {
			SceneManager.LoadScene (lastPlayedLevel);
		} else {
			SceneManager.LoadScene (name);
		}

	}

	public void LoadLevelWrapper (string name)
	{
		LoadLevel (name);


	}

	public void QuitGame ()
	{
		Debug.Log ("quit called");
	
		Application.Quit ();
	
	}

	/// <summary>
	/// Loads the next level.
	/// </summary>
	public static void LoadNextLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

}

