using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids : MonoBehaviour {

	public Transform objeto;
	public Transform objetoMax;

	public GameObject[] inimigoPrefab;
	public Vector3 spawnValues; // Valores onde os inimigos vão ser respawnados
	public int hazardCount; // Quantidade de inimigos que vão ser respawnados
	public float spawnWait; // Tempo de espera
	public float startWait; // Tempo para começar
	public float waveWait;

	public GameObject explosaoPrefab;

	// Use this for initialization
	void Start () {

		StartCoroutine (SpawnWaves ());

	}

	IEnumerator SpawnWaves () {

		yield return new WaitForSeconds (startWait);

		while (true) {

			for (int i = 0; i < hazardCount; i++) {

				Vector3 spawnPosition = new Vector3 (Random.Range(objeto.position.x, objetoMax.position.x), objeto.position.y, objeto.position.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (inimigoPrefab [Random.Range (0, inimigoPrefab.Length)], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}

			yield return new WaitForSeconds (waveWait);

		}

	}

	void OnTriggerEnter2D (Collider2D col) {

		switch (col.gameObject.tag) {

		case "Respawn":
			explodir ();
			break;

		}

	}

	void explodir () {

		GameObject tempPrefab = Instantiate (explosaoPrefab) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		//Destroy (this.gameObject);

	}


}
