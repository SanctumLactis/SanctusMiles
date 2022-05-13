using System.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCSSAttackTarget : SubStateDIA
{
    float attackEndlag = 1f;

    // Runs on initialization
    public ZCSSAttackTarget(object mainScript, object parentState) : base(mainScript, parentState)
    {
        attackEndlag = main.attackEndlag;
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter()
    {
        Debug.Log("running coroutine attackplayer");
        MonoHelper.instance.StartCoroutine(AttackPlayer());
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

    IEnumerator AttackPlayer()
    {
        GameObject closestPlayer = parentState.GetClosestVisiblePlayer();
        Debug.Log("Attacking Player: " + closestPlayer.name);

        // Remove Health from closestPlayer and play animation

        yield return new WaitForSeconds(attackEndlag);

        main.stateMachine.SwitchState(parentState.moveToTargetSS);
    }
}