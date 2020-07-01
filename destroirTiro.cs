using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroirTiro : MonoBehaviour {

	void OnBecameInvisible () {

		Destroy (this.gameObject);

	}
}
