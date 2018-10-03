using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;

	Move move;
    int count = 0;
    float rand_x;
    float rand_z;

    // Use this for initialization
    void Start () {
		move = GetComponent<Move>();
        rand_x = RandomBinominal();
        rand_z = RandomBinominal();

    }

	// number [-1,1] values around 0 more likely
	float RandomBinominal()
	{
		return Random.value * Random.value;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor
        Vector3 rand_vec = Vector3.zero;
        int frames = Time.frameCount;
        float rand_rad;

        rand_rad = Mathf.Atan2(rand_x, rand_z);
        rand_rad = rand_rad * Mathf.Rad2Deg;
        if (count > 75)
        {
            if (Random.Range(0.0f, 1.0f) < 0.5f)
                rand_x = -5.0f;
            else
                rand_x = 5.0f;

            if (Random.Range(0.0f, 1.0f) < 0.5f)
                rand_z = -5.0f;
            else
                rand_z = +5.0f;

            count = 0;
        }
        else
        {
            count++;
        }

        float rad = Mathf.Atan2(move.mov_velocity.x, move.mov_velocity.z);
        rad *= Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.RotateTowards(Quaternion.AngleAxis(rad, Vector3.up), Quaternion.AngleAxis(rand_rad, Vector3.up), max_angle); 

        move.mov_velocity.Set(rand_x, 0,rand_z);
	}
}
