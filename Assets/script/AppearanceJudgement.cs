using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppearanceJudgement
{
    public bool IsAppearable(double progressedTime)
    {
        //Debug.Log("ProgressedTime");
        //Debug.Log(progressedTime);
        AppearanceRateCalculator c = new AppearanceRateCalculator(progressedTime);
        var rand = Random.Range(0.0f, 1.0f);//(float)AppearanceRateCalculator.GetMaxRate());

        //Debug.Log("Rate");
        //Debug.Log(c.GetRate());

        return (rand < 0.002 * c.GetRate());
    }
}
