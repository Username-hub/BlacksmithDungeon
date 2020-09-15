using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHeroScript : MonoBehaviour
{

    public int maxHealth = 5;
    public int health;
    
    

    public Image healthBar;

    private void Start()
    {
        health = maxHealth;
    }

    public int TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = (float) health / maxHealth;
        return health;
    }
}
