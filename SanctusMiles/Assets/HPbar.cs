using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{

    private float healthData;
    private GameObject gweenBar;

    // Start is called before the first frame update
    void Start()
    {
        gweenBar = transform.Find("gween").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        healthData = gameObject.GetComponentInParent<HealthData>().playerHP;
        gweenBar.transform.localScale = new Vector3(healthData, 4f, 1f);
    }
}
