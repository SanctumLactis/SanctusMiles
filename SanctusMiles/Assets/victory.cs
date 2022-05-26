using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{

    public GameObject bossScript;
    private HealthData healthData;
    public GameObject crazyZomberParent;
    public GameObject crazyZomberParent2;
    public GameObject victoryObj;
    public GameObject endgameSound;

    // Start is called before the first frame update
    void Start()
    {
        healthData = bossScript.GetComponent<HealthData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthData.health <= 0)
        {
            victoryObj.SetActive(true);
            crazyZomberParent.SetActive(false);
            crazyZomberParent2.SetActive(false);
            endgameSound.SetActive(false);
            //Time.timeScale = 0;           
        }
    }
}
