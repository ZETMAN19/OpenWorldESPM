using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {
	public GameObject planet;
	Vector3 startpos;
	Quaternion startrot;
	// Use this for initialization
	void Start () {
		startpos = transform.position;
		startrot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (planet) {

            

            Vector3 dirl = planet.transform.position - transform.position;
            transform.forward = dirl;

            Vector3 dir = (planet.transform.position+
                Vector3.up * planet.transform.localScale.magnitude + 
                planet.transform.position.normalized * planet.transform.localScale.magnitude*-3)
                - transform.position;

            transform.position += dir * Time.unscaledDeltaTime;

           

			
		} else {
			Vector3 dir = startpos - transform.position;
			transform.position += dir * Time.unscaledDeltaTime;
			transform.rotation = startrot;
		}
	
	}
}
