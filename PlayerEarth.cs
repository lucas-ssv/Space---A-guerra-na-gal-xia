using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEarth : MonoBehaviour {

	private pontuacao pontuacao;

	private Rigidbody2D playerRb;
	private Animator playerAnimator;

	public float fronteiraPlayer;

	public float velocidade;
	public float velocidadeRot;

	public Transform arma;
	public GameObject tiroPrefab;
	public float forcaTiro;

	public GameObject explosaoPrefab;
	public float Hp;

	public GameObject armasExtras;

	public Collider2D pocao;

	[SerializeField]
	private GameObject gameOverUI;

	// Use this for initialization
	void Start () {

		pontuacao = FindObjectOfType (typeof(pontuacao)) as pontuacao;

		playerRb = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();

	}

	void Update () {

		/*if (Input.GetButtonDown ("Atirar")) {
			Atirar ();
		}*/

	}

	// Update is called once per frame
	void FixedUpdate () {

		// Rotacionar a nave
		Quaternion rot = transform.rotation;

		float MovimentoZ = rot.eulerAngles.z;

		MovimentoZ -= Input.GetAxis ("Horizontal") * velocidadeRot * Time.deltaTime;

		rot = Quaternion.Euler (0, 0, MovimentoZ);
		transform.rotation = rot;

		// Mover a nave
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0, Input.GetAxis ("Vertical") * velocidade * Time.deltaTime, 0);

		pos += rot * velocity;

		// Restringir câmera na posição Y
		if (pos.y + fronteiraPlayer > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - fronteiraPlayer;
		} 

		if (pos.y - fronteiraPlayer < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + fronteiraPlayer;
		}

		// Restringir a câmera na posição X 
		float screenRatio = (float) Screen.width / (float) Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + fronteiraPlayer > widthOrtho) {
			pos.x = widthOrtho - fronteiraPlayer;
		} 

		if (pos.x - fronteiraPlayer < -widthOrtho) {
			pos.x = -widthOrtho + fronteiraPlayer;
		}

		// Atualiza sua posição
		transform.position = pos;

	}

	/*void Atirar () {
	
		GameObject tempPrefab = Instantiate (tiroPrefab) as GameObject;
		tempPrefab.transform.position = arma.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, forcaTiro));

	}*/

	void OnTriggerEnter2D (Collider2D col) {

		switch (col.gameObject.tag) {

		case "tiroInimigo":
			tomarDano (1);
			break;

		case "pocaoPower":
			pocaoPower ();
			Destroy (col.gameObject);
			//explodir ();
			break;

		case "coins":
			coins ();
			Destroy (col.gameObject);
			break;

		case "caixaExplosiva":
			explodir ();
			Destroy (col.gameObject);
			GameOver ();
			break;

		}

	}

	void OnCollisionEnter2D (Collision2D col) {

		switch (col.gameObject.tag) {

		case "inimigo":
			Hp--;
			if (Hp <= 0) {

				explodir ();
				GameOver ();

			}
			break;

		case "asteroids":
			explodir ();
			GameOver ();
			break;

		}

	}

	void tomarDano (int danoTomado) {

		Hp -= danoTomado;
		if (Hp <= 0) {
			explodir ();
			GameOver ();
		}

	}

	void explodir () {

		GameObject tempPrefab = Instantiate (explosaoPrefab) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		Destroy (this.gameObject);

	}

	void pocaoPower () {

		armasExtras.SetActive (true);
		pontuacao.pontos += 250;

	}

	void coins () {

		pontuacao.pontos += 1000;

	}

	public void GameOver () {

		Debug.Log ("Game Over!");
		gameOverUI.SetActive (true);
	} 



}
