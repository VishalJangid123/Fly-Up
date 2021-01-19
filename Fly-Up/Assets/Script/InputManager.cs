using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject sample_text;

    public enum Move
    {
        FIX,
        UP,
        DOWN
    }

    bool shouldMove = false;
    int direction = 0;

    // Update is called once per frame
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

        if(shouldMove)
            move(direction);

    }

    public void move(int direction)
    {
        sample_text.transform.position = Vector3.Lerp(sample_text.transform.position, new Vector3(0,5 * direction,0), 5 * Time.deltaTime);
        if(sample_text.transform.position.y >= 5f) shouldMove = false;
        Debug.Log("move called");
    }

}
