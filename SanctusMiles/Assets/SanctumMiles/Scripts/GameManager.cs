using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject cameraSystemPrefab;

    [SerializeField] private int defaultPlayerCount = 2;


    private GameObject players;
    private GameObject cameraSystem;
    private CinemachineTargetGroup targetGroup;

    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("playerCount", defaultPlayerCount);
        // Defaults to defaultPlayerCount if it has not been specified before this.
        if (PlayerPrefs.GetInt("playerCount") != 1 && PlayerPrefs.GetInt("playerCount") != 2)
            PlayerPrefs.SetInt("playerCount", defaultPlayerCount);

        // Get Player Spawn Positions
        Vector3 player1Spawn = transform.GetChild(0).GetChild(0).position;
        Vector3 player2Spawn = transform.GetChild(0).GetChild(1).position;

        players = new GameObject();
        players.name = "Players";

        cameraSystem = Instantiate(cameraSystemPrefab);

        targetGroup = cameraSystem.transform.GetComponentInChildren<CinemachineTargetGroup>();
        
        CreatePlayer(player1Spawn);

        if (PlayerPrefs.GetInt("playerCount") == 2)
            CreatePlayer(player2Spawn);
    }

    private GameObject CreatePlayer(Vector3 spawnPosition)
    {
        GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity, players.transform);
        targetGroup.AddMember(player.transform, 1, 3);
        return player;
    }
}
