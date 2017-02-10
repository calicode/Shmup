using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	Vector3 leftmost;
	Vector3 rightmost;
	public float padding = .5f;
	// Use this for initialization
	void Start ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;	
		leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));	
		rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.Translate (new Vector3 (Random.Range (1, 5), Random.Range (1, 5), 0));
		//transform.position = new Vector3 (Mathf.Clamp (transform.position.x, leftmost.x + padding, rightmost.x - padding), transform.position.y, 0);

	}
}
