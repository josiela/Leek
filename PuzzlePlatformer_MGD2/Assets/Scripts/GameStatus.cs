﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // New Game Button function
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene( sceneName );
    }
}
