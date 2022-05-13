using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    public Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Move Zomber towards position
    public void MoveTowardsPosition(Vector3 position, float speed=1000)
    {
        Look(position);
        MoveForward(speed);
    }
    public void MoveTowardsPosition(Transform transform, float speed=1000)
    {
        Look(transform.position);
        MoveForward(speed);
    }

    public void MoveTowardsPosition(GameObject gameObject, float speed=1000)
    {
        Look(gameObject.transform.position);
        MoveForward(speed);
    }

    // Look Zomber
    public void Look(Vector3 position)
    {
        // get direction you want to point at
        Vector2 direction = ((Vector2)position - (Vector2) transform.position).normalized;

        // set vector of transform directly
        transform.right = direction;
    }

    public void Look(Transform transform)
    {
        // get direction you want to point at
        Vector2 direction = ((Vector2)transform.position - (Vector2) transform.position).normalized;

        // set vector of transform directly
        transform.right = direction;
    }

    public void Look(GameObject gameObject)
    {
        // get direction you want to point at
        Vector2 direction = ((Vector2)gameObject.transform.position - (Vector2) transform.position).normalized;

        // set vector of transform directly
        transform.right = direction;
    }

    // Move Forward Zomber
    public void MoveForward(float speed=1000)
    {
        rigidBody.AddForce(transform.right * moveSpeed, ForceMode2D.Force);
    }
}
