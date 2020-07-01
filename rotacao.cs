using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacao : MonoBehaviour {

	public Transform orbita;
	public int velocidade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		orbita.transform.Rotate (0, 0, Time.deltaTime * velocidade);

	}
}
