using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private ProjectileController projectile;
	[SerializeField]
	private float moveSpeed = 2500f;
	[SerializeField]
	private int projectilesToSpawn = 4;

	private void Start () {
		HideMouseCursor ();
	}

	private void Update () {
		MovePlayerToMouse ();
		FireOnMouseClick ();
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
		if (Input.GetMouseButtonDown (0)) {
			InstantiateProjectile ();
		}
	}

	private void InstantiateProjectile () {
		for (int i = 0; i < projectilesToSpawn; i++) {
			ProjectileController newProjectile = Instantiate (
				projectile,
				transform.position,
				transform.rotation
			) as ProjectileController;
			newProjectile.directionToFire = DegreeToVector2 (360 * i / projectilesToSpawn);
		}
	}

	private Vector2 DegreeToVector2(float degree)
	{
		degree *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(degree), Mathf.Sin(degree));
	}
}
