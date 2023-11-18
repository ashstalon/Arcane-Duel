using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class ButtonEnter : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed == true)
            {
                Debug.Log("Key Pressed Successfuly");
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BoxArea")
        {
            canBePressed = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "BoxArea")
        {
            canBePressed = false;
        }

    }
}
