using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	int baseDamage, maxDamage, currentDamage;
	// Use this for initialization
	void Start ()
	{
		baseDamage = 1;
		maxDamage = 5;
		currentDamage = baseDamage;
	}

	void Update ()
	{
		if (currentDamage > maxDamage) {
			currentDamage = maxDamage;
		}

	}

	public int getDamage ()
	{
		return currentDamage;
	}

	public void killMe ()
	{
		Destroy (gameObject);

	}
	// Update is called once per frame

}
