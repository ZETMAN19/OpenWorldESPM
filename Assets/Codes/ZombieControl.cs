using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieControl : MonoBehaviour {
    Animator anim;
    Rigidbody[] rdbs;
    public GameObject brain;
    public GameObject waypoints;
    Transform[] ways;
    int wayindex = 1;
    NavMeshAgent agent;
    public enum Zstate {Patrol,Berserk,Attack,Dead};
    public Zstate zstate;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rdbs = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rdb in rdbs)
        {
            rdb.isKinematic = true;
        }
        ways = waypoints.GetComponentsInChildren<Transform>();

        wayindex = Random.Range(1, ways.Length);
        agent.SetDestination(ways[wayindex].position);

    }


    void FixedUpdate() {
        switch (zstate) {
            case (Zstate.Patrol):
                Patrol();
                break;
            case (Zstate.Berserk):
                Berserk();
                break;
            case (Zstate.Attack):
                Attack();
                break;
            case (Zstate.Dead):
               
                break;

        }
    }
    void Patrol()
    {
            Vector3 dir = ways[wayindex].position - transform.position;
            if(dir.magnitude < 3)
            {
                wayindex = Random.Range(1, ways.Length);
                agent.SetDestination(ways[wayindex].position);
            }
    }
    void Attack()
    {
        Vector3 dir = brain.transform.position - transform.position;
        if (dir.magnitude > 2)
        {
            zstate = Zstate.Berserk;
        }
    }
    void Berserk()
    {
        if (brain)
        {
            agent.SetDestination(brain.transform.position);
            Vector3 dir = brain.transform.position - transform.position;
            if (dir.magnitude < 2)
            {
                zstate = Zstate.Attack;
            }
        }
    }

    public void KillMe()
    {
        anim.enabled = false;
        zstate = Zstate.Dead;
        agent.enabled = false;
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
            zstate = Zstate.Berserk;
        }
    }
}
