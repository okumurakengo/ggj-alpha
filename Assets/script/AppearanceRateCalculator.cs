using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppearanceRateCalculator
{

    private const double CapLogResult = 5.0f;
    private readonly double _progressedTime = 0f;

    public AppearanceRateCalculator(double progressedTime) 
    {
        this._progressedTime = progressedTime;
    }

    public double GetRate()
    {
        return Math.Min(
            Math.Pow(1.008981, this._progressedTime)
            , CapLogResult);
    }

    public static double GetMaxRate()
    {
        return CapLogResult;
    }
}
