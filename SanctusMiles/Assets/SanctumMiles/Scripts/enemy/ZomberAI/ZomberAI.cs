using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberAI : MonoBehaviour
{
    public ZomberController controller;

    [Header("State Machine")]
    // State Machine
    [SerializeField] public StateMachineDIA stateMachine;

    // States
    [SerializeField] public ZomberIdleState idleState;
    [SerializeField] public ZomberWanderState wanderState;
    [SerializeField] public ZomberAttackState attackState;

    [Header("Idle State")]
    // IdleState
    [SerializeField] public float switchWanderTimeMin = 2f;
    [SerializeField] public float switchWanderTimeMax = 5f;

    [Header("Wander State")]
    // WanderState
    [SerializeField] public float wanderRange = 3.5f;
    [Tooltip("How close the Zomber has to reach the target position before it enters Idle State again.")]
    [SerializeField] public float switchIdleDistance = 0.25f;
    [SerializeField] public float maxWanderTime = 5f;

    [Header("Attack State")]
    // AttackState
    [SerializeField] public float viewDistance = 4.5f;

    public ZomberAI()
    {
        stateMachine = new StateMachineDIA();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Controller
        controller = GetComponent<ZomberController>();

        // Initialize States
        idleState = new ZomberIdleState(this);
        wanderState = new ZomberWanderState(this);
        attackState = new ZomberAttackState(this);

        // Change to starting state
        stateMachine.SwitchState(wanderState);
    }
}
