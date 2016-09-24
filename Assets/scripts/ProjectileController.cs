using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public Vector3 directionToFire;

	private Vector3 direction;
	private float speed = 5f;

	private void Start () {
		direction = directionToFire.normalized;
	}

	private void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
	}
}
