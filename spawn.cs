using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawn : MonoBehaviour {

	public GameObject animacao;

	public static int EnemiesAlive = 0;

	public GameObject[] waves; // inimigos

	public Vector3 spawnValues; 

	public float timeBetweenWaves = 5f; // tempo de espera 
	private float countdown = 2f; // quantidade de inimigos

	public GameManager gameManager;

	private int waveIndex = 0;

	void Update () {

		if (EnemiesAlive > 0) {

			return;

		}

		if (waveIndex == waves.Length) {

			gameManager.WinLevel ();
			this.enabled = false;

		}

		if (countdown <= 0f) {

			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves;
			return;

		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

	}

	IEnumerator SpawnWave () {

		GameObject wave = waves [waveIndex];

		EnemiesAlive = waveIndex;

		for (int i = 0; i < waves.Length; i++) {

			SpawnEnemy (wave);
			yield return new WaitForSeconds (1f);

		}

		waveIndex++;

	}

	void SpawnEnemy (GameObject enemy) {

		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (animacao, spawnPosition, spawnRotation);
		Instantiate (enemy, spawnPosition, spawnRotation);

	}

}
