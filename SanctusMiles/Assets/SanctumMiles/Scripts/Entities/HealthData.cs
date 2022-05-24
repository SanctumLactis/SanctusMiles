using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    public float playerHP = 100f;
    [SerializeField] private float regenAmount = 1f;
    [SerializeField] public float regenSpeed = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HealthRegen());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP > 100f)
            playerHP = 100f;
        
        if (playerHP <= 0)
        {
            playerHP = 0f;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
    }

    IEnumerator HealthRegen()
    {
        while (playerHP > 0)
        {
            if (playerHP < 100f)
                playerHP += regenAmount;
            
            yield return new WaitForSeconds(regenSpeed);
        }
    }

    public void DoDamage(float damage)
    {
        playerHP -= damage;
    }
}
