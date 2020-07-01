using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	private inimigoMartePlay inimigo;

	private ArmaDireita armaDireita;

	private armaNave armaD;

	private playerShooting tiro;

	Vector3 position;

	public RectTransform xposisi;

	private virtualJoystick joystick;

	private pontuacao pontuacao;

	private SpriteRenderer cor;

	private Rigidbody2D playerRb;
	private Animator playerAnimator;

	public float moveForce = 5, boostMultiplier = 2;

	public float fronteiraPlayer;

	public float velocidade;
	public float velocidadeRot;

	public Transform arma;
	public GameObject tiroPrefab;
	public float forcaTiro;

	public GameObject explosaoPrefab;
	public float Hp;

	public GameObject armasExtras;

	//public Collider2D pocao;

	[SerializeField]
	private GameObject gameOverUI;

	// Use this for initialization
	void Start () {

		inimigo = FindObjectOfType (typeof(inimigoMartePlay)) as inimigoMartePlay;

		armaDireita = FindObjectOfType (typeof(ArmaDireita)) as ArmaDireita;

		armaD = FindObjectOfType (typeof(armaNave)) as armaNave;

		tiro = FindObjectOfType (typeof(playerShooting)) as playerShooting;

		joystick = FindObjectOfType (typeof(virtualJoystick)) as virtualJoystick;

		pontuacao = FindObjectOfType (typeof(pontuacao)) as pontuacao;

		playerRb = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		cor = GetComponent<SpriteRenderer> ();

	}

	void Update () {

		if (Input.GetButton ("Atirar")) {
		
			tiro.Atirar();
		
		}

	}

	// Update is called once per frame
	public void FixedUpdate () {

		// Rotacionar a nave
		Quaternion rot = transform.rotation;

		float MovimentoZ = rot.eulerAngles.z;

		MovimentoZ -= Input.GetAxis ("Horizontal") * velocidadeRot * Time.deltaTime;

		rot = Quaternion.Euler (0, 0, MovimentoZ);
		transform.rotation = rot;

		// mover a nave
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

	public void Atirar () {
	
		tiro.Atirar ();
		armaD.Atirou ();
		armaDireita.Atirou ();

	}

	void OnTriggerEnter2D (Collider2D col) {

		switch (col.gameObject.tag) {

		case "pocaoPower":
			pocaoPower ();
			Destroy (col.gameObject);
			//explodir ();
			break;

		case "coins":
			Power ();
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

		case "tiroInimigo":
			tomarDano (1);
			MudaCor ();
			break;

		case "inimigo":
			Hp--;
			MudaCor ();
			if (Hp <= 0) {
				explodir ();
				GameOver ();
			}
			break;

		case "boss":
			explodir ();
			Hp = 0;
			GameOver ();
			break;

		case "asteroids":
			explodir ();
			GameOver ();
			break;

		}

	}

	void MudaCor () {

		cor.color = Color.red;
		Invoke ("NormalizaCor", 0.08f);

	}

	void NormalizaCor () {

		cor.color = Color.white;

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

		Hp += 1;
		pontuacao.pontos += 250;

	}

	void Power () {

		pontuacao.pontos += 250;
		velocidade += 1;

	}

	public void GameOver () {

		Debug.Log ("Game Over!");
		gameOverUI.SetActive (true);

	} 

}
