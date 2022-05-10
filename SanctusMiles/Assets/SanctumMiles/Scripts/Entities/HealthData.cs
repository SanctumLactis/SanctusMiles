using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{

    [SerializeField] private float playerHP = 100f;
    [SerializeField] private float regenRate = 1f;
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
    }

    void FixedUpdate()
    {
    }

    IEnumerator HealthRegen()
    {
        while (playerHP > 0)
        {
            if (playerHP < 100f)
                playerHP += regenRate;
            
            yield return new WaitForSeconds(regenSpeed);
        }
    }

    void DoDamage(float damage)
    {
        playerHP -= damage;


    }
}
