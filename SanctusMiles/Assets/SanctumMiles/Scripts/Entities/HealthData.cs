using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float regenAmount = 1f;
    [SerializeField] private float regenSpeed = 0.5f;
    [SerializeField] private float health;
    public float GetHealth() { return health; }

    private Rigidbody2D rigidBody;
    public AudioSource audioSourceDeath;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();

        StartCoroutine(HealthRegen());
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
            health = maxHealth;
        
        if (health <= 0)
        {
            health = 0f;
            if (audioSourceDeath != null)
            {
                audioSourceDeath.Play(0);
            }
            Destroy(gameObject);
            //GameManager.playersAlive = GameManager.playersAlive - 1;
        }
        //Debug.Log(GameManager.playersAlive);
    }

    IEnumerator HealthRegen()
    {
        while (health > 0)
        {
            if (health < maxHealth)
                health += regenAmount;
            
            yield return new WaitForSeconds(regenSpeed);
        }
    }

    public float DoDamage(float damage, float knockback=6.9f)
    {
        rigidBody.AddForce(transform.right * -knockback, ForceMode2D.Impulse);

        health -= damage;
        if (health <= 0)
        {
            health = 0f;
        }
        return health;
    }
}
