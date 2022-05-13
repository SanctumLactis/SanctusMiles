using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderUpdater : MonoBehaviour
{
    public delegate void CollideEnter(GameObject collider, Collider2D collideEnter);
 
    public CollideEnter collideEnter;

    public delegate void CollideExit(GameObject collider, Collider2D collideExit);
 
    public CollideExit collideExit;
 
 
    void OnTriggerEnter2D(Collider2D other)
    {
        collideEnter(gameObject, other);
    }
     
    void OnTriggerExit2D(Collider2D other) {
        collideExit(gameObject, other);
    }
}
