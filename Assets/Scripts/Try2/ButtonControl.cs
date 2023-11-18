using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite Default;
    public Sprite Pressed;

    public KeyCode KeyPressed;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyPressed))
        {
            SR.sprite = Pressed;
        }

        if(Input.GetKeyUp(KeyPressed))
        {
            SR.sprite = Default;
        }
    }
}
