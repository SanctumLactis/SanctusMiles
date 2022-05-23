using System.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCSSAttackTarget : SubStateDIA
{
    float damage = 10f;
    float attackEndlag = 1f;

    // Runs on initialization
    public ZCSSAttackTarget(object mainScript, object parentState) : base(mainScript, parentState)
    {
        damage = main.damage;
        attackEndlag = main.attackEndlag;
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter()
    {
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

        closestPlayer.GetComponent<HealthData>().DoDamage(damage);

        yield return new WaitForSeconds(attackEndlag);

        main.stateMachine.SwitchState(parentState.moveToTargetSS);
    }
}