using UnityEngine;
using System.Collections;
using System;

public class StateOne : AbstractState {


    //how should your state become Avtive?
    public override void Active()
    {
       
    }

    //how should your state become InActive?
    public override void InActive()
    {
       
    }

    // Update is called once per frame the same as a typical script
    public override void Update()
    {
        Debug.Log("Hello From State One!");
    }

    
}
