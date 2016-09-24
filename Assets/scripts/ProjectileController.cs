using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public Vector3 directionToFire;

	private Vector3 direction;
	private float speed = 5;
	private float lifetime = 2;

	private void Start () {
		direction = directionToFire.normalized;
		Destroy (gameObject, lifetime);
	}

	private void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
	}
}
