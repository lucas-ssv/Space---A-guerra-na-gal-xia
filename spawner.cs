using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	private Player player;

	public int inimigos;

	//private Inimigo explodiu;

	public GameObject animacao;

	public GameObject[] inimigoPrefab;
	public Vector3 spawnValues; // Valores onde os inimigos vão ser respawnados
	public int hazardCount; // Quantidade de inimigos que vão ser respawnados
	public float spawnWait; // Tempo de espera
	public float startWait; // Tempo para começar
	public float waveWait;

	public GameManager gameManager;

	private int waveIndex = 0;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType (typeof(Player)) as Player;

		StartCoroutine (SpawnWaves ());

	}

	void Update () {

		//print (inimigos);

		if (inimigos <= 0) {
		
			gameManager.WinLevel ();
			this.enabled = false;
		
		}

	}
		
	IEnumerator SpawnWaves () {

		yield return new WaitForSeconds (startWait);

		//while (true) {

			for (int i = 0; i < hazardCount; i++) {

				if (player.transform.position != spawnValues) {

					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;

					Instantiate (animacao, spawnPosition, spawnRotation);
					Instantiate (inimigoPrefab [Random.Range (0, inimigoPrefab.Length)], spawnPosition, spawnRotation);

					yield return new WaitForSeconds (spawnWait);
				}

			}

			yield return new WaitForSeconds (waveWait);

		//}

	}

	void explodir () {

		GameObject tempPrefab = Instantiate (animacao) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		//Destroy (this.gameObject);

	}


}
