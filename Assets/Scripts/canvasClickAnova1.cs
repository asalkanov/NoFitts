﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class canvasClickAnova1 : MonoBehaviour {

	public GameObject srednjaKocka;
	public GameObject enemy;
	public GameObject startPoint;

	public srednjiCubeClick veza;
	public LerpAnova1 vezaNaLerp;
	public getPlayer vezaZaImena;
	public krugClickAnova1 vezaNaKrug;

	public Text ime;
	public Text pomagalo;
	public string imePomagala;
	public float distance;
	public Camera camera;
	public Ray click;
	public RaycastHit hit;
	public GameObject Sphere;

	public Vector3 srednjaPozicija;
	public Vector3 trenutnaSrednjaPozicija;
	public Vector3 udaljenost;

	public string velicinaObjekta;
	public int noviScore;
	public int score;
	public int type;
	public string zapis;
	public float novaDistanceSrednja;
	public int destroyerScore;

	// da se ne kreiraju instance sfera na pocetku
	public int flag = 0;
	public int flagZapis;
	public int flagDestroyer = 0;
	public int brojObjekata = 0;

	public List<GameObject> gameObjects;

	public void Start(){
		velicinaObjekta = "";
		type = 1;
		veza = srednjaKocka.GetComponent<srednjiCubeClick> ();
		vezaNaLerp = enemy.GetComponent<LerpAnova1> ();
		vezaZaImena = ime.GetComponent<getPlayer> ();
		vezaNaKrug = startPoint.GetComponent<krugClickAnova1> ();
		flagZapis = 0;
		destroyerScore = 0;
		imePomagala = PlayerPrefs.GetString("tipPomagala");
		pomagalo.text = imePomagala;
	}

	public void Update(){
		if (flag != 0) {
			CastRayToWorld ();
		}
		destroyerScore = vezaNaKrug.scoreClickKrug;

	}

	public void CastRayToWorld() {
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		GameObject temp;
		temp = Instantiate (Sphere, hit.point, transform.rotation);
		gameObjects.Add(temp);

		score = vezaNaLerp.score; //score prije klika

		if (Input.GetMouseButtonDown (0)) { 
			flag = 1;
			noviScore = vezaNaLerp.score; //score nakon klika

			if (veza.srednjaKocka.activeSelf) {
				vezaNaLerp.unistio = "Ne";
			}

			Debug.Log ("noviScore klik "+ noviScore + " destroyerScore klik " + destroyerScore + "veza pogodak: " + veza.pogodak);

			temp = Instantiate (Sphere, hit.point, transform.rotation);
			gameObjects.Add (temp);
			if (Physics.Raycast (ray, out hit, 100)) {
				if (veza.srednjaKocka.activeSelf) {
					trenutnaSrednjaPozicija = veza.srednjaKocka.transform.position;
					distance = Vector3.Distance (hit.point, trenutnaSrednjaPozicija);
					//srednjaPozicija = veza.srednjaKocka.transform.position;
					velicinaObjekta = "srednja";
				}
			}

			if (noviScore == destroyerScore && vezaNaLerp.realTime > 0) { //korisnik pogodio corak
				Debug.Log ("promasaj NS " + noviScore + " DS " + destroyerScore);

				if (veza.srednjaKocka.activeSelf) {
					zapisRezultata (type, imePomagala, noviScore, distance, veza.srednjaKocka.transform.position, vezaZaImena.ime, vezaNaLerp.realTime,
						vezaNaLerp.level, velicinaObjekta, hit.point, vezaNaLerp.strana, vezaNaLerp.totalObjects, vezaNaLerp.unistio,
						System.DateTime.Now.ToString());
				}

			}
			else if (noviScore > destroyerScore && veza.pogodak == true)  { //korisnik pogodio cube
				veza.pogodak = false;
				novaDistanceSrednja = Vector3.Distance (hit.point, srednjaKocka.transform.position);
				Debug.Log ("noviScore pogodak "+ noviScore + " destroyerScore " + destroyerScore);
				if ((noviScore - destroyerScore) == 6) {
					zapisRezultata (type, imePomagala, vezaNaLerp.score, novaDistanceSrednja, veza.srednjaKocka.transform.position, vezaZaImena.ime, vezaNaLerp.realTime,
						vezaNaLerp.level, velicinaObjekta, hit.point, vezaNaLerp.strana, vezaNaLerp.totalObjects, vezaNaLerp.unistio,
						System.DateTime.Now.ToString ());
				}
			}
		}


		if (score < destroyerScore && vezaNaLerp.igra == true) { //destroyer unistio cube
			Debug.Log ("score" + score + "destroyer score " + destroyerScore);

			flagDestroyer = 1;
			if ((destroyerScore-score) == 4) {
				zapisRezultata (type, imePomagala, vezaNaLerp.score, 0, veza.srednjaKocka.transform.position, vezaZaImena.ime, vezaNaLerp.realTime,
					vezaNaLerp.level, velicinaObjekta, hit.point = new Vector3(0,0,0), vezaNaLerp.strana, vezaNaLerp.totalObjects, 
					vezaNaLerp.unistio, System.DateTime.Now.ToString());
			}
			flagDestroyer = 0;
		} 

		//Unistavanje sfera
		for(int i = 0; i<gameObjects.Count; i++){
			Destroy(gameObjects[i]);
		}
	} 		


	public void zapisRezultata (int tip, string imePomagala, int score, float distance, Vector3 pozicija, Text name, float vrijeme, int level, string velicina,
		Vector3 udarac, string strana, int ukupanBrojObjekata, string korisnikUnistio, string datum) 
	{
		string filePath = getPath ();

		//This is the writer, it writes to the filepath
		StreamWriter writer = new StreamWriter (filePath, append: true);

		//This is writing the line of the type, name, damage... etc... (I set these)
		if(flagZapis == 0) {
			writer.WriteLine ("TipIgre=Pomagalo=Score=Distance=PozicijaObjekta=Username=VrijemeIgre=Brzina=TipObjekta=PozicijaClicka=StranaPadanjaObjekta=UkupanBrojObjekata=Pogodak=TimeCEST");
		}
		flagZapis = 1;
		writer.WriteLine ("Anova"+tip.ToString () + "=" + imePomagala + "=" + score.ToString () + "=" + distance.ToString () + "=" + pozicija.ToString () + "=" + name.text + "=" + vrijeme.ToString () + "=" + level.ToString ()
			+ "=" + velicina + "=" + udarac + "=" + strana + "=" + ukupanBrojObjekata.ToString() + "=" + korisnikUnistio + "=" + datum);
		writer.Flush ();
		//This closes the file
		writer.Close ();
	}

	private string getPath () {
		/*#if UNITY_EDITOR
		return Application.dataPath + "/CSV/" + "Zapis.csv";
		#elif UNITY_ANDROID
		return Application.dataPath + "/CSV/" + "Zapis.csv";
		#elif UNITY_IPHONE
		rreturn Application.dataPath + "/CSV/" + "Zapis.csv";
		#else
		return Application.dataPath + "/CSV/" + "Zapis.csv";
		#endif*/
		return Application.dataPath + "/CSV/" + "Zapis.csv";
	}    

}