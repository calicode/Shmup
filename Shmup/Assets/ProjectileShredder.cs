using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShredder : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D trigger)
	{
		Destroy (trigger.gameObject);

	}
}
