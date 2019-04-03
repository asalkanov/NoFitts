using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krugClickAnova1 : MonoBehaviour {

	public GameObject kruzic;
	public GameObject srednjaKocka;
	public GameObject enemy;
	public GameObject hitMe;
	//public GameObject cubeClick;

	public int flag;
	public int scoreClickKrug; // dohvati score u trenutku kad kliknes na kruzic, usporeduje se kada destroyer unisti cube
	public int count;

	public srednjiCubeClick vezaNaSkriptu;
	public LerpAnova1 skripta;
	public canvasClickAnova1 pozivRaya;
	// Use this for initialization
	void Start () {
		vezaNaSkriptu = srednjaKocka.GetComponent<srednjiCubeClick> ();
		skripta = enemy.GetComponent<LerpAnova1> ();
		pozivRaya = hitMe.GetComponent<canvasClickAnova1> ();
		flag = 1;
		kruzic.SetActive (true);
		count = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnMouseDown(){
		count = 1;
		if (skripta.realTime == 0) {
			Debug.Log ("pozvao sam prvi puta!");
			pozivRaya.CastRayToWorld ();
		}
		skripta.random = Random.Range (1,4);
		skripta.pos = transform.position;
		if (skripta.random == 1) {
			skripta.pos.x = 289;
			skripta.pos.y = 141;
			skripta.strana = "Lijevo";
		} else if (skripta.random == 2) {
			skripta.pos.x = 293;
			skripta.pos.y = 141;
			skripta.strana = "Sredina";
		} else {
			skripta.pos.x = 297;
			skripta.pos.y = 141;
			skripta.strana = "Desno";
		}

		skripta.srednjiStart = srednjaKocka.transform.position;

		if (kruzic.activeSelf) {
			skripta.totalObjects++;
			scoreClickKrug = skripta.score;
			kruzic.SetActive (false);

			vezaNaSkriptu.srednjaKocka.SetActive (true);
			flag = 3;
		}

	}
}
