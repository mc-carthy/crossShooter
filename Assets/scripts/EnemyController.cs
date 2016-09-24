using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private PlayerController player;
	[SerializeField]
	private float moveSpeed = 0.5f;
	private Vector2 direction;

	private void Start () {
		direction = player.transform.position - transform.position;
	}

	private void Update () {
		transform.Translate (direction * moveSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "projectile") {
			Destroy (gameObject);
		}
	}
}