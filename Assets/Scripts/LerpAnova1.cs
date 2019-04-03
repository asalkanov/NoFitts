using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LerpAnova1 : MonoBehaviour {

	public GameObject srednjaKocka;
	public GameObject krug;

	public Vector3 srednjiStart;
	public Vector3 srednjiEnd;
	public Vector3 pos;

	public float distance;
	public float time;
	public float realTime;
	public float prijelaz;
	public string unistio;
	public float currentTime = 0;
	public bool nesto = false;
	public bool igra;

	public int score;
	public int level;
	public int totalObjects;
	public int random;
	public string strana;
	public krugClickAnova1 vezaSaKrugom;

	// Use this for initialization
	void Start () {
		vezaSaKrugom = krug.GetComponent<krugClickAnova1> ();
		realTime = 0;
		prijelaz = 0f;
		distance = 48f;
		time = 10;
		score = 0;
		level = 3;
		igra = false;
		strana = "";
		unistio = "";
		totalObjects = 0;
		srednjaKocka.SetActive(true);
		random = Random.Range (1,4);
		pos = transform.position;
		if (random == 1) {
			pos.x = 289;
			pos.y = 141;
			srednjaKocka.transform.position = pos;
			strana = "Lijevo";
		} else if (random == 2) {
			pos.x = 293;
			pos.y = 141;
			srednjaKocka.transform.position = pos;
			strana = "Sredina";
		} else {
			pos.x = 297;
			pos.y = 141;
			srednjaKocka.transform.position = pos;
			strana = "Desno";
		}
		if (vezaSaKrugom.kruzic.activeSelf == false) {
			srednjiStart = srednjaKocka.transform.position;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
		}
	}

	// Update is called once per frame
	void Update () {
		if (vezaSaKrugom.kruzic.activeSelf == false) {
			igra = true;
			Padanje ();
		} else {
			igra = false;
		}
	}

	public void Padanje() {
		realTime += Time.deltaTime;
		if (realTime < 90.0) {
			srednjiStart = pos;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 90.0){
			PlayerPrefs.SetInt ("rezultat", score);
			SceneManager.LoadScene ("gameOver");
		}

		if (srednjaKocka.activeSelf)
		{
			currentTime += Time.deltaTime;
			if (currentTime >= time)
			{
				currentTime = time;
			}
			float Perc = currentTime / time;
			srednjaKocka.transform.position = Vector3.Lerp(srednjiStart, srednjiEnd, Perc);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		unistio = "Ne";
		if (other.gameObject.name == "srednjiCube") {
			vezaSaKrugom.kruzic.SetActive (true);
			srednjaKocka.SetActive (false);
			score -= 4;
			currentTime = 0;
			//srednjaKocka.SetActive (true);
		}
	}
}
