﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	// Use this for initialization
	public float width = 10f;
	public float height = 5f;
	Vector3 leftmost;
	Vector3 rightmost;
	public float padding;
	public float formationSpeed = 5f;
	public string moveDirection = "Left";

	void Start ()
	{
		padding = width / 2;
		spawnEnemiesAtSpawnPositions ();
		float distance = transform.position.z - Camera.main.transform.position.z;	
		leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));	
		rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));

	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}
	// Update is called once per frame
	void Update ()
	{
		moveEnemies ();
	}

	public void spawnEnemiesAtSpawnPositions ()
	{
	
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
	
		}
	

	}

	public void moveEnemies ()
	{
		if (moveDirection == "Right") {
			transform.Translate (new Vector3 (formationSpeed * Time.deltaTime, 0, 0));
			if (transform.position.x > rightmost.x - padding) {
				moveDirection = "Left";
			}
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, leftmost.x + padding, rightmost.x - padding), transform.position.y, 0);
		} else if (moveDirection == "Left") {
			transform.Translate (new Vector3 (-formationSpeed * Time.deltaTime, 0, 0));
			if (transform.position.x < leftmost.x + padding) {
				moveDirection = "Right";
			}

			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, leftmost.x + padding, rightmost.x - padding), transform.position.y, 0);
		}
		

	}
}
