using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }
}

