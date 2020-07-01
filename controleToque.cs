using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleToque : MonoBehaviour {

	private Camera camera;

	// Use this for initialization
	void Start () {

		camera = GetComponent<Camera> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
		
			foreach (Touch toque in Input.touches) {
			
				Ray ray = camera.ScreenPointToRay (toque.position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
				
					GameObject objetoTocado = hit.transform.gameObject;

					switch (toque.phase) {

					case TouchPhase.Began:

						objetoTocado.SendMessage ("aoTocar", SendMessageOptions.DontRequireReceiver);

						break;

					case TouchPhase.Ended:

						objetoTocado.SendMessage ("aoTirar", SendMessageOptions.DontRequireReceiver);

						break;

					}
				
				}
			
			}
		
		}
		
	}
}
