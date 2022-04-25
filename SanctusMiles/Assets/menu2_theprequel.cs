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
        playbuttons.SetActive(true);
        playbuttonsAnimator.Play("ClickPlay_mainbuttonsmove");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
