using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zomberwander : MonoBehaviour{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 direction = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(rnadopositon());
    }

    IEnumerator rnadopositon()
    { 
        while (true)
        {
            direction = new Vector3(Random.Range(-5.0f, 5.0f) + transform.position.x, Random.Range(-3.0f, 3.0f) + transform.position.y, 0);
            yield return new WaitForSeconds(Random.Range(2,10));
        }
    }

    // Update is called once per frame
    void Update(){
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}