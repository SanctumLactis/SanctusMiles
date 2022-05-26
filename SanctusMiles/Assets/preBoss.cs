using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preBoss : MonoBehaviour
{

    public GameObject key;
    public SpriteRenderer keySprite;

    // Start is called before the first frame update
    void Start()
    {
        keySprite.color = new Color(1f,1f,1f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        keySprite.color = new Color(1f,1f,1f,1f);
    }
}
