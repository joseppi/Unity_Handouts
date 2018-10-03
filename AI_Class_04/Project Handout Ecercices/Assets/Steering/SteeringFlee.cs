﻿using UnityEngine;
using System.Collections;

public class SteeringFlee : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
        // TODO 2: Same as Steering seek but opposite direction
        Vector3 aux_acc;
        aux_acc.x = move.transform.position.x - target.x;
        aux_acc.y = 0.0f;
        aux_acc.z = move.transform.position.z - target.z;
        aux_acc.Normalize();
        aux_acc = aux_acc * move.max_mov_velocity; 
        move.AccelerateMovement(aux_acc);
    }
}
