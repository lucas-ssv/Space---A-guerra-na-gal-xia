using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour {

	public string menuSceneName = "MenuPrincipal";

	public static int releasedLevelStatic = 1;
	public int releasedLevel;
	public string nextLevel;

	public SceneFader sceneFader;

	void Awake () {

		if (PlayerPrefs.HasKey ("Level")) {
			releasedLevelStatic = PlayerPrefs.GetInt ("Level", releasedLevelStatic);
		}

	}

	public void ButtonNextLevel () {
		sceneFader.FadeTo (nextLevel);
		if (releasedLevelStatic <= releasedLevel) {
			releasedLevelStatic = releasedLevel;
			PlayerPrefs.SetInt ("Level", releasedLevelStatic);
		}

	}

	public void Menu () {

		sceneFader.FadeTo (menuSceneName);

	}

}
