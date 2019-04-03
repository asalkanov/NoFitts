using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameScene : MonoBehaviour {

	public Dropdown lista;
	public Toggle input;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void tipPomagala(){
		if (input.isOn) {
			PlayerPrefs.SetString ("tipPomagala", "Mouse");
		} else {
			PlayerPrefs.SetString ("tipPomagala", "Touch");
		}
	}

	public void changeScene(){
		if (lista.value == 0) {
			SceneManager.LoadScene ("Game");
		} else {
			SceneManager.LoadScene ("anova1");
		}
	}


}
