using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getResult : MonoBehaviour {

	public Text rezultat;
	public Lerp script;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		script = enemy.GetComponent<Lerp> ();
	}
	
	// Update is called once per frame
	void Update () {
		rezultat.text = script.score.ToString();
	}
}
