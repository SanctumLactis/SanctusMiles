using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberIdleState : StateDIA
{
    [SerializeField] float switchWanderTimeMin = 2f;
    [SerializeField] float switchWanderTimeMax = 5f;

    // Coroutines
    Coroutine waitThenWander;

    // Runs on initialization
    public ZomberIdleState(object mainScript) : base(mainScript)
    {
        switchWanderTimeMin = main.switchWanderTimeMin;
        switchWanderTimeMax = main.switchWanderTimeMax;
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter(dynamic[] args)
    {
        waitThenWander = MonoHelper.instance.StartCoroutine(WaitThenWander());
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
        MonoHelper.instance.StopCoroutine(waitThenWander);
    }

    // Waits then switches to the wander state
    IEnumerator WaitThenWander()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(switchWanderTimeMin, switchWanderTimeMax));
        main.stateMachine.SwitchState(main.wanderState);
    }
}