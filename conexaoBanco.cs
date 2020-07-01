using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using MySql.Data.MySqlClient;

public class conexaoBanco : MonoBehaviour
{

    private string source;
    private MySqlConnection conexao;

	public Text id;
	public Text nome;
	public Text pontuacao;

	public Text msg;

    // Use this for initialization
	void Start () {

        source = "Server=191.252.185.199;" +
                 "Database=unitysql;" +
                 "User ID=lucas;" +
                 "Pooling=false;" +
                 "Password=lucas020799";

        ConectarBanco(source);
        Listar(conexao);

    }

    void ConectarBanco(string _source)
    {

        conexao = new MySqlConnection(_source);
        conexao.Open();

    }

    void Listar(MySqlConnection _conexao)
    {

        MySqlCommand comando = _conexao.CreateCommand();
        comando.CommandText = "Select * from ranking order by Pontuacao desc";
        MySqlDataReader dados = comando.ExecuteReader();

        while (dados.Read())
        {
            id.text = (string)dados["ID"].ToString();
			nome.text = (string)dados["Nome"].ToString();
			pontuacao.text = (string)dados["Pontuacao"].ToString();

            Debug.Log("Id: " + id);
            Debug.Log("Nome: " + nome);
            Debug.Log("Pontuação: " + pontuacao);
        }

    }

}
