using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key2 : MonoBehaviour
{

    [SerializeField]private GameObject door;
    private Animator animator;

    public Transform keyTransform;
    public Transform bossTransform;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        door.SetActive(true);
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = bossTransform.position;
        transform.rotation = Quaternion.Euler(0, keyTransform.rotation.eulerAngles.y, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            door.SetActive(false);
            animator.enabled = true;
        }
    }

}
