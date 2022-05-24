using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{

    public static HPbar healthBar1;
    public static HPbar healthBar2;

    public void Awake()
    {
        // Create pseudo singletons that make sure there are
        // only 2 players active and keep them as instances
        // that can be referenced from any script using:
        // - PlayerController.player1
        // - PlayerController.player2
        if (healthBar1 == null)
            // If there is no player 1, make this player 1
            healthBar1 = this;
        else if (healthBar1 != this)
            // if there is a player 1, and it is not this player, check if there is a player 2
            if (healthBar2 == null)
                // If there is no player 2, make this player 2
                healthBar2 = this;
            else if (healthBar2 != this)
                // If there is a player 2, and it is not this player, delete this player
                Destroy(gameObject);
    }



    private HealthData healthData;
    private GameObject gweenBar;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Set input method
        if (healthBar1 == this)
            player = PlayerController.player1.gameObject;
        else if (healthBar2 == this)
            player = PlayerController.player2.gameObject;

        gweenBar = transform.GetChild(1).gameObject;

        healthData = player.GetComponent<HealthData>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, -1, 0);
        //gweendata e bytte bare på scalen 
        gweenBar.transform.localScale = new Vector3(healthData.playerHP, 4f, 1f);
    }
}
