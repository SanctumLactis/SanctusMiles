using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZISSWander : SubStateDIA
{
    // Variables
    [SerializeField] float wanderSpeed = 600;
    [SerializeField] float wanderRange = 3.5f;
    [SerializeField] float switchIdleDistance = 0.25f;
    [SerializeField] float maxWanderTime = 5f;

    Vector3 wanderArea;
    Vector3 wanderPosition;
    float distanceToPosition;

    // Coroutines
    Coroutine waitThenStandStill;

    // Runs on initialization
    public ZISSWander(object mainScript, object parentState) : base(mainScript, parentState)
    {
        wanderSpeed = main.wanderSpeed;
        wanderRange = main.wanderRange;
        switchIdleDistance = main.switchIdleDistance;
        maxWanderTime = main.maxWanderTime;
        
        wanderArea = main.transform.position;
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter()
    {
        // Start Coroutine that turns to idle after maxWanderTime to make sure the Zomber isn't stuck
        waitThenStandStill = MonoHelper.instance.StartCoroutine(WaitThenStandStill());

        // Get a random position within the wander area
        wanderPosition = new Vector3(wanderArea.x + UnityEngine.Random.Range(-wanderRange, wanderRange), wanderArea.y + UnityEngine.Random.Range(-wanderRange, wanderRange), 0);
    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {
        // Check how close we are to the wander position
        distanceToPosition = Vector3.Distance(main.transform.position, wanderPosition);

        if (distanceToPosition < switchIdleDistance)
        {
            main.stateMachine.SwitchState(parentState.standingStillSS);
        }
    }

    // Runs at a fixed rate and is framerate independent
    public override void OnFixedUpdate()
    {
        // Move
        main.controller.MoveTowardsPosition(wanderPosition, wanderSpeed);
    }

    // Runs when the state stops
    public override void OnExit()
    {
        MonoHelper.instance.StopCoroutine(waitThenStandStill);
    }

    // Waits then switches to the wander state
    IEnumerator WaitThenStandStill()
    {
        yield return new WaitForSeconds(maxWanderTime);
        main.stateMachine.SwitchState(parentState.standingStillSS);
    }
}