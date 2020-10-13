using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyObject : ScriptableObject
{
    public string enemyName;
    public Sprite enemySprite;
    public int health;
    public int damage;
    public int reward;
    public int rewardXP;
}
