using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameObject player;
	[SerializeField]
	private float moveSpeed = 0.5f;
	private Vector2 direction;

	private void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		if (player != null) {
			direction = (player.transform.position - transform.position).normalized;
		}
	}

	private void Update () {
		transform.Translate (direction * moveSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "projectile") {
			Destroy (trig.gameObject);
			Destroy (gameObject);
		}
	}
}