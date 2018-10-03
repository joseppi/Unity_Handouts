using UnityEngine;
using System.Collections;

public class KinematicSeek : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 5: Set movement velocity to max speed in the direction of the target
        Vector3 vec_result;
        vec_result.x = move.target.transform.position.x - move.transform.position.x;
        vec_result.y = 0;
        vec_result.z = move.target.transform.position.z - move.transform.position.z;

        move.SetMovementVelocity(vec_result);

        // Remember to enable this component in the inspector
	}
}
