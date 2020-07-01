using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class novoUsuario : MonoBehaviour {

	private string urlFormulario = "http://localhost:90/space/novousuario.php";

	public InputField inpNome, inpPontuacao;
	private string nome, pontuacao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void submitDados () {

		if (inpNome.text != "" && inpPontuacao.text != "") {
			nome = inpNome.text;
			pontuacao = inpPontuacao.text;

			WWWForm form = new WWWForm ();
			form.AddField ("nome", nome);
			form.AddField ("pontuacao", pontuacao);
			WWW send = new WWW (urlFormulario, form);

			inpNome.text = "";
			inpPontuacao.text = "";

			print ("Enviado");
		} else {
			print ("Ocorreu um erro");
		}

	}

}
