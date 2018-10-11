using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

[RequireComponent(typeof(BGCcMath))]

public class FollowCurve : CoordinatingBehaveour
{
    float currentRatio = 0.0f;
    public BGCcMath curve_math;
    public GameObject target;
    public GameObject tank_green;
    Move move;

    private float distance;

    // Use this for initialization
    void Start ()
    {
        move = GetComponent<Move>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // TODO 1: Have a GameObject that follows the curve's path
        // Increase the ratio [0 to 1] and set the GameObject position to the respecive point in the curve

        transform.position = curve_math.CalcPositionByDistanceRatio(currentRatio);
        currentRatio = currentRatio + 0.01f;
        if (currentRatio >= 1)
        {
            currentRatio = 0;
        }
    }
}
