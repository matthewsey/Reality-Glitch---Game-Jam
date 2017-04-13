using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		((MovieTexture)GetComponent<RawImage> ().mainTexture).Play ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
