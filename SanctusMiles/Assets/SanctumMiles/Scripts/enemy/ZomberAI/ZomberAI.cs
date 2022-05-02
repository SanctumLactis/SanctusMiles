using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberAI : MonoBehaviour
{
    // State Machine
    [SerializeField] StateMachineDIA stateMachine;

    // States
    [SerializeField] ZomberIdleState idleState;
    [SerializeField] ZomberWanderState wanderState;
    [SerializeField] ZomberAttackState attackState;

    public ZomberAI()
    {
        stateMachine = new StateMachineDIA();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize States
        idleState = new ZomberIdleState(this);
        wanderState = new ZomberWanderState(this);
        attackState = new ZomberAttackState(this);

        // Change to starting state
        stateMachine.SwitchState(idleState);
    }
}
