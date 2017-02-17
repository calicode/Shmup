using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
	int score;
	Text myScore;
	// Use this for initialization
	void Start ()
	{
		score = 0;
		myScore = gameObject.GetComponent <Text> ();
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

	// Update is called once per frame
}

