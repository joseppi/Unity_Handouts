using UnityEngine;
using System.Collections;

public class SteeringSeek : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start ()
    {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
        // TODO 1: accelerate towards our target at max_acceleration
        // use move.AccelerateMovement()
        Vector3 aux_acc;
        aux_acc.x = target.x - move.transform.position.x;
        aux_acc.y = 0.0f;
        aux_acc.z = target.z - move.transform.position.z;
        move.AccelerateMovement(aux_acc);
    }
}
