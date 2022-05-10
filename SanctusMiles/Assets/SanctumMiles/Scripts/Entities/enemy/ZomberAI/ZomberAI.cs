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
    [SerializeField] public ZomberCombatState combatState;

    
    [Header("Colliders")]
    // Colliders
    public List<ColliderUpdater> colliderUpdaters;
    private List<KeyValuePair<GameObject, Collider>> collisions = new List<KeyValuePair<GameObject, Collider>>();
    public List<KeyValuePair<GameObject, Collider>> GetCollisions() { return collisions; }

    [Header("Idle State")]
    [Tooltip("How far the Zomber can see, remember to change the collider too for proper representation")]
    [SerializeField] public float viewDistance = 4.5f;
    
    [Header("ZISS Stand Still")]
    // ZISS Stand Still
    [SerializeField] public float switchWanderTimeMin = 2f;
    [SerializeField] public float switchWanderTimeMax = 5f;

    [Header("ZISS Wander")]
    // ZISS Wander
    [SerializeField] public float wanderRange = 3.5f;
    [Tooltip("How close the Zomber has to reach the target position before it enters Idle State again.")]
    [SerializeField] public float switchIdleDistance = 0.25f;
    [SerializeField] public float maxWanderTime = 5f;

    [Header("Combat State")]
    // AttackState
    [Tooltip("How far the Zomber can attack, remember to change the collider too for proper representation")]
    [SerializeField] public float attackDistance = 1f;

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
        combatState = new ZomberCombatState(this);

        // Register Colliders
        foreach(ColliderUpdater colliderUpdater in colliderUpdaters)
        {
            colliderUpdater.collideEnter = OnCollideEnter;
            colliderUpdater.collideExit = OnCollideExit;
        }

        // Change to starting state
        stateMachine.SwitchState(idleState);
    }

    public void OnCollideEnter(GameObject colliderObject, Collider other)
    {
        KeyValuePair<GameObject, Collider> collision = new KeyValuePair<GameObject, Collider>(colliderObject, other);
        if (!collisions.Contains(collision)) { collisions.Add(collision); }
    }

    public void OnCollideExit(GameObject colliderObject, Collider other)
    {
        KeyValuePair<GameObject, Collider> collision = new KeyValuePair<GameObject, Collider>(colliderObject, other);
        if (collisions.Contains(collision)) { collisions.Remove(collision); }
    }
}
