using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getResultAnova1 : MonoBehaviour {

	public Text rezultat;
	public LerpAnova1 script;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		script = enemy.GetComponent<LerpAnova1> ();
	}

	// Update is called once per frame
	void Update () {
		rezultat.text = script.score.ToString();
	}
}
