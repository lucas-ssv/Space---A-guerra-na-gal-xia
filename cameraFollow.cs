using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	private Player scriptPlayer;
	//public Transform Left, Right;
	private Vector3 destino;
	public float velocidade;
	//public bool comLerp;
	//public bool seguirY;

	void Start () {

		scriptPlayer = FindObjectOfType (typeof(Player)) as Player;

	}
	
	// Update is called once per frame
	void Update () {

		destino = new Vector3 (scriptPlayer.transform.position.x, scriptPlayer.transform.position.y, transform.position.z);

		transform.position = Vector3.Lerp (transform.position, destino, velocidade * Time.deltaTime);
		//transform.position = new Vector3 (scriptPlayer.transform.position.x, scriptPlayer.transform.position.y, transform.position.z);
		
	}
}


