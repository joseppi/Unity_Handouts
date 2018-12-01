using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GOAPActionTemplate : Action {

    public GOAPActionTemplate() { }


    public override void OnActionSetup(IGoap iGoap, List<Condition> state) { }

    public override void OnActionStart() { }

    public override void OnActionPerform() { }

    public override void OnActionFinished() {  }

    public override void OnActionAborted() { }
}
