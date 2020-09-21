using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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
    }

    public int HitByHero(int damage)
    {
        if(damage > 0)
            SetupGetHitAnimation();
        health -= damage;
        healthBar.fillAmount = (float)health / maxHealth;
        return health;
    }

    public void StartAttack()
    {
        SetupAttackAnimation();
    }

    private void EndAttack()
    {
        gameManager.EndEnemyAttack(damageAttack);
    }

    private bool attacAnimationPlay = false;
    private bool getHitAnimationPlay = false;
    
    public float pushTime = 2f;
    public float speed = 1;
    private float distHitBackward;
    private float distHitForward;
    private void SetupGetHitAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        distHitBackward = pushTime / 2;
        distHitForward = pushTime / 2;
        getHitAnimationPlay = true;
    }

    private float distAttackBackward;
    private float distAttackForward;
    private void SetupAttackAnimation()
    {
        distAttackBackward = pushTime / 2;
        distAttackForward = pushTime / 2;
        attacAnimationPlay = true;
    }
    private void EndOfMoveBackAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void Update()
    {
        if (getHitAnimationPlay)
        {
            PlayGetHitAnimation();
        }else if (attacAnimationPlay)
        {
            PlayAttackAnimation();
        }
    }

    private void PlayGetHitAnimation()
    {
        if (distHitBackward > 0)
        {
            Vector2 position = transform.position;
            position.x += speed * Time.deltaTime;
            transform.position = position;
            distHitBackward -= Time.deltaTime;
            if (distHitBackward <= 0)
            {
                EndOfMoveBackAnimation();
            }
        }
        else if (distHitForward > 0)
        {
            Vector2 position = transform.position;
            position.x -= speed * Time.deltaTime;
            transform.position = position;
            distHitForward -= Time.deltaTime;
            if (distHitForward <= 0)
            {
                getHitAnimationPlay = false;
            }
        }
    }

    private void PlayAttackAnimation()
    {
        if (distAttackForward > 0)
        {
            Vector2 position = transform.position;
            position.x -= speed * Time.deltaTime;
            transform.position = position;
            distAttackForward -= Time.deltaTime;
        }else if (distAttackBackward > 0)
        {
            Vector2 position = transform.position;
            position.x += speed * Time.deltaTime;
            transform.position = position;
            distAttackBackward -= Time.deltaTime;
            if (distAttackBackward <= 0)
            {
                attacAnimationPlay = false;
                EndAttack();
            }
        }
    }
}
