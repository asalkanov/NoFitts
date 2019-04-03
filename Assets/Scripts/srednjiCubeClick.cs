using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class srednjiCubeClick : MonoBehaviour {

	public GameObject srednjaKocka;
	public GameObject enemy;
	public GameObject startPoint;
	public GameObject keanvas;
	public Camera camera;
	public List<GameObject> gameObjects;

	public krugClickAnova1 start;
	public LerpAnova1 skriptica;
	public canvasClickAnova1 keavnasKlik;
	public RaycastHit hit2;

	public bool pogodak = false;
	public float novaDistanceSrednja;

	// Use this for initialization
	void Start () {
		skriptica = enemy.GetComponent<LerpAnova1>();
		start = startPoint.GetComponent<krugClickAnova1>();
		keavnasKlik = keanvas.GetComponent<canvasClickAnova1>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnMouseDown(){
		skriptica.unistio = "Da";
		pogodak = true;

		if(srednjaKocka.activeSelf){
			pogodak = true;
			srednjaKocka.SetActive(false);
			skriptica.score += 6;
			skriptica.currentTime = 0;
			start.kruzic.SetActive (true);
			//srednjaKocka.SetActive (true);
		}
	}
}
