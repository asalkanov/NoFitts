using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krugClick : MonoBehaviour {

	public GameObject kruzic;
	public GameObject malaKocka;
	public GameObject srednjaKocka;
	public GameObject velikaKocka;
	public GameObject enemy;
	public GameObject hitMe;
	//public GameObject cubeClick;

	public int flag;
	public int scoreClickKrug; // dohvati score u trenutku kad kliknes na kruzic, usporeduje se kada destroyer unisti cube
	public int count;

	public maliCube_Click vezaNaSkriptu;
	public Lerp skripta;
	public canvasClick pozivRaya;
	// Use this for initialization
	void Start () {
		vezaNaSkriptu = malaKocka.GetComponent<maliCube_Click> ();
		pozivRaya = hitMe.GetComponent<canvasClick> ();
		skripta = enemy.GetComponent<Lerp> ();
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
		} else if (skripta.random == 3){
			skripta.pos.x = 297;
			skripta.pos.y = 141;
			skripta.strana = "Desno";
		}

		skripta.maliStart = malaKocka.transform.position;
		skripta.srednjiStart = srednjaKocka.transform.position;
		skripta.velikiStart = velikaKocka.transform.position;

		if (kruzic.activeSelf) {
			skripta.totalObjects++;
			scoreClickKrug = skripta.score;
			kruzic.SetActive (false);

			if (vezaNaSkriptu.srednjaKocka.activeSelf == false && vezaNaSkriptu.velikaKocka.activeSelf == false && flag == 1) {
				vezaNaSkriptu.malaKocka.SetActive (true);
				flag = 2;
			}
			else if (vezaNaSkriptu.malaKocka.activeSelf == false && vezaNaSkriptu.velikaKocka.activeSelf == false && flag == 2) {
				vezaNaSkriptu.srednjaKocka.SetActive (true);
				flag = 3;
			}
			else if (vezaNaSkriptu.malaKocka.activeSelf == false && vezaNaSkriptu.srednjaKocka.activeSelf == false && flag == 3) {
				vezaNaSkriptu.velikaKocka.SetActive (true);
				flag = 1;
			}
		}

	}
}
