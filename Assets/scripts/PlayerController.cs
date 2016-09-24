using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private ProjectileController projectile;
	[SerializeField]
	private float moveSpeed = 2500f;
	[SerializeField]
	private int projectilesToSpawn = 4;
	[SerializeField]
	private float shootCooldown;
	private float currentCooldown;
	private bool canShoot = true;

	private void Start () {
		HideMouseCursor ();
	}

	private void Update () {
		MovePlayerToMouse ();
		FireOnMouseClick ();
		ReduceCooldown ();
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "enemy") {
			ReloadScene ();
		}
	}

	private void MovePlayerToMouse () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = transform.position.z - Camera.main.transform.position.z;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		transform.position = Vector3.MoveTowards (transform.position, mousePos, moveSpeed * Time.deltaTime);
	}

	private void HideMouseCursor () {
		Cursor.visible = false;
	}

	private void FireOnMouseClick () {
		if (Input.GetMouseButton (0) && canShoot) {
			InstantiateProjectile ();
		}
	}

	private void InstantiateProjectile () {
		ResetCooldown ();
		for (int i = 0; i < projectilesToSpawn; i++) {
			ProjectileController newProjectile = Instantiate (
				projectile,
				transform.position,
				transform.rotation
			) as ProjectileController;
			newProjectile.directionToFire = DegreeToVector2 (360 * i / projectilesToSpawn);
		}
	}

	private void ReduceCooldown () {
		currentCooldown -= Time.deltaTime;
		if (currentCooldown <= 0) {
			canShoot = true;
		}
	}

	private void ResetCooldown () {
		canShoot = false;
		currentCooldown = shootCooldown;
	}

	/*
	private void DecreaseShootCooldown () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			shootCooldown /= 2;
		}
	}
	*/

	private Vector2 DegreeToVector2 (float degree) {
		degree *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(degree), Mathf.Sin(degree));
	}

	private void ReloadScene () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
	}
}
