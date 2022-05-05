using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberWanderState : StateDIA
{
    // Variables
    [SerializeField] float wanderRange = 3.5f;
    [SerializeField] float switchIdleDistance = 0.25f;
    [SerializeField] float maxWanderTime = 5f;

    Vector3 wanderArea;
    Vector3 wanderPosition;
    float distanceToPosition;

    // Coroutines
    Coroutine waitThenIdle;

    // Runs on initialization
    public ZomberWanderState(object mainScript) : base(mainScript)
    {
        wanderRange = main.wanderRange;
        switchIdleDistance = main.switchIdleDistance;
        maxWanderTime = main.maxWanderTime;
        
        wanderArea = main.transform.position;
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter(dynamic[] args)
    {
        // Start Coroutine that turns to idle after maxWanderTime to make sure the Zomber isn't stuck
        waitThenIdle = MonoHelper.instance.StartCoroutine(WaitThenIdle());

        // Get a random position within the wander area
        wanderPosition = new Vector3(wanderArea.x + UnityEngine.Random.Range(-wanderRange, wanderRange), wanderArea.y + UnityEngine.Random.Range(-wanderRange, wanderRange), 0);
    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {
        //TODO: Add check for if the Zomber can see the player


        // Check how close we are to the wander position
        distanceToPosition = Vector3.Distance(main.transform.position, wanderPosition);

        UnityEngine.Debug.Log(distanceToPosition.ToString() + " " + wanderPosition.ToString());
        if (distanceToPosition < switchIdleDistance)
        {
            main.stateMachine.SwitchState(main.idleState);
        }
    }

    // Runs at a fixed rate and is framerate independent
    public override void OnFixedUpdate()
    {
        // Move
        main.controller.MoveTowardsPosition(wanderPosition);
    }

    // Runs when the state stops
    public override void OnExit()
    {
        MonoHelper.instance.StopCoroutine(waitThenIdle);
    }

    // Waits then switches to the wander state
    IEnumerator WaitThenIdle()
    {
        yield return new WaitForSeconds(maxWanderTime);
        main.stateMachine.SwitchState(main.wanderState);
    }
}