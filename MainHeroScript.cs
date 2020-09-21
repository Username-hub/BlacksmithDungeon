using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHeroScript : MonoBehaviour
{

    public int maxHealth = 5;
    public int health;


    public GameManager gameManager;
    public Image healthBar;
    
    private void Start()
    {
        health = maxHealth;
    }

    public int TakeDamage(int damage)
    {
        SetupGetHitAnimation();
        health -= damage;
        healthBar.fillAmount = (float) health / maxHealth;
        return health;
    }
    
    
    
    private bool attacAnimationPlay = false;
    private bool getHitAnimationPlay = false;
    
    public float pushTime = 0.4f;
    public float speed = 2;
    private float distHitBackward;
    private float distHitForward;
    
    private void SetupGetHitAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        distHitBackward = pushTime / 2;
        distHitForward = pushTime / 2;
        getHitAnimationPlay = true;
    }
    
    private void EndOfMoveBackAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    public void StartAttack()
    {
        SetupAttackAnimation();
    }

    private void EndAttack()
    {
        gameManager.EndOfHeroAnimation();
    }
    private float distAttackBackward;
    private float distAttackForward;
    private void SetupAttackAnimation()
    {
        distAttackBackward = pushTime / 2;
        distAttackForward = pushTime / 2;
        attacAnimationPlay = true;
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
            position.x -= speed * Time.deltaTime;
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
            position.x += speed * Time.deltaTime;
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
            position.x += speed * Time.deltaTime;
            transform.position = position;
            distAttackForward -= Time.deltaTime;
        }else if (distAttackBackward > 0)
        {
            Vector2 position = transform.position;
            position.x -= speed * Time.deltaTime;
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
