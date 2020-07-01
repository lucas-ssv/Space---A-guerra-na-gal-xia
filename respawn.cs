using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	//public Transform spawn;

	public GameObject[] inimigoPrefab;
	public Vector3 spawnValues; // Valores onde os inimigos vão ser respawnados
	public int hazardCount; // Quantidade de inimigos que vão ser respawnados
	public float spawnWait; // Tempo de espera
	public float startWait; // Tempo para começar
	public float waveWait;

	// Use this for initialization
	void Start () {

		StartCoroutine (SpawnWaves ());

	}

	IEnumerator SpawnWaves () {

		yield return new WaitForSeconds (startWait);

		while (true) {

			for (int i = 0; i < hazardCount; i++) {

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (inimigoPrefab [Random.Range (0, inimigoPrefab.Length)], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}

			yield return new WaitForSeconds (waveWait);


		}

	}

}
