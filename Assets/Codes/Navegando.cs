using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navegando : MonoBehaviour {
    public GameObject planeta;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (planeta)
        {
            Vector3 dir = planeta.transform.position - transform.position;
            transform.position += dir * Time.unscaledDeltaTime;
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(dir),
                Time.unscaledDeltaTime);
        }
        else
        {


        }
    }
}
