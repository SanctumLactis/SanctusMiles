using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberCombatState : StateDIA
{
    // Variables
    public List<GameObject> playersVisible = new List<GameObject>();

    // Sub States
    [SerializeField] public ZCSSMoveToTarget moveToTargetSS;
    [SerializeField] public ZCSSAttackTarget attackTargetSS;

    // Runs on initialization
    public ZomberCombatState(object mainScript) : base(mainScript)
    {
        moveToTargetSS = new ZCSSMoveToTarget(main, this);
        attackTargetSS = new ZCSSAttackTarget(main, this);

        main.stateMachine.SwitchState(moveToTargetSS);
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter(dynamic[] args)
    {

    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {
        bool playerDetected = false;

        // Check for all Players visible
        foreach (KeyValuePair<GameObject, Collider> collision in main.GetCollisions())
        {
            if (collision.Key.name == "View Distance" && collision.Value.gameObject.tag == "Player")
            {
                playerDetected = true;
            }
        }

        // Switch to Idle if a Player is not visible
        if (!playerDetected)
        {
            main.SwitchState(main.idleState);
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