using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<float>();
        rb.velocity = transform.right * Mathf.Clamp01(movement) * moveSpeed;
    }

    void OnTurn(InputAction.CallbackContext context)
    {
        turn = context.ReadValue<float>();
        float rotation = -turn * turnSpeed;
        transform.Rotate(Vector3.forward * rotation);
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

    void OnSpecial(InputAction.CallbackContext context)
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
