using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player1;
    public static PlayerController player2;

    public void Awake()
    {
        // Create pseudo singletons that make sure there are
        // only 2 players active and keep them as instances
        // that can be referenced from any script using:
        // - PlayerController.player1
        // - PlayerController.player2
        if (player1 == null)
            // If there is no player 1, make this player 1
            player1 = this;
        else if (player1 != this)
            // if there is a player 1, and it is not this player, check if there is a player 2
            if (player2 == null)
                // If there is no player 2, make this player 2
                player2 = this;
            else if (player2 != this)
                // If there is a player 2, and it is not this player, delete this player
                Destroy(gameObject);
    }

    [SerializeField] float moveSpeed = 1000f;
    [SerializeField] float turnSpeed = 400f;

    private Rigidbody2D rigidBody;
    private PlayerInput playerInput;
    public ColliderManager colliderManager;

    float move;
    float turn;

    public Animator anim;

    public Collider2D playerCollider;
    public Collider2D doorTrigger;
    public List<string> levels = new List<string>();

    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float specialDamage = 30f;
    [SerializeField] private float attackEndlag = 0.5f;
    [SerializeField] private float specialEndlag = 1f;

    private float timer;

    AudioSource audioSource;
    public AudioSource audioSourceAttack;
    public AudioSource audioSourceHit;

    // Start is called before the first frame update
    void Start()
    {
        // Get references
        rigidBody = GetComponent<Rigidbody2D>();

        playerInput = GetComponent<PlayerInput>();

        colliderManager = GetComponent<ColliderManager>();

        GameObject hitBoxes = transform.GetChild(1).gameObject;

        timer = attackEndlag;

        audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0f;
        
        // Set input method
        if (player1 == this)
            playerInput.SwitchCurrentActionMap("Player 1");
        else if (player2 == this)
            playerInput.SwitchCurrentActionMap("Player 2");

        // Enable hitboxes
        hitBoxes.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //Debug.Log(rigidBody.velocity.magnitude);

        if(rigidBody.velocity.magnitude > 0.5) //Make This a small number
            audioSource.volume = 0.5f;
        else
            audioSource.volume = 0f;
    }

    void FixedUpdate()
    {
        rigidBody.AddTorque(turnSpeed * -turn * Time.deltaTime);

        rigidBody.AddForce(transform.right * moveSpeed * move * Time.deltaTime, ForceMode2D.Force);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<float>();
        //Debug.Log("Move: " + move);

    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turn = context.ReadValue<float>();
        // Debug.Log("Turn: " + turn);
    }

    public void OnAttackLeft(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                // Action Started
                if(timer < 0)
                {
                    anim.CrossFadeInFixedTime("swing left anim", 0);
                    audioSourceAttack.Play(0);
                }
                break;
            case InputActionPhase.Performed:
                // Action Performed
                if(timer < 0)
                {
                    AttackEnemies("AttackLeft", attackDamage);
                    timer = attackEndlag;
                }
                break;
            case InputActionPhase.Canceled:
                // Button Released
                break;
        }
    }

    public void OnAttackRight(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                // Action Started
                if(timer < 0)
                {
                    anim.CrossFadeInFixedTime("swing right anim", 0);
                    audioSourceAttack.Play(0);
                }
                break;
            case InputActionPhase.Performed:
                // Action Performed
                if(timer < 0)
                {
                    AttackEnemies("AttackRight", attackDamage);
                    timer = attackEndlag;
                }
                break;
            case InputActionPhase.Canceled:
                // Button Released
                break;
        }
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                if (timer < 0)
                {
                    anim.CrossFadeInFixedTime("SpecialAttack", 0);
                    audioSourceAttack.Play(0);
                }
                break;
            case InputActionPhase.Performed:
                // Action Performed
                if(timer < 0)
                {
                    AttackEnemies("Special", specialDamage);
                    timer = specialEndlag;
                }
                break;
            case InputActionPhase.Canceled:
                // Button Released
                break;
        }
    }

    private void AttackEnemies(string attackType, float damage)
    {
        Debug.Log("attacking enemies");
        List<KeyValuePair<string, GameObject>> enemiesInRange = GetEnemiesInAttackRange();
        foreach (KeyValuePair<string, GameObject> enemyInRange in enemiesInRange)
        {
            if (enemyInRange.Key != null && enemyInRange.Value != null)
            {
                if (enemyInRange.Key == attackType)
                {
                    Debug.Log(enemyInRange.Value.name);
                    audioSourceHit.Play(0);

                    float remainingHealth = enemyInRange.Value.GetComponent<HealthData>().DoDamage(damage);
                }
            }
        }
    }

    private List<KeyValuePair<string, GameObject>> GetEnemiesInAttackRange()
    {
        List<KeyValuePair<string, GameObject>> enemiesInRange = new List<KeyValuePair<string, GameObject>>();
        foreach (KeyValuePair<GameObject, Collider2D> collision in colliderManager.GetCollisions())
        {
            if (collision.Key != null && collision.Value != null)
            {
                if (collision.Value.gameObject.tag == "Enemy Hurtbox")
                {
                    Debug.Log(collision.Key.name + " " + collision.Value.gameObject.name);
                    enemiesInRange.Add(new KeyValuePair<string, GameObject>(collision.Key.name, collision.Value.transform.parent.parent.gameObject));
                }
            }
        }
        return enemiesInRange;
    }
}
