using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceEnemyService : IService
{
    public void progress(SharedStatus sharedStatus,  GameManager gameObject)
    {
        const float StartYPosition = 0.5f;
        
        var appearanceJudgement = new AppearanceJudgement();

        //Debug.Log("Debug Service progress time");
        //Debug.Log(sharedStatus.totalSeconds);
        if (appearanceJudgement.IsAppearable(sharedStatus.totalSeconds))
        {
            Debug.Log("Apparance Flag Raised");

            float xPosition = Random.Range(-10f, -2f);
            Vector3 pos = new Vector3(xPosition, StartYPosition, -0.147f);
            GameObject newEnemy = MonoBehaviour.Instantiate(gameObject.enemyPrefab, pos, Quaternion.identity);

            newEnemy.GetComponent<Enemy>().SetGoalPoint(new Vector3(xPosition, -3.0f, -1.0f));
            
            sharedStatus.aliveEnemyList.Add(newEnemy);
        }

    }
}