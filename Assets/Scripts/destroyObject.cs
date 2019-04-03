using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
	public GameObject maliCube;

	public Vector3 startPoint;
    // Use this for initialization
    void Start()
	{
		//start = maliCube.transform.position;
		startPoint = maliCube.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
    }

	private void OnTriggerEnter(Collider other)
	{	
		if(other.gameObject.name == "maliCube") {
			maliCube.transform.position = startPoint;
		}
	}

}
