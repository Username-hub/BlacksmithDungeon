using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int maxHealth;
    public int health;
    private int damageAttack;
    private string enemyName;
    private int reward;
    public Image healthBar;
    private GameManager gameManager;

    public void InitializeEnemy(EnemyObject enemyObject, GameManager manager)
    {
        this.gameManager = manager;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyObject.enemySprite;
        maxHealth = enemyObject.health;
        health = enemyObject.health;
        damageAttack = enemyObject.damage;
        reward = enemyObject.reward;
        enemyName = enemyObject.enemyName;
        gameObject.name = enemyName;
        //transform.localScale = new Vector3(2,2,1);
    }

    public int HitByHero(int damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health / maxHealth;
        return health;
    }

    public void StartAttack()
    {
        EndAttack();
    }

    private void EndAttack()
    {
        gameManager.EndEnemyAttack(damageAttack);
    }
}
