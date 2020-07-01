using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject completeLevelUI;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (GameIsOver) {

			return;

		}

	}

	public void WinLevel () {

		GameIsOver = true;
		completeLevelUI.SetActive (true);
		//Debug.Log ("Win");

	}
}
