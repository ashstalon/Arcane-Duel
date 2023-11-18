using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSwipe : MonoBehaviour
{
    public bool canBePressed;
    public Vector3 startPos;

    private void Update()
    {

        GetTouch();

    }

    public void GetTouch()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                float swipeDistance = touch.position.x - startPos.x;


                if (swipeDistance > 0 && canBePressed == true)
                {

                    Destroy(gameObject);
                    Destroy(FindAnyObjectByType<ArrowSpawner>().hitPoint);
                    FindAnyObjectByType<ArrowSpawner>().isPresent = false;
                    FindAnyObjectByType<ArrowSpawner>().isMoving = false;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitPoint") ;
        {
            canBePressed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "HitPoint") ;
        {
            canBePressed = false;
        }
    }
}
