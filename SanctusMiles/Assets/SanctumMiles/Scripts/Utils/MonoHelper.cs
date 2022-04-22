using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to call MonoBehaviour Functions in non Monobehaviour scripts.
public class MonoHelper : MonoBehaviour
{
    public static MonoHelper instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}