using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{

    public int numObjects = 10;
    public GameObject zomberPrefab;
    public GameObject crazyZomberParent;
    public GameObject crazyZomberParent2;
    public GameObject victory;
    private HealthData healthData;

    // Start is called before the first frame update
    void Start() {
    //    Vector3 center = transform.position;
    //    for (int i = 0; i < numObjects; i++){
    //        Vector3 pos = RandomCircle(center, 15.0f);
    //        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
    //        Instantiate(zomberPrefab, pos, rot);
    //    }
        healthData = gameObject.GetComponent<HealthData>();
    }
 
    //Vector3 RandomCircle ( Vector3 center ,   float radius  ){
    //    float ang = Random.value * 360;
    //    Vector3 pos;
    //    pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
    //    pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
    //    pos.z = center.z;
    //    return pos;
    //}

    IEnumerator crazyZomberAttack()
    {
        yield return new WaitForSeconds(10);
        crazyZomberParent.SetActive(true);
        yield return new WaitForSeconds(10);
        crazyZomberParent.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthData.health < 500)
            StartCoroutine(crazyZomberAttack());

        if(healthData.health <= 0)
        {
            victory.SetActive(true);
            crazyZomberParent.SetActive(false);
            crazyZomberParent2.SetActive(false);
            //Time.timeScale = 0;           
        }
    }
}
