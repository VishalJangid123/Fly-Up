using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onLevelToggleCliked(int level)
    {
        Level _level = Level.EASY;

        switch(level)
        {
            case 0: _level = Level.EASY;break; 
            case 1: _level = Level.HARD; break;
            
        }

        Debug.Log(_level);
        // change diffculty level
        PlayerPrefs.SetInt("level", (int)_level);

        GameManager.instance.changeSelectedLevel(_level);
    }
}
