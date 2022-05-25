using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberAI : MonoBehaviour
{
    [HideInInspector] public ZomberController controller;

    [HideInInspector] public ColliderManager colliderManager;

    [Header("State Machine")]
    // State Machine
    [SerializeField] public StateMachineDIA stateMachine;

    // States
    [SerializeField] public ZomberIdleState idleState;
    [SerializeField] public ZomberCombatState combatState;

    [Header("Idle State")]
    [Tooltip("How far the Zomber can see, remember to change the collider too for proper representation")]
    [SerializeField] public float viewDistance = 4.5f;
    
    [Header("ZISS Stand Still")]
    // ZISS Stand Still
    [SerializeField] public float switchWanderTimeMin = 2f;
    [SerializeField] public float switchWanderTimeMax = 5f;

    [Header("ZISS Wander")]
    // ZISS Wander
    [SerializeField] public float wanderSpeed = 600;
    [SerializeField] public float wanderRange = 3.5f;
    [Tooltip("How close the Zomber has to reach the target position before it enters Idle State again.")]
    [SerializeField] public float switchIdleDistance = 0.25f;
    [SerializeField] public float maxWanderTime = 5f;

    [Header("Combat State")]
    // Combat State
    [Tooltip("How far the Zomber can attack, remember to change the collider too for proper representation")]
    [SerializeField] public float attackDistance = 1f;

    [Header("ZCSS Move To Target")]
    // ZCSS Attack Target
    [SerializeField] public float chaseSpeed = 900f;

    [Header("ZCSS Attack Target")]
    // ZCSS Attack Target
    [SerializeField] public float damage = 10f;
    [SerializeField] public float attackEndlag = 1f;

    public ZomberAI()
    {
        stateMachine = new StateMachineDIA();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Controller
        controller = GetComponent<ZomberController>();

        // Get Collider Manager
        colliderManager = GetComponent<ColliderManager>();

        // Initialize States
        idleState = new ZomberIdleState(this);
        combatState = new ZomberCombatState(this);


        // Change to starting state
        stateMachine.SwitchState(idleState);
    }

    public List<KeyValuePair<GameObject, Collider2D>> GetCollisions()
    {
        return colliderManager.GetCollisions();
    }

    void OnDestroy()
    {
        stateMachine.KillStateMachine();
    }
}