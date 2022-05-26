using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startagane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        levelmusicScript.Instance.gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
