using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverResult : MonoBehaviour {

	public Text rez;
	// Use this for initialization
	void Start () {
		getRezultat ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void getRezultat(){
		rez.text = PlayerPrefs.GetInt("rezultat").ToString();
	}
}
