using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPLOSION : MonoBehaviour
{
    bool truc = false;

    public bool NUKEbool = false;
    float timerlimitEXPLOSION = 0.3f;

    float timerEXPLOSION = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (NUKEbool == true)
        {
            timerlimitEXPLOSION = 3f;
        }
        truc = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (truc == true)
        {
            timerEXPLOSION += Time.deltaTime;
            if (timerEXPLOSION >= timerlimitEXPLOSION)
            {
                Destroy(gameObject);
            }
        }
    }
}
