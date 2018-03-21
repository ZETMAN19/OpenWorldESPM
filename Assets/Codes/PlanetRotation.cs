using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour {
	public double daytime=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.rotation *= Quaternion.Euler (0, (float)(daytime*360)*Time.deltaTime, 0);
	}
}
