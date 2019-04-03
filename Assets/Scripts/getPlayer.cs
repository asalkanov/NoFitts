using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getPlayer : MonoBehaviour {

	public Text ime;
	public string name;

	// Use this for initialization
	void Start () {
		name = PlayerPrefs.GetString("imeIgraca");
		ime.text = name;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
