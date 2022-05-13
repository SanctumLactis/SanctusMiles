﻿using System;
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
        standingStillSS = new ZISSStandingStill(main, this);
        wanderSS = new ZISSWander(main, this);
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter(dynamic[] args)
    {
        main.stateMachine.SwitchState(wanderSS);
    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {
        foreach (KeyValuePair<GameObject, Collider2D> collision in main.GetCollisions())
        {
            if (collision.Key.name == "View Distance" && collision.Value.gameObject.tag == "Player")
            {
                Debug.Log("Detected Player - Self: " + main.gameObject.name + " | Collider: " + collision.Key.name + " | Other: " + collision.Value.gameObject.name);
                main.stateMachine.SwitchState(main.combatState);
            }
        }
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