using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ranking : MonoBehaviour {

    private conexaoBanco conexao;

    public Text id;

	// Use this for initialization
	void Start () {

        conexao = FindObjectOfType(typeof(conexaoBanco)) as conexaoBanco;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
