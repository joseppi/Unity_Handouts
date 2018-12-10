using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    private Animation anim;
    private float mov_speed;
    private Rigidbody rigidbody;
    private float jump_heigh;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animation>();
        rigidbody = GetComponent<Rigidbody>();

        mov_speed = 1;
        jump_heigh = 250;


    }
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.zero;

        if (!Input.anyKey && !anim.IsPlaying("Jump"))
        {
            anim.Play("Idle");
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.CrossFade("Run", 0.35f);
            dir.Set(0, 0, 1);
            dir *= mov_speed;
            transform.position += dir * Time.deltaTime;


        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.CrossFade("WalkBack", 0.35f);
            dir.Set(0, 0, -1);
            dir *= mov_speed;
            transform.position += dir * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.CrossFade("Jump", 0.35f);
            dir.Set(0, 1, 0);
            dir *= jump_heigh;
            rigidbody.AddForce(dir);

        }
        


        


        anim["Run"].speed = mov_speed * 0.8f;
        anim["Jump"].speed = jump_heigh * 0.0070f;
    }
}
