using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderUpdater : MonoBehaviour
{
    public delegate void CollideEnter(GameObject collider, Collider collideEnter);
 
    public CollideEnter collideEnter;

    public delegate void CollideExit(GameObject collider, Collider collideExit);
 
    public CollideExit collideExit;
 
 
    private void OnTriggerEnter(Collider other)
    {
        collideEnter(gameObject, other);
    }
     
    private void OnTriggerExit(Collider other) {
        collideExit(gameObject, other);
    }
}
