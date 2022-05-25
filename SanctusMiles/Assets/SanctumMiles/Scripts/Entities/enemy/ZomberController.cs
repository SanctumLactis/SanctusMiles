using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomberController : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Move Zomber towards position
    public void MoveTowardsPosition(Vector3 position, float moveSpeed)
    {
        Look(position);
        MoveForward(moveSpeed);
    }

    public void MoveTowardsPosition(GameObject gameObject, float moveSpeed)
    {
        Look(gameObject);
        MoveForward(moveSpeed);
    }

    // Look Zomber
    public void Look(Vector3 position)
    {
        // get direction you want to point at
        Vector2 direction = ((Vector2)position - (Vector2) transform.position).normalized;

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
    public void MoveForward(float moveSpeed)
    {
        rigidBody.AddForce(transform.right * moveSpeed * Time.deltaTime, ForceMode2D.Force);
    }

    void OnDestroy()
    {
        // Increase the score of the player when dead
        int currentScore = PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score", currentScore + 1);
    }
}
