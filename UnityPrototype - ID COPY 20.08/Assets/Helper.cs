﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void changeQualitySetting(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
    }
}