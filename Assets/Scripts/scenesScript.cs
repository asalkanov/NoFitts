using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void startGame(){
		SceneManager.LoadScene ("PreGame");
	}

	public void homeGame(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void backHome(){
		SceneManager.LoadScene ("MainMenu");
	}
}
