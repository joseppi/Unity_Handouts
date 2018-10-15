using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTargetPosition : MonoBehaviour {
    Move move;
    NavMeshAgent nav_agent;
	// Use this for initialization
	void Start ()
    {
        move = GetComponent<Move>();
        nav_agent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        nav_agent.destination = move.target.transform.position;
    }
}
