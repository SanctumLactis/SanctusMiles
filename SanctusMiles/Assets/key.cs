using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{

    public GameObject door;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            door.SetActive(false);
            animator.CrossFadeInFixedTime("keygone", 0);
        }
    }
}
