using UnityEngine;
using System.Collections;

public class SteeringSeparation : MonoBehaviour {

	public LayerMask mask;
	public float search_radius = 5.0f;
	public AnimationCurve falloff;
    private Collider[] col_list;


    Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

    // Update is called once per frame
    void Update()
    {
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration
        col_list = Physics.OverlapSphere(move.transform.position, search_radius,mask);
        for (int i = 0;i <= col_list.Length; i++)
        {
            Vector3 repulsion_vec = Vector3.zero;
            repulsion_vec.x = move.transform.position.x - col_list[i].transform.position.x;
            repulsion_vec.y = 0.0f;
            repulsion_vec.z = move.transform.position.z - col_list[i].transform.position.z;
            repulsion_vec.Normalize();

            Vector3 distance_vec = Vector3.zero;
            distance_vec.x = move.transform.position.x - col_list[i].transform.position.x;
            distance_vec.y = 0.0f;
            distance_vec.z = move.transform.position.z - col_list[i].transform.position.z;

            float transform_distance = move.max_mov_velocity / distance_vec.magnitude;

            float speed = falloff.Evaluate(transform_distance);
            float final_speed = move.max_mov_velocity * speed;
            repulsion_vec = repulsion_vec * final_speed;
            move.SetMovementVelocity(repulsion_vec);
        }

        
    }


	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
