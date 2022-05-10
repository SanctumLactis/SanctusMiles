using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberIdleState : StateDIA
{
    // Sub States
    [SerializeField] public ZISSStandingStill standingStillSS;
    [SerializeField] public ZISSWander wanderSS;


    // Runs on initialization
    public ZomberIdleState(object mainScript) : base(mainScript)
    {

    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter(dynamic[] args)
    {
        standingStillSS = new ZISSStandingStill(main, this);
        wanderSS = new ZISSWander(main, this);

        main.stateMachine.SwitchState(wanderSS);
    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {
        //TODO: Add check for if the Zomber can see the player
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