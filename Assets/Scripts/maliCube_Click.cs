using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class maliCube_Click : MonoBehaviour {

	public GameObject malaKocka;
	public GameObject srednjaKocka;
	public GameObject velikaKocka;
	public GameObject enemy;
	public GameObject startPoint;
	public GameObject keanvas;
	public Camera camera;
	public List<GameObject> gameObjects;


	public Lerp skriptica;
	public krugClick start;
	public canvasClick keavnasKlik;
	public RaycastHit hit2;
	public RaycastHit hit3;

	public bool pogodak = false;
	public float novaDistanceSrednja;
	public float novaDistanceVelika;

	// Use this for initialization
	void Start () {
		skriptica = enemy.GetComponent<Lerp>();
		start = startPoint.GetComponent<krugClick>();
		keavnasKlik = keanvas.GetComponent<canvasClick>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnMouseDown() {
		
	    skriptica.unistio = "Da";
		pogodak = true;
			
		Debug.Log ("tu: "+ keavnasKlik.noviScore + " sam: " + keavnasKlik.destroyerScore);
		if ((keavnasKlik.noviScore-keavnasKlik.destroyerScore) == 9) {
			Debug.Log ("tu nikad ni ne udem, ulazim u canvasClick za mali cube!");
			keavnasKlik.zapisRezultata (keavnasKlik.type, keavnasKlik.imePomagala, keavnasKlik.noviScore, novaDistanceSrednja, keavnasKlik.veza.malaKocka.transform.position, keavnasKlik.vezaZaImena.ime, keavnasKlik.vezaNaLerp.realTime,
				keavnasKlik.vezaNaLerp.level, keavnasKlik.velicinaObjekta, keavnasKlik.hit.point, keavnasKlik.vezaNaLerp.strana, keavnasKlik.vezaNaLerp.totalObjects, keavnasKlik.vezaNaLerp.unistio, 
				System.DateTime.Now.ToString());
		} else if ((keavnasKlik.noviScore-keavnasKlik.destroyerScore) == 6) {
			
			novaDistanceSrednja = Vector3.Distance (keavnasKlik.hit.point, velikaKocka.transform.position);
			Debug.Log ("ni tu ne bi trebao uc: " + novaDistanceSrednja);
			keavnasKlik.zapisRezultata (keavnasKlik.type, keavnasKlik.imePomagala, keavnasKlik.noviScore, novaDistanceSrednja, keavnasKlik.veza.srednjaKocka.transform.position, keavnasKlik.vezaZaImena.ime, keavnasKlik.vezaNaLerp.realTime,
				keavnasKlik.vezaNaLerp.level, keavnasKlik.velicinaObjekta, keavnasKlik.hit.point, keavnasKlik.vezaNaLerp.strana, keavnasKlik.vezaNaLerp.totalObjects, keavnasKlik.vezaNaLerp.unistio,
				System.DateTime.Now.ToString());
		} else if ((keavnasKlik.noviScore-keavnasKlik.destroyerScore) == 3) {
			novaDistanceVelika = Vector3.Distance (keavnasKlik.hit.point, velikaKocka.transform.position);
			keavnasKlik.zapisRezultata (keavnasKlik.type, keavnasKlik.imePomagala, keavnasKlik.noviScore, novaDistanceVelika, keavnasKlik.veza.velikaKocka.transform.position, keavnasKlik.vezaZaImena.ime, keavnasKlik.vezaNaLerp.realTime,
				keavnasKlik.vezaNaLerp.level, keavnasKlik.velicinaObjekta, keavnasKlik.hit.point, keavnasKlik.vezaNaLerp.strana, keavnasKlik.vezaNaLerp.totalObjects, keavnasKlik.vezaNaLerp.unistio,
				System.DateTime.Now.ToString());
		}

		if (malaKocka.activeSelf) {

			pogodak = true;
			malaKocka.SetActive (false);
			//srednjaKocka.SetActive (true);
			velikaKocka.SetActive (false);
			skriptica.score += 9;
			skriptica.currentTime = 0;
			//skriptica.totalObjects++;
			start.kruzic.SetActive (true);
		}
		else if(srednjaKocka.activeSelf)
		{
			pogodak = true;
			malaKocka.SetActive(false);
			srednjaKocka.SetActive(false);
			//velikaKocka.SetActive(true);
			skriptica.score += 6;
			skriptica.currentTime = 0;
			//skriptica.totalObjects++;
			start.kruzic.SetActive (true);
		
			Ray ray2 = camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray2, out hit2, 100)) {
				novaDistanceSrednja = Vector3.Distance (srednjaKocka.transform.position, hit2.point);
				Debug.Log ("u srednjoj distance: " + novaDistanceSrednja);
			}

			keavnasKlik.zapisRezultata (keavnasKlik.type, keavnasKlik.imePomagala, skriptica.score, novaDistanceSrednja, srednjaKocka.transform.position, keavnasKlik.vezaZaImena.ime, keavnasKlik.vezaNaLerp.realTime,
					keavnasKlik.vezaNaLerp.level, keavnasKlik.velicinaObjekta, hit2.point, keavnasKlik.vezaNaLerp.strana, keavnasKlik.vezaNaLerp.totalObjects, keavnasKlik.vezaNaLerp.unistio,
					System.DateTime.Now.ToString ());
			Debug.Log ("Zapisao sam da si pogodio SREDNJU");


		}
		else if(velikaKocka.activeSelf)
		{
			
			pogodak = true;
			//malaKocka.SetActive(true);
			srednjaKocka.SetActive(false);
			velikaKocka.SetActive(false);
			skriptica.score += 3;
			skriptica.currentTime = 0;
			//skriptica.totalObjects++;
			start.kruzic.SetActive (true);

			Ray ray3 = camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray3, out hit3, 100)) {
				novaDistanceVelika = Vector3.Distance (velikaKocka.transform.position, hit3.point);
				Debug.Log ("u velikoj distance: " + novaDistanceVelika);
			}

			keavnasKlik.zapisRezultata (keavnasKlik.type, keavnasKlik.imePomagala, skriptica.score, novaDistanceVelika, velikaKocka.transform.position, keavnasKlik.vezaZaImena.ime, keavnasKlik.vezaNaLerp.realTime,
				keavnasKlik.vezaNaLerp.level, keavnasKlik.velicinaObjekta, hit3.point, keavnasKlik.vezaNaLerp.strana, keavnasKlik.vezaNaLerp.totalObjects, keavnasKlik.vezaNaLerp.unistio,
				System.DateTime.Now.ToString());

			Debug.Log ("Zapisao sam da si pogodio VELIKU");

		}
	}

}
