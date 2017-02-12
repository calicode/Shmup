using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}
