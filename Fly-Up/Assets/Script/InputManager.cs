using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    DataHandler _dataHandler;
    void Start()
    {
        _dataHandler = this.GetComponent<DataHandler>();
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

        


        if (Input.GetKeyDown(KeyCode.UpArrow) && !shouldMove)
        {
            // move text up
            shouldMove = true;
            direction = (int)Move.UP;
            Debug.Log("UP key pressed");
            _dataHandler.UpKeyPress();
        }

        // detect down

        if (Input.GetKeyDown(KeyCode.DownArrow) && !shouldMove)
        {
            // move text down
            shouldMove = true;
            direction = (int)Move.DOWN;
            Debug.Log("DOWN key pressed");

            _dataHandler.DownKeyPress();


        }



    }

    

}
