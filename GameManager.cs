using System.Collections;
using System.Collections.Generic;
using Minigames;
using Progression;
using SaveLoadSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public EnemySpawnerScript enemySpawnerScript;
    public MainHeroScript mainHero;
    
    private GameObject enemy;

    private EnemyScript enemyScript;

    private int gold;
    private int xP;
    private int lvl;
    // Start is called before the first frame update
    void Start()
    {
        GameSaveData loadedData = SaveSystem.LoadProgress();
        gold = loadedData.gold;
        xP = loadedData.XP;
        lvl = loadedData.lvl;  
        UpdateGoldCount();
        ContinueRun();
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
        AttackEnemy();
    }
    
    public MinigameManager minigameManager;
    public void AttackEnemy()
    {
        minigameManager.StartMinigameManager();
        
    }
    
    public void EndOfHeroAttack(int damage)
    {
        mainHero.StartAttack();
        enemyScript.HitByHero(damage);
        
        
    }

    public void EndOfHeroAnimation()
    {
        if (enemyScript.health <= 0)
        {
            gold += enemyScript.reward;
            xP += enemyScript.rewardXP;
            Destroy(enemyScript.gameObject);
            UpdateGoldCount();
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
        //Spawn enemy
        enemy = enemySpawnerScript.SpawnEnemy(1,1);
        enemyScript = enemy.GetComponent<EnemyScript>();
        //Move enemy and wall
        backGroundScript.enabled = true;
        backGroundScript.StartMove(enemy.transform);
    }

    public void EndOfBackgroundMove()
    {
        backGroundScript.enabled = false;
        StartFight();
    }

    public void EndRun()
    {
        MainProgressionsScript.SaveRunProgress(gold, xP, lvl);
        SceneManager.LoadScene("MainMenu");
    }

    public TextMeshProUGUI goldCount;

    private void UpdateGoldCount()
    {
        goldCount.text = gold.ToString();
    }
}
