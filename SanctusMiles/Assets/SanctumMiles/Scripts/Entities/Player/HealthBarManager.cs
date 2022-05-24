using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{

    [SerializeField]private GameObject healthBarPrefab;
    private GameObject healthBar;

    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = Instantiate(healthBarPrefab, transform.position, Quaternion.identity, transform.parent);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Destroy(healthBar);
        GameManager.playersAlive = GameManager.playersAlive - 1;
    }
}
