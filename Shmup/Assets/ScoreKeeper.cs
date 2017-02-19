using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
	static int score;
	Text myScore;
	// Use this for initialization
	void Start ()
	{

		myScore = gameObject.GetComponent <Text> ();
		myScore.text = score.ToString ();
	}

	public void Score (int value)
	{
		score += value;
		myScore.text = score.ToString ();

	}

	public void ResetScore ()
	{
		score = 0;
		myScore.text = score.ToString ();
	}

	public int GetScore ()
	{
		return score;
	}
	// Update is called once per frame
}

