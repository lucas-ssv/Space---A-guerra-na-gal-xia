using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class virtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public GameObject ObjetoDestino;
	public string comando;
	public Sprite[] imagensBtn;
	private Image botao;

	// Use this for initialization
	void Start () {

		botao = GetComponent<Image> ();
		
	}

	public void OnPointerDown (PointerEventData ped) {
	
		ObjetoDestino.SendMessage (comando, SendMessageOptions.DontRequireReceiver);

		botao.sprite = imagensBtn [0];
	
	}

	public void OnPointerUp(PointerEventData ped) {
	
		botao.sprite = imagensBtn [1];
	
	}
}
