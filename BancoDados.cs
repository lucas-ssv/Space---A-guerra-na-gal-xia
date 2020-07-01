using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoDados : MonoBehaviour {

	public string[] nomes; // vai armazenar os nomes do banco de dados
	public List<string> nome, pontuacao;

	IEnumerator Start () {
	
		WWW itemData = new WWW ("http://localhost:90/space/nomes.php");
		yield return itemData;
		string itemDataString = itemData.text;
		//print (itemDataString);
		nomes = itemDataString.Split(';');

		for (int i = 0; i < nomes.Length - 1; i++) {
		
			nome.Add (GetDataValue (nomes [i], "NOME:"));
			pontuacao.Add (GetDataValue (nomes [i], "PONTUACAO:"));
		
		}
		
	} 

	private string GetDataValue (string data, string index) {
	
		string value = data.Substring (data.LastIndexOf (index) + index.Length);
		if (value.Contains ("|")) {
			value = value.Remove (value.IndexOf ("|"));
		}
		return value;
	
	}

}
