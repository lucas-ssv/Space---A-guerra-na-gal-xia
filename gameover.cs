using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {

	public void Quit () {
	
		Debug.Log ("Saiu do aplicativo!");
		Application.LoadLevel ("MenuPrincipal");

	}

	public void Restart () {
	
		Debug.Log ("Recomecar a fase!");
		Application.LoadLevel ("play");
		//SceneManager.LoadScene ("play");
	
	}


	/*public void jogar () {
	
		Application.LoadLevel ("play");

	}*/
}
