using System.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCSSMoveToTarget : SubStateDIA
{
    float chaseSpeed = 900f;

    // Runs on initialization
    public ZCSSMoveToTarget(object mainScript, object parentState) : base(mainScript, parentState)
    {
        chaseSpeed = main.chaseSpeed;
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter()
    {

    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {
        CheckAttackPossible();

        main.controller.MoveTowardsPosition(parentState.GetClosestVisiblePlayer(), chaseSpeed);
    }

    // Runs at a fixed rate and is framerate independent
    public override void OnFixedUpdate()
    {
        
    }

    // Runs when the state stops
    public override void OnExit()
    {

    }

    private void CheckAttackPossible()
    {
        foreach (KeyValuePair<GameObject, Collider2D> collision in main.GetCollisions())
        {
            if (collision.Key.name == "Attack Distance" && collision.Value.gameObject.tag == "Player Hurtbox")
            {
                main.stateMachine.SwitchState(parentState.attackTargetSS);
                break;
            }
        }
    }
}