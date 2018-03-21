using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour {
	public Navigation navigation;
	public GameObject[] planets;
	// Use this for initialization
	void Start () {
		if (!navigation) {
			GetComponent<Navigation> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			navigation.planet = null;
		}
		if (Input.anyKeyDown) {
			string key = Input.inputString;
			int n = 0;
			if(int.TryParse(key,out n)) {
				navigation.planet = planets [n];
			}
		}
	}
}
