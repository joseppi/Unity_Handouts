using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_target = 0.1f;

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
		if(!move)
			move = GetComponent<Move>();

        // TODO 3: Find the acceleration to achieve the desired velocity
        // If we are close enough to the target just stop moving and do nothing else
        // Calculate the desired acceleration using the velocity we want to achieve and the one we already have
        // Use time_to_target as the time to transition from the current velocity to the desired velocity
        // Clamp the desired acceleration and call move.AccelerateMovement()
        Vector3 distance = new Vector3(move.transform.position.x - target.x, 0, move.transform.position.z - target.z);
        Vector3 desire_vel = new Vector3(move.transform.position.x - target.x, 0, move.transform.position.z - target.z);
        desire_vel.Normalize();
        desire_vel = desire_vel * move.max_mov_velocity;
        if (distance.x < slow_distance && distance.z < slow_distance)
        {
            if (distance.x <= min_distance && distance.z <= min_distance)
            {
                move.SetMovementVelocity(Vector3.zero);
            }
            else
            {
                Vector3 resulting_acc;
                resulting_acc.x = move.movement.x - desire_vel.x / time_to_target;
                resulting_acc.y = 0.0f;
                resulting_acc.z = move.movement.z - desire_vel.z / time_to_target;
                move.AccelerateMovement(resulting_acc);
            }
        }


        //TODO 4: Add a slow factor to reach the target
        // Start slowing down when we get closer to the target
        // Calculate a slow factor (0 to 1 multiplier to desired velocity)
        // Once inside the slow radius, the further we are from it, the slower we go
        if (distance.x < slow_distance && distance.z < slow_distance)
        {
            move.movement.x = move.movement.x * 0.5f;
            move.movement.z = move.movement.z * 0.5f;
        }

    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
