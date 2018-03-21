using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhaPara : MonoBehaviour {
    GameObject alvo;
    public bool invert = false;
	// Use this for initialization
	void Start () {
        alvo = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (invert)
        {
            Vector3 dir = alvo.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        else
        {
            Vector3 dir = transform.position - alvo.transform.position ;
            transform.rotation = Quaternion.LookRotation(dir);
        }
	}
}
