using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Current Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Current Score: " + PlayerPrefs.GetInt("score").ToString();
    }
}
