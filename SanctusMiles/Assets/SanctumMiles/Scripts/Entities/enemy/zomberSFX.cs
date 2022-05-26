using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zomberSFX : MonoBehaviour
{

    private AudioSource audioSourceGrowl;
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceGrowl = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //audioSourceGrowl.Play([Random.Range(0, 10000)];);

        if (!audioSourceGrowl.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                audioSourceGrowl.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}
