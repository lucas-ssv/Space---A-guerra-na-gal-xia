using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaTrigger : MonoBehaviour {

	public GameObject tiroPrefab;

	public float delay;
	float cooldownTimer = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void Atirou () {

		cooldownTimer -= Time.deltaTime;

		//if (Input.GetButton ("Atirar") && cooldownTimer <= 0) {

		// Atirar
		//print("Atirou!");
		cooldownTimer = delay;

		Vector3 offset = transform.rotation * new Vector3 (0, 0, 0);
		//Vector3 power = transform.rotation * new Vector3 (0.7f, 0.7f, 0);

		Instantiate (tiroPrefab, transform.position + offset, transform.rotation);
		//Instantiate (tiroPrefab, transform.position + power, transform.rotation);

		//}

		//Destroy (gameObject, 10); // Durabilidade da poção

	}
}
