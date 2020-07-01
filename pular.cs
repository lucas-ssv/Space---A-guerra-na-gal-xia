using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pular : MonoBehaviour {

	public string load;

	public void Pular () {

		SceneManager.LoadScene (load);

	}

}
