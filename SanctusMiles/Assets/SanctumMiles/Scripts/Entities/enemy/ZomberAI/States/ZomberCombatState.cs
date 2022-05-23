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
    }

    // Runs once before the first OnUpdate() when state is activated
    public override void OnEnter(dynamic[] args)
    {

        main.stateMachine.SwitchState(moveToTargetSS);
    }

    // Runs every frame the state is active
    public override void OnUpdate()
    {
        CheckPlayersVisible();
    }

    // Runs at a fixed rate and is framerate independent
    public override void OnFixedUpdate()
    {
        
    }

    // Runs when the state stops
    public override void OnExit()
    {

    }

    private void CheckPlayersVisible()
    {
        // Check for all Players visible
        bool playerDetected = false;
        List<GameObject> _playersVisible = new List<GameObject>();
        foreach (KeyValuePair<GameObject, Collider2D> collision in main.GetCollisions())
        {
            if (collision.Key.name == "View Distance" && collision.Value.gameObject.tag == "Player Hurtbox")
            {
                playerDetected = true;
                _playersVisible.Add(collision.Value.gameObject);
            }
        }
        playersVisible = _playersVisible;

        // Switch to Idle if a Player is not visible
        if (!playerDetected)
        {
            Debug.Log("Lost sight of all Players");
            main.stateMachine.SwitchState(main.idleState);
        }
    }

    public GameObject GetClosestVisiblePlayer()
    {
        GameObject closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach(GameObject potentialTarget in playersVisible)
        {
            float distanceToTarget = Vector3.Distance(potentialTarget.transform.position, main.transform.position);
            
            if(distanceToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = distanceToTarget;
                closestTarget = potentialTarget;
            }
        }             
        return closestTarget.transform.parent.parent.gameObject;
    }
}