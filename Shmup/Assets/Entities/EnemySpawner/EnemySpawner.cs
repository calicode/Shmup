using System.Collections;
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
	public float spawnDelay = .5f;

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
		CheckIfAllEnemiesDead ();
	}

	public void spawnEnemiesAtSpawnPositions ()
	{
	
		Transform freePosition = NextFreeSpawnPosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}

	
		if (NextFreeSpawnPosition ()) {
			Invoke ("spawnEnemiesAtSpawnPositions", spawnDelay);
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

	bool CheckIfAllEnemiesDead ()
	{
		foreach (Transform childPositionGameObject  in transform) {

			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		spawnEnemiesAtSpawnPositions ();
		return true;
	}

	Transform NextFreeSpawnPosition ()
	{

		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}

		}
		print ("no free spawn positions hmm"); 
		return null;
	}
}
