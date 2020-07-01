using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesInimigo : MonoBehaviour {

	public float velocidadeRot;

	Transform player;
	
	// Update is called once per frame
	void Update () {

		if (player == null) {

			//Encontrar o player
			GameObject go = GameObject.Find ("Player");

			if (go != null) {

				player = go.transform;
			
			}
		
		}

		if (player == null)
			return;

		Vector3 direcao = player.position - transform.position;
		direcao.Normalize ();

		float angleZ = Mathf.Atan2 (direcao.y, direcao.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler (0, 0, angleZ);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, velocidadeRot * Time.deltaTime);
		


	}
}
