using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Start()
    {
    }

    public enum Move
    {
        FIX,
        UP = 1,
        DOWN = -1
    }

    [HideInInspector]
    public bool shouldMove = false;

    [HideInInspector]
    public int direction = 0;

    void Update()
    {
        // detect up

        


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // move text up
            shouldMove = true;
            direction = (int)Move.UP;
        }

        // detect down

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // move text down
            shouldMove = true;
            direction = (int)Move.DOWN;

        }

        

    }

    

}
