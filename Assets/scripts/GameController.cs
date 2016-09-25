using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Text timeText;
	[SerializeField]
	private EnemySpawner spawner;
	private float waveTime = 25;

	private void Update () {
		if (waveTime > 0) {
			waveTime -= Time.deltaTime;
			timeText.text = "Time: " + waveTime.ToString ("0");
			if (waveTime < 10) {
				timeText.color = Color.red;
			} else if (waveTime < 20) {
				timeText.color = Color.yellow;
			}
		} else {
			spawner.StopSpawning ();
		}
	}
}
