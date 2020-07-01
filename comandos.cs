using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comandos : MonoBehaviour {

	private Player scriptPlayer;

	public string nomeBotao;

	void Start () {

		scriptPlayer = FindObjectOfType (typeof(Player)) as Player;

	}

	public void aoTocar () {

		switch (nomeBotao) {

		case "Atirar":
			scriptPlayer.Atirar ();
			break;

		case "Analogico":
			scriptPlayer.FixedUpdate ();
			break;
		}

	}

	public void aoTirar () {

		switch (nomeBotao) {

		case "Atirar":

			break;

		case "Analogico":

			break;
		}

	}
}
