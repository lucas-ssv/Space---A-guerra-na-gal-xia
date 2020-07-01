using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontuacao : MonoBehaviour {

	private Player player;
	public Text vida;
	public Text speed;

	public Text score;
	public Text highScore;
	public int pontos;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType (typeof(Player)) as Player;

		highScore.text = PlayerPrefs.GetInt ("HighScore", 0).ToString ();

	}
	
	void Update () {

		speed.text = player.velocidade.ToString ();

		vida.text = player.Hp.ToString ();

		score.text = pontos.ToString ();

		if (pontos > PlayerPrefs.GetInt ("HighScore", 0)) {
		
			PlayerPrefs.SetInt ("HighScore", pontos);
			highScore.text = pontos.ToString ();
		
		}
	}

	public void Reset () {

		PlayerPrefs.DeleteAll ();
		highScore.text = "0";

	}
		
}
