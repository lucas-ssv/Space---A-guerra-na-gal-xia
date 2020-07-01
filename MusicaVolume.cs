using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicaVolume : MonoBehaviour {

	public Slider Volume;
	public AudioSource Musica;

	void Start () {
	
		Volume.value = PlayerPrefs.GetFloat ("volume");

	}
	
	// Update is called once per frame
	public void Update () {

		Musica.volume = Volume.value;
		AudioListener.volume = Volume.value;
		
	}

	public void Salvar () {
	
		PlayerPrefs.SetFloat ("volume", Volume.value);
		//Debug.Log ("Opcoes salvas!");
	
	}
}
