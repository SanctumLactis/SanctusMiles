using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float turnSpeed = 50;

    [SerializeField] Rigidbody2D rigidBody;

    float move;
    float turn;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.forward * -turn * turnSpeed * Time.deltaTime);
        rigidBody.velocity = transform.right * move * moveSpeed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<float>();
        Debug.Log("Move: " + move);
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turn = context.ReadValue<float>();
        
        Debug.Log("Turn: " + turn);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                // Button Pressed
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
                // Button Pressed
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
