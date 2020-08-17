using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int health;
    private string enemyName;

    public void InitializeEnemy(EnemyObject enemyObject)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyObject.enemySprite;
        health = enemyObject.health;
        enemyName = enemyObject.enemyName;
        gameObject.name = enemyName;
        transform.localScale = new Vector3(2,2,1);
    }
}
