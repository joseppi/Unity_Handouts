using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GOAPGoalTemplate : Goal {

    public GOAPGoalTemplate() { }


    public override void OnGoalInitialize(IGoap igoap) { this.igoap = igoap; }

    public override void OnGoalSetup()
    {
        base.OnGoalSetup();
    }

    public override void OnGoalFinished()
    {
        base.OnGoalFinished();
    }

    public override void OnGoalAborted()
    {
        base.OnGoalAborted();
    }

    public override bool IsGoalRelevant()
    {
        throw new System.NotImplementedException();
    }
}
