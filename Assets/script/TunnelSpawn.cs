using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawn : MonoBehaviour
{

    float timer;

    public float timerLimit;

    public GameObject voiture;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timerLimit)
        {
            Instantiate(voiture, transform.position, transform.rotation, GameObject.Find("GameObject_call").GetComponent<GameObject_Call>().cars.transform);
            timer = 0f;
        }
    }
}
