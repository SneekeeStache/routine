using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghtMove : MonoBehaviour
{
    bool moveDirection;

    public float limitMove;

    public float currentAngle;

    public float lightSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = transform.rotation.eulerAngles.x;
        transform.Rotate(new Vector3(lightSpeed,0,0),Space.Self);
        if(currentAngle <= limitMove)
        {
            transform.Rotate(new Vector3(lightSpeed,0,0),Space.Self);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,-30,0);
        }
    }
}
