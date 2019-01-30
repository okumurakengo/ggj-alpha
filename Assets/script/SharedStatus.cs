using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedStatus
{
    public double progressedTime = 70f;

    public List<GameObject> aliveEnemyList = new List<GameObject>();
    public double totalSeconds = 0f;
    public bool isGameOver = false;

    public void Reset()
    {
        aliveEnemyList = new List<GameObject>();
        totalSeconds = 0f;
        isGameOver = false;
    }

}
