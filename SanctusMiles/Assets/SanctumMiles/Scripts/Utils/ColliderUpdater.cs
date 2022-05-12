using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderUpdater : MonoBehaviour
{
    public delegate void CollideEnter(GameObject collider, Collider collideEnter);
 
    public CollideEnter collideEnter;

    public delegate void CollideExit(GameObject collider, Collider collideExit);
 
    public CollideExit collideExit;
 
 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        collideEnter(gameObject, other);
    }
     
    void OnTriggerExit(Collider other) {
        Debug.Log(other);
        collideExit(gameObject, other);
    }
}
