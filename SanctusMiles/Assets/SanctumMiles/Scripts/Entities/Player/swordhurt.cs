using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class swordhurt : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.43f);
                //Debug.Log("key press");
                break;
            case InputActionPhase.Performed:
                GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.43f);
                //Debug.Log("key press2");
                break;
            case InputActionPhase.Canceled:
                // Button Released
                break;
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ENEMY")
        {
            Destroy(other.gameObject);
            Debug.Log("ow");
            GetComponent<Collider>().enabled = true;
        }
    }
}
