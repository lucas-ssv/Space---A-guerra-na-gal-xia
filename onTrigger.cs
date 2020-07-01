using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour {

	public GameObject explosaoPrefab;

	void OnTriggerEnter2D (Collider2D col) {

		switch (col.gameObject.tag) {

		case "parede":
			explodir ();
			break;

		}
	
		if (!col.isTrigger) {
			Destroy (this.gameObject);
		}
	
	}

	void explodir () {

		GameObject tempPrefab = Instantiate (explosaoPrefab) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		Destroy (this.gameObject);

	}
}
