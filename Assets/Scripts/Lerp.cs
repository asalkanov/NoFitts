using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lerp : MonoBehaviour {

	public GameObject malaKocka;
    public GameObject srednjaKocka;
    public GameObject velikaKocka;
	public GameObject krug;

	public Vector3 maliStart;
    public Vector3 maliEnd;
	public Vector3 srednjiStart;
    public Vector3 srednjiEnd;
	public Vector3 velikiStart;
    public Vector3 velikiEnd;
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

	public krugClick vezaSaKrugom;

    // Use this for initialization
    void Start () {
		vezaSaKrugom = krug.GetComponent<krugClick> ();
		realTime = 0;
		prijelaz = 0f;
		distance = 16f;
		time = 10;
		score = 0;
		level = 1;
		igra = false;
		strana = "";
		unistio = "";
        if (nesto == false)
        {
			malaKocka.SetActive(true);
			srednjaKocka.SetActive(false);
			velikaKocka.SetActive(false);
			totalObjects = 0;
		}
		nesto = true;
		random = Random.Range (1,4);
		pos = transform.position;
		if (random == 1) {
			pos.x = 289;
			pos.y = 141;
			malaKocka.transform.position = pos;
			strana = "Lijevo";
		} else if (random == 2) {
			pos.x = 293;
			pos.y = 141;
			malaKocka.transform.position = pos;
			strana = "Sredina";
		} else if(random == 3){
			pos.x = 297;
			pos.y = 141;
			malaKocka.transform.position = pos;
			strana = "Desno";
		}
		maliStart = malaKocka.transform.position;
		srednjiStart = srednjaKocka.transform.position;
		velikiStart = velikaKocka.transform.position;
		if (vezaSaKrugom.kruzic.activeSelf == false) {
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
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
		if (realTime < 30.0) {
			distance = 16f;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 30.0 && realTime < 35.0){
			distance = distance+prijelaz;
			prijelaz = prijelaz + 0.00035f;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 35.0 && realTime < 65.0){
			distance = 32f;
			level = 2;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 65.0 && realTime < 70.0){
			if (nesto == true) {
				prijelaz = 0;
			}
			nesto = false;
			distance = distance+prijelaz;
			prijelaz = prijelaz + 0.00035f;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 70.0 && realTime < 100.0){
			distance = 48f;
			level = 3;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 100.0 && realTime < 105.0){
			if (nesto == false) {
				prijelaz = 0;
			}
			nesto = true;
			distance = distance+prijelaz;
			prijelaz = prijelaz + 0.00035f;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 105.0 && realTime < 135.0){
			distance = 64f;
			level = 4;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 135.0 && realTime < 140.0){
			if (nesto == true) {
				prijelaz = 0;
			}
			nesto = false;
			distance = distance+prijelaz;
			prijelaz = prijelaz + 0.00035f;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 140.0 && realTime < 170.0){
			distance = 80f;
			level = 5;
			maliStart = pos;
			srednjiStart = pos;
			velikiStart = pos;
			maliEnd = malaKocka.transform.position + Vector3.down * distance;
			srednjiEnd = srednjaKocka.transform.position + Vector3.down * distance;
			velikiEnd = velikaKocka.transform.position + Vector3.down * distance;
		}
		else if(realTime >= 170.0){
			PlayerPrefs.SetInt ("rezultat", score);
			SceneManager.LoadScene ("gameOver");
		}

		if (malaKocka.activeSelf == true && srednjaKocka.activeSelf == false && velikaKocka.activeSelf == false) {
			currentTime += Time.deltaTime;
			if (currentTime >= time) {
				currentTime = time;
			}
			float Perc = currentTime / time;
			malaKocka.transform.position = Vector3.Lerp (maliStart, maliEnd, Perc);
        }
        else if (malaKocka.activeSelf == false && srednjaKocka.activeSelf == true && velikaKocka.activeSelf == false)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= time)
            {
                currentTime = time;
            }
            float Perc = currentTime / time;
            srednjaKocka.transform.position = Vector3.Lerp(srednjiStart, srednjiEnd, Perc);
        }
        else if(malaKocka.activeSelf == false && srednjaKocka.activeSelf == false && velikaKocka.activeSelf == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= time)
            {
                currentTime = time;
            }
            float Perc = currentTime / time;
            velikaKocka.transform.position = Vector3.Lerp(velikiStart, velikiEnd, Perc);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		unistio = "Ne";
		if (other.gameObject.name == "maliCube") {
			vezaSaKrugom.kruzic.SetActive (true);
			malaKocka.SetActive (false);
			//srednjaKocka.SetActive (false);
			//srednjaKocka.SetActive (true);
			velikaKocka.SetActive (false);
			score -= 2;
			//malaKocka.transform.position = maliStart;
			currentTime = 0;
		} 
		else if (other.gameObject.name == "srednjiCube") {
			vezaSaKrugom.kruzic.SetActive (true);
			srednjaKocka.SetActive (false);
			malaKocka.SetActive (false);
			//velikaKocka.SetActive (true);
			//velikaKocka.SetActive (false);
			score -= 4;
			currentTime = 0;
		}
		else if(other.gameObject.name == "velikiCube"){
			vezaSaKrugom.kruzic.SetActive (true);
			velikaKocka.SetActive (false);
			srednjaKocka.SetActive (false);
			//malaKocka.SetActive (true);
			//malaKocka.SetActive (false);
			score -= 6;
			currentTime = 0;
		}
	}
}