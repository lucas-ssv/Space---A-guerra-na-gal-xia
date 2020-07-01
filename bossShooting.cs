using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting : MonoBehaviour {

	public Transform objeto;

	public GameObject tiroPrefab;

	public float delay;
	float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {

		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0) {

			// Atirar
			print("Atirou!");
			cooldownTimer = delay;

			Vector3 offset = new Vector3 (objeto.position.x, objeto.position.y, objeto.position.z);

			Instantiate (tiroPrefab, offset, transform.rotation);

		}
	}
}
