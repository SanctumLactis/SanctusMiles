using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmplSubStateDIA : SubStateDIA
{
    // Runs on initialization
    public TmplSubStateDIA(object mainScript, object parentState) : base(mainScript, parentState)
    {

    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter()
    {

    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {

    }

    // Runs at a fixed rate and is framerate independent
    public override void OnFixedUpdate()
    {
        
    }

    // Runs when the state stops
    public override void OnExit()
    {

    }
}