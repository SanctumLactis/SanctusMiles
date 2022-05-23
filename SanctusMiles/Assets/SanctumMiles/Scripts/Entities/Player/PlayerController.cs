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

    float move;
    float turn;

    public Animator anim;

    public Collider2D playerCollider;
    public Collider2D doorTrigger;
    public List<string> levels = new List<string>();

    public float AttackCooldown = 0.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Get references
        rigidBody = transform.GetComponent<Rigidbody2D>();

        playerInput = transform.GetComponent<PlayerInput>();

        timer = AttackCooldown;
        
        // Set input method
        if (player1 == this)
            playerInput.SwitchCurrentActionMap("Player 1");
        else if (player2 == this)
            playerInput.SwitchCurrentActionMap("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
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
                if(timer < 0)
                {
                    anim.CrossFadeInFixedTime("swing left anim", 0);
                    timer = AttackCooldown;
                }
                break;
            case InputActionPhase.Performed:
                // Action Performed
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
                if(timer < 0)
                {
                    anim.CrossFadeInFixedTime("swing right anim", 0);
                    timer = AttackCooldown;
                }
                break;
            case InputActionPhase.Performed:
                // Action Performed
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
                if (playerCollider.IsTouching(doorTrigger))
                {
                    SceneManager.LoadScene(levels[1]);
                }
                else if (timer < 0)
                {
                    anim.CrossFadeInFixedTime("special anim", 0);
                    timer = AttackCooldown;
                }
                break;
            case InputActionPhase.Performed:
                // Action Performed
                break;
            case InputActionPhase.Canceled:
                // Button Released
                break;
        }
    }

    IEnumerator swinganimation()
    {

        
        yield return new WaitForSeconds(1);
    }
}
