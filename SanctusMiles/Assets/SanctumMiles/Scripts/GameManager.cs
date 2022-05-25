using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject cameraSystemPrefab;

    [SerializeField] private bool forcePlayerCount = false;
    [SerializeField] private int defaultPlayerCount = 2;

    public static float playersAlive;

    private GameObject players;
    private GameObject cameraSystem;
    private CinemachineTargetGroup targetGroup;

    [SerializeField] private GameObject gameOverPrefab;
    private GameObject gameOver;

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
        // Defaults to defaultPlayerCount if it has not been specified before this.
        if (PlayerPrefs.GetInt("playerCount") != 1 && PlayerPrefs.GetInt("playerCount") != 2 || forcePlayerCount == true)
            PlayerPrefs.SetInt("playerCount", defaultPlayerCount);

        // Get Player Spawn Positions
        Vector3 player1Spawn = transform.GetChild(0).GetChild(0).position;
        Vector3 player2Spawn = transform.GetChild(0).GetChild(1).position;

        // Initialize Camera System
        cameraSystem = Instantiate(cameraSystemPrefab);

        targetGroup = cameraSystem.transform.GetComponentInChildren<CinemachineTargetGroup>();
        
        // Create Game Over Screen
        gameOver = Instantiate(gameOverPrefab);
        gameOver.SetActive(false);
        
        // Create Players
        players = new GameObject();
        players.name = "Players";

        CreatePlayer(player1Spawn);

        if (PlayerPrefs.GetInt("playerCount") == 2)
            CreatePlayer(player2Spawn);

        playersAlive = PlayerPrefs.GetInt("playerCount");
    }

    private GameObject CreatePlayer(Vector3 spawnPosition)
    {
        GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity, players.transform);
        targetGroup.AddMember(player.transform, 1, 3);
        return player;
    }

    void Update()
    {
        if(playersAlive == 0)
            gameOver.SetActive(true);
    }
}
