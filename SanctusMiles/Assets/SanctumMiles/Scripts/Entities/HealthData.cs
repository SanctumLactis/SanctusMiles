using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    private float health = 100f;
    public float GetHealth() { return health; }
    [SerializeField] private float regenAmount = 1f;
    [SerializeField] private float regenSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
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
        }
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

    public float DoDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0f;
        }
        return health;
    }
}
