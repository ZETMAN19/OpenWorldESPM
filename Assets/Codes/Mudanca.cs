using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudanca : MonoBehaviour {
    public Navigation navigation;
    public GameObject[] planets;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            navigation.planet = planets[0];
        }
	}
}
