using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZISSStandingStill : SubStateDIA
{
    // Variables
    [SerializeField] float switchWanderTimeMin = 2f;
    [SerializeField] float switchWanderTimeMax = 5f;

    // Coroutines
    Coroutine waitThenWander;

    // Runs on initialization
    public ZISSStandingStill(object mainScript, object parentState) : base(mainScript, parentState)
    {
        switchWanderTimeMin = main.switchWanderTimeMin;
        switchWanderTimeMax = main.switchWanderTimeMax;
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter()
    {
        waitThenWander = MonoHelper.instance.StartCoroutine(WaitThenWander());
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
        MonoHelper.instance.StopCoroutine(waitThenWander);
    }

    // Waits then switches to the wander state
    IEnumerator WaitThenWander()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(switchWanderTimeMin, switchWanderTimeMax));
        main.stateMachine.SwitchState(parentState.wanderSS);
    }
}