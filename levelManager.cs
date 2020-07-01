using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

	public SceneFader fader;

	public int level;

	private string levelString;

	// Use this for initialization
	void Start () {

		if (ButtonSettings.releasedLevelStatic >= level) {
			LevelUnlocked ();
		} else {
			LevelLocked ();
		}

	}

	public void LevelSelect (string _level) {
		levelString = _level;
		fader.FadeTo (levelString);
	
	} 
	
	// Update is called once per frame
	void Update () {
		
	}

	void LevelLocked () {
	
		GetComponent<Button> ().interactable = false;
	
	}

	void LevelUnlocked () {

		GetComponent<Button> ().interactable = true;

	}
}
