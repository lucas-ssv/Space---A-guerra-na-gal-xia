using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacaoPlaneta : MonoBehaviour {

	public GameObject planetaPrefab;
	public int velocidade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		planetaPrefab.transform.Rotate (0, Time.deltaTime * velocidade, 0);
		
	}
}
