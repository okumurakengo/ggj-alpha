using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private ServiceContainer _serviceContainer;
    private SharedStatus _sharedStatus;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    
    void Awake()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _sharedStatus = new SharedStatus();
        _serviceContainer = new ServiceContainer();
        
        _serviceContainer.AddContaner(new AppearanceEnemyService());
        _serviceContainer.AddContaner(new ActionWhenEnemyDiedService());
        _serviceContainer.AddContaner(new GotoGameOverWhenDiedService());
    }

    // Update is called once per frame
    void Update()
    {
        _sharedStatus.totalSeconds += Time.deltaTime;

        if (false == _sharedStatus.isGameOver)
        {
            _serviceContainer.ExecuteAll(_sharedStatus, this);
        }
        else
        {
            SceneManager.LoadScene("Result");
        }
    }
}
