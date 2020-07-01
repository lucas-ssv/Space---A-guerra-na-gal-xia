using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	private MusicaVolume musica;

	public static bool MusicIsPlay = true;

	public static bool GameIsPaused = false;

	public string restart;

	public GameObject pauseMenuUI;

	void Start () {

		musica = FindObjectOfType (typeof(MusicaVolume)) as MusicaVolume;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
		
			if (GameIsPaused) {
			
				Resume ();

			} else {
			
				Pause ();
			
			}
		
		}
		
	}

	public void Resume () {

		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	public void Pause () {

		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;

	}

	public void LoadMenu () {
		
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MenuPrincipal");

	} 

	public void Restart () {

		Time.timeScale = 1f;
		SceneManager.LoadScene (restart);

	}

	public void Musica () {
	
		if (MusicIsPlay) {
			Desligar ();
		} else {
			Ligar ();
		}
	
	}

	void Desligar () {

		AudioListener.pause = true;
		MusicIsPlay = false;

	}

	void Ligar () {

		AudioListener.pause = false;
		MusicIsPlay = true;

	}

	public void QuitGame () {

		SceneManager.LoadScene ("MenuPrincipal");

	}
}
