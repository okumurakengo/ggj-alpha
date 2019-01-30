using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ゲームオーバー判定
public class GotoGameOverWhenDiedService : IService
{
    public void progress(SharedStatus sharedStatus, GameManager gameObject)
    {
        // do Something...
        foreach (var enemy in sharedStatus.aliveEnemyList)
        {
            if (enemy.GetComponent<Enemy>().HasReachedGoal())
            {
                sharedStatus.isGameOver = true;
            }
        }
    }
}