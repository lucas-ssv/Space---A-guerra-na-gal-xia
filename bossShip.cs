using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossShip : MonoBehaviour {

	public GameObject bossPrefab;
	public float velocidade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		bossPrefab.transform.Rotate (0, 0, Time.deltaTime * velocidade);
		
	}
}
