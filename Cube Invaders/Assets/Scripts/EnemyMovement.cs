using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float cycleWidth, frequency, velocity;
    float cY, cX, counter, xSin;
    // Start is called before the first frame update
    void Start()
    {
        cY= transform.position.y;
        cX= transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        cY = cY - velocity;
        counter= counter + (frequency/100);
        xSin = Mathf.Sin(counter);
        transform.position = new Vector3(cX + (xSin * cycleWidth), cY, 0);
        if (counter >6.28f)
        {
            { counter = 0; }
        }
    }
}
