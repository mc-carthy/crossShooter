using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	private EnemyController enemy;
	[SerializeField]
	private float spawnRate = 2f;
	private bool canSpawn = true;
	private Vector3[] spawnPositions = new Vector3[] {
		new Vector3 (10, 6, 0),
		new Vector3 (-10, 6, 0),
		new Vector3 (10, -6, 0),
		new Vector3 (-10, -6, 0),
	};

	private void Start () {
		StartCoroutine (SpawnEnemies(spawnRate));
	}

	private void SpawnEnemiesAtCorners() {
		foreach (Vector3 pos in spawnPositions) {
			EnemyController newEnemy = Instantiate (
				enemy,
				pos,
				Quaternion.identity
			) as EnemyController;
			newEnemy.transform.SetParent (this.transform);
		}
	}

	private IEnumerator SpawnEnemies (float spawnRate) {
		while (canSpawn) {
			yield return new WaitForSeconds (spawnRate);
			SpawnEnemiesAtCorners ();
		}
	}
}
