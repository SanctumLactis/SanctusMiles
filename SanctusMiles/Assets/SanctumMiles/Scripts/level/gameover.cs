using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{

    private GameObject endgameSoundye;

    // Start is called before the first frame update
    void Start()
    {
        endgameSoundye = GameObject.FindWithTag("endgameSoundTag");
        endgameSoundye.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(0);
        levelmusicScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
