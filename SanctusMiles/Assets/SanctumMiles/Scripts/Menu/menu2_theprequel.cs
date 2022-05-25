using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu2_theprequel : MonoBehaviour
{

    public GameObject playbuttons;
    public Animator playbuttonsAnimator;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMenu()
    {
        playbuttons.GetComponent<Animator> ().Play ("ClickPlay_buttonsmove");
        playbuttonsAnimator.Play("ClickPlay_mainbuttonsmove");
    }

    public void StartGame(int playerCount)
    {
        PlayerPrefs.SetInt("playerCount", playerCount);
        PlayerPrefs.SetInt("score", 0);

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        playbuttons.GetComponent<Animator> ().Play ("ClickBack_Buttonsmove");
        playbuttonsAnimator.Play("ClickBack_mainButtonsmove");
    }
}
