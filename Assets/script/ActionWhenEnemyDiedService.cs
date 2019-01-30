using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵が死んだときの処理向け(掃除とカウント)
public class ActionWhenEnemyDiedService : MonoBehaviour,IService
{
    public void progress(SharedStatus sharedStatus,  GameManager gameObject)
    {
        List<GameObject> deadEnemyList = new List<GameObject>();
        // 削除判定 (だけ)
        foreach (var enemy in sharedStatus.aliveEnemyList)
        {
            if (enemy.GetComponent<Enemy>().Gethp() <= 0)
            {
                deadEnemyList.Add(enemy);
                FindObjectOfType<Score>().AddPoint(100);
            }
        }

        // 削除リストからGameObjectをDestroy, aliveEnemyListからも削除
        foreach (var enemy in deadEnemyList)
        {
            MonoBehaviour.Destroy(enemy);

            sharedStatus.aliveEnemyList.Remove(enemy);
        }
    }
}