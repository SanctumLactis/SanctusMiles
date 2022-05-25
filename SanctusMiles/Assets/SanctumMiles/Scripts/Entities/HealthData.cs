using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float health = 100f;
    public float GetHealth() { return health; }
    [SerializeField] private float regenAmount = 1f;
    [SerializeField] private float regenSpeed = 0.5f;
    public AudioSource audioSourceDeath;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        StartCoroutine(HealthRegen());
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 100f)
            health = 100f;
        
        if (health <= 0)
        {
            health = 0f;
            Destroy(gameObject);
            audioSourceDeath.Play(0);
            //GameManager.playersAlive = GameManager.playersAlive - 1;
        }
        //Debug.Log(GameManager.playersAlive);
    }

    IEnumerator HealthRegen()
    {
        while (health > 0)
        {
            if (health < 100f)
                health += regenAmount;
            
            yield return new WaitForSeconds(regenSpeed);
        }
    }

    public float DoDamage(float damage, float knockback=100)
    {
        rigidBody.AddForce(transform.right * knockback * Time.deltaTime, ForceMode2D.Impulse);

        health -= damage;
        if (health <= 0)
        {
            health = 0f;
        }
        return health;
    }
}
