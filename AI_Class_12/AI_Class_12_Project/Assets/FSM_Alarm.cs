﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class FSM_Alarm : MonoBehaviour {
    private bool player_detected = false;
    private bool in_alarm = false;
    private Vector3 patrol_pos;
    private NavMeshAgent navMeshAgent;

    public GameObject alarm;
    public BansheeGz.BGSpline.Curve.BGCurve path;
    IEnumerator enumerator;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == alarm)
            in_alarm = true;
    }

    // Update is called once per frame
    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            player_detected = true;
        }
    }

    // TODO 1: Create a coroutine that executes 20 times per second
    // and goes forever. Make sure to trigger it from Start()

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine("Patrol");
        
    }
    IEnumerator Patrol()
    {

        Debug.Log("Patrol");
        while(player_detected == false && in_alarm == false && path.gameObject.activeSelf == true)
        {
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine("GotoAlarm");
        patrol_pos = transform.position;


    }
    IEnumerator GotoAlarm()
    {
        Debug.Log("GotoAlarm");
        while (in_alarm == false)
        {
            yield return new WaitForSeconds(0.05f);
            navMeshAgent.destination = alarm.transform.position;
            path.gameObject.SetActive(false);
        }

        if (in_alarm == true)
        {
            StartCoroutine("GotoPatrol");
        }
            
    }
    IEnumerator GotoPatrol()
    {
        Debug.Log("GotoPatrol");
        while (navMeshAgent.remainingDistance > 0.1f)
        {
            navMeshAgent.destination = patrol_pos;
            yield return new WaitForSeconds(0.05f);
            if (navMeshAgent.remainingDistance < 0.1f)
            {
                player_detected = false;
                in_alarm = false;
                path.gameObject.SetActive(true);

                StartCoroutine("Patrol");
            }
        }
    }
    // TODO 2: If player is spotted, jump to another coroutine that should
    // execute 20 times per second waiting for the player to reach the alarm



    // TODO 3: Create the last coroutine to have the tank waiting to reach
    // the point where he left the path, and trigger again the patrol



}