using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgameGameover : MonoBehaviour
{

    private HealthData healthData;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        healthData = player.GetComponent<HealthData>();
        player = PlayerController.player1.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(healthData.GetHealth());
        //if(healthData.GetHealth() <= 0)
        //    gameObject.SetActive(false);
    }
}
