using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SteeringSeek : CoordinatingBehaveour
{

	Move move;
    private NavMeshPath path;
    private float elapsed = 0.0f;
	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
        path = new NavMeshPath();
        elapsed = 0.0f;
    }
	
	// Update is called once per frame
	void Update () 
	{
        elapsed += Time.deltaTime;

        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, move.target.transform.position, NavMesh.AllAreas, path);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            Steer(path.corners[i]);
        }           
    }

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

		Vector3 diff = target - transform.position;
		diff.Normalize ();
		diff *= move.max_mov_acceleration;

		move.AccelerateMovement(diff);
	}
}
