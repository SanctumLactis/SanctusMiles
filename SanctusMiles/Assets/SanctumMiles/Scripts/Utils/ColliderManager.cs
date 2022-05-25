using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [Header("Colliders")]
    // Colliders
    public List<ColliderUpdater> colliderUpdaters;
    private List<KeyValuePair<GameObject, Collider2D>> collisions = new List<KeyValuePair<GameObject, Collider2D>>();
    public List<KeyValuePair<GameObject, Collider2D>> GetCollisions() 
    {
        collisions.RemoveAll(collision => collision.Value == null);
        return collisions;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Register Colliders
        foreach(ColliderUpdater colliderUpdater in colliderUpdaters)
        {
            colliderUpdater.collideEnter = OnCollideEnter;
            colliderUpdater.collideExit = OnCollideExit;
        }
    }
    

    public void OnCollideEnter(GameObject colliderObject, Collider2D other)
    {
        KeyValuePair<GameObject, Collider2D> collision = new KeyValuePair<GameObject, Collider2D>(colliderObject, other);
        if (!collisions.Contains(collision)) { collisions.Add(collision); }
    }

    public void OnCollideExit(GameObject colliderObject, Collider2D other)
    {
        KeyValuePair<GameObject, Collider2D> collision = new KeyValuePair<GameObject, Collider2D>(colliderObject, other);
        if (collisions.Contains(collision)) { collisions.Remove(collision); }
    }
}
