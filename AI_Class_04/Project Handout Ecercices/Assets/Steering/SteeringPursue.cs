using UnityEngine;
using System.Collections;

public class SteeringPursue : MonoBehaviour {

	public float max_seconds_prediction;

	Move move;
    SteeringSeek seek;
    SteeringArrive arrive;
    Vector3 enemy_position;

    // Use this for initialization
    void Start () {
		move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        arrive = GetComponent<SteeringArrive>();
        enemy_position = new Vector3(3.0f, 0.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () 
	{
		Steer(enemy_position, move.target.GetComponent<Move>().movement);

	}

	public void Steer(Vector3 target, Vector3 velocity)
	{
        // TODO 5: Create a fake position to represent
        // enemies predicted movement. Then call Steer()
        // on our Steering Seek / Arrive with the predicted position in
        // max_seconds_prediction time
        // Be sure that arrive / seek's update is not called at the same time

        seek.Steer(target);

        


        // TODO 6: Improve the prediction based on the distance from
        // our target and the speed we have

    }
}
