using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float turnSpeed = 50;

    [SerializeField] Rigidbody2D rigidBody;

    float move;
    float turn;

    public Animator anim;

    public Collider2D playerCollider;
    public Collider2D doorTrigger;
    public string level1 = "Level uno";


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -turn * turnSpeed * Time.deltaTime);
        rigidBody.velocity = transform.right * move * moveSpeed * Time.deltaTime;



    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<float>();
        //Debug.Log("Move: " + move);
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turn = context.ReadValue<float>();

        
        //Debug.Log("Turn: " + turn);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                anim.CrossFadeInFixedTime("swing left anim", 0);


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
                    SceneManager.LoadScene(level1);
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
}
