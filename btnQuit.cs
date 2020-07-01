using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnQuit : MonoBehaviour {

	public static bool GameIsActive = true;

	public GameObject screenQuit;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (GameIsActive) {

				ScreenQuitOpen ();

			} else {
			
				ScreenQuitClose ();

			}
		}
	}

	void ScreenQuitOpen () {

		screenQuit.SetActive (true);
		//Time.timeScale = 1f;
		GameIsActive = false;

	}

	void ScreenQuitClose () {

		screenQuit.SetActive (false);
		//Time.timeScale = 0f;
		GameIsActive = true;

	}

	public void Exit () {

		screenQuit.SetActive (false);
		GameIsActive = true;

	}

	public void Sim () {

		Application.Quit ();

	}

}
