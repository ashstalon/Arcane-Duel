using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScroller : MonoBehaviour
{

    public float fallSpeed;
    public bool started = false;
    void Start()
    {
        fallSpeed = 5f;
    }
    void Update()
    {
        if(!started)
        {
            if(Input.anyKeyDown)
            {
                started = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, fallSpeed * Time.deltaTime, 0f);
        }
    }
}
