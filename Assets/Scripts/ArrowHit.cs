using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{

    public bool canBePressed;
    public ArrowSpawner hit;
    

    public KeyCode keyToPress;

  
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                Destroy(gameObject);
                Destroy(FindAnyObjectByType<ArrowSpawner>().hitPoint);
                FindAnyObjectByType<ArrowSpawner>().isPresent = false;
                FindAnyObjectByType<ArrowSpawner>().isMoving = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitPoint");
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "HitPoint");
        {
            canBePressed = false;
        }
    }
}
