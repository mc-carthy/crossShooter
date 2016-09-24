using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private GameObject projectile;
	[SerializeField]
	private float moveSpeed = 2500f;

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
		Instantiate (
			projectile,
			transform.position,
			transform.rotation
		);
	}
}
