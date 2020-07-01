using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour {

	public static LevelClear levelClear;

	private int faseAtual = 1;

	void Awake () {

		if (levelClear == null) {
			levelClear = this;
		} else if (levelClear != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

	}

	void Update () {

	}

	public void LiberarFase (int faseALiberar) {
	
		if (faseALiberar > faseAtual) {
			faseAtual = faseALiberar;
		}
	
	}

	public int GetFaseAtual () {

		return faseAtual;

	}

}
