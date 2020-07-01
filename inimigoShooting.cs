using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoShooting : MonoBehaviour {

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

			Vector3 offset = transform.rotation * new Vector3 (0, 1.5f, 0);

			Instantiate (tiroPrefab, transform.position + offset, transform.rotation);

		}

	}
}
