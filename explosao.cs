using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao : MonoBehaviour {

	public float tempoVida;
	private float tempTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		tempTime += Time.deltaTime;

		if (tempTime >= tempoVida) {
		
			Destroy (this.gameObject);

		}
		
	}
}
