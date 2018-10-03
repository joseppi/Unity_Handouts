using UnityEngine;
using System.Collections;

public class KinematicFlee : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 6: To create flee just switch the direction to go
        Vector3 vec_result;
        vec_result.x = move.transform.position.x - move.target.transform.position.x;
        vec_result.y = 0;
        vec_result.z = move.transform.position.z - move.target.transform.position.z;

        move.SetMovementVelocity(vec_result);
    }
}
