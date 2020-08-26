using System.Collections;
using System.Collections.Generic;
using Minigames;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public EnemySpawnerScript enemySpawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerScript.SpawnEnemy(1,1);
        AttackEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MinigameManager minigameManager;
    public void AttackEnemy()
    {
        minigameManager.StartMinigameManager();
        
    }

    public void EndEnemyattack(int damage)
    {
        
    }
}
