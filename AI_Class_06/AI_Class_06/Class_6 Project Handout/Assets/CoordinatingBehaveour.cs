using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatingBehaveour : MonoBehaviour {

    // Use this for initialization
    [Range(1.0f, 5.0f)]
    public int priority;
    public Vector3[] movement_velocity_list = new Vector3[5];





    void Start()
    {
        Vector3[] movement_velocity_list = new Vector3[5];
        movement_velocity_list[0] = new Vector3(1.0f, 0.0f, 0.0f);


    }

	
	// Update is called once per frame
	void Update () {


        /*
        for (int i = 0;i< movement_velocity_list.Length;i++)
        {
            movement_velocity_list[i] = Vector3.zero;
        }
        */
    }
}
