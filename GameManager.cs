using System.Collections;
using System.Collections.Generic;
using Minigames;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public EnemySpawnerScript enemySpawnerScript;
    public MainHeroScript mainHero;
    
    private GameObject enemy;

    private EnemyScript enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        StartFight();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            mainHero.TakeDamage(1);
        }
    }

    
    private void StartFight()
    {
        enemy = enemySpawnerScript.SpawnEnemy(1,1);
        enemyScript = enemy.GetComponent<EnemyScript>();
        AttackEnemy();
    }
    
    public MinigameManager minigameManager;
    public void AttackEnemy()
    {
        minigameManager.StartMinigameManager();
        
    }
    
    public void EndOfHeroAttack(int damage)
    {
        enemyScript.HitByHero(damage);
        if (enemyScript.health <= 0)
        {
            Destroy(enemyScript.gameObject);
            ContinueRun();
        }
        else
        {
            StartEnemyAttack();
        }
        
    }

    private void StartEnemyAttack()
    {
        enemyScript.StartAttack();
    }
    public void EndEnemyAttack(int damage)
    {
        mainHero.TakeDamage(damage);
        if (mainHero.health <= 0)
        {
            EndRun();
        }
        else
        {
            AttackEnemy();
        }
    }

    public BackGroundScript backGroundScript;
    private void ContinueRun()
    {
        backGroundScript.enabled = true;
        backGroundScript.StartMove();
    }

    public void EndOfBackgroundMove()
    {
        backGroundScript.enabled = false;
        StartFight();
    }

    private void EndRun()
    {}
}
