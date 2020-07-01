using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisao : MonoBehaviour {

	public GameObject explosaoPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
	
		switch (col.gameObject.tag) {

		case "Finish":
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
