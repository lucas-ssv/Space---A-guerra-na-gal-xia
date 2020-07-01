using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroirIni : MonoBehaviour {

	private Player player;
	private float velocidade = 1;


	// Use this for initialization
	void Start () {

		player = FindObjectOfType (typeof(Player)) as Player;
		
	}
	
	// Update is called once per frame
	void Update () {

		player.velocidadeRot += velocidade;
		
	}
}
