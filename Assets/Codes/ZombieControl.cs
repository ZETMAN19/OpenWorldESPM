using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : MonoBehaviour {
    Animator anim;
    CharacterController charctrl;
    Rigidbody[] rdbs;
    public GameObject brain;
    public GameObject waypoints;
    Transform[] ways;
    int wayindex = 1;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        charctrl = GetComponent<CharacterController>();
        rdbs = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rdb in rdbs)
        {
            rdb.isKinematic = true;
        }
        ways = waypoints.GetComponentsInChildren<Transform>();
    }
	
	
	void FixedUpdate () {
        if (charctrl.enabled)
        {
            Berserk();
            Attack();
            Patrol();
        }

    }
    void Patrol()
    {
        if (!brain)
        {
            transform.LookAt(ways[wayindex]);
            charctrl.SimpleMove(transform.forward);
            if(Vector3.Distance(transform.position, ways[wayindex].position) < 1)
            {
                wayindex++;
                if (wayindex >= ways.Length) wayindex = 1;
            }
        }
    }
    void Attack()
    {
        //porrada aqui
    }
    void Berserk()
    {
        if (brain)
        {
            transform.LookAt(brain.transform);
            charctrl.SimpleMove(transform.forward);
        }
    }

    public void KillMe()
    {
        anim.enabled = false;
        charctrl.enabled = false;
        foreach (Rigidbody rdb in rdbs)
        {
            rdb.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            brain = other.gameObject;
        }
    }
}
