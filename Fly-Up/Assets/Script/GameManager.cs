using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System.Linq;

public enum Level
{
    EASY,
    HARD
}


public class GameManager : Singleton<GameManager>
{
    protected override void InternalInit()
    {
       
    }

    protected override void InternalOnDestroy()
    {
        
    }

   



    // get list from firebase



    // get the audiosource
    [HideInInspector]
    public AudioSource _audioSource;

    private List<Controller> _controllers;
    private List<Controller> _levels;
    public Level _selectedLevel;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _controllers = FindObjectsOfType<Controller>().ToList();
        _levels = new List<Controller>();

        foreach ( Controller i in _controllers)
        {
            if (i._desired_level == Level.EASY || i._desired_level == Level.HARD)
            {
                _levels.Add(i);
            }
        }

        // check for playerpref
        if (PlayerPrefs.HasKey("level"))
        {
            if (PlayerPrefs.GetInt("level") == (int)Level.EASY)
            {
                _selectedLevel = Level.EASY;
            }
            else if(PlayerPrefs.GetInt("level") == (int)Level.HARD)
            {
                _selectedLevel = Level.HARD;
            }
        }
        else
        {
            PlayerPrefs.SetInt("level", (int)Level.EASY);
            _selectedLevel = Level.EASY;

        }

        changeSelectedLevel(_selectedLevel);

        SetDifficultyLevel();
        
    }

    void print()
    {
        Debug.Log(PlayerPrefs.GetInt("level"));
    }

    public void changeSelectedLevel(Level _level)
    {

        foreach (Controller level in _levels)
        {
            if( level._desired_level == _level)
            {
                level.GetComponent<Lean.Gui.LeanToggle>().On = true;
            }
            else
            {
                level.GetComponent<Lean.Gui.LeanToggle>().On = false;

            }
        }

        _selectedLevel = _level;

    }

    void SetDifficultyLevel()
    {
        if(_selectedLevel == Level.EASY)
        {

        }
        else if(_selectedLevel == Level.HARD)
        {

        }
    }


}

