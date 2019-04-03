using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class configuration : MonoBehaviour {

	public InputField inputfield;
	//public string ime;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		getIme ();
	}
	public void getIme(){
		PlayerPrefs.SetString ("imeIgraca", inputfield.text);
	}
		
}
