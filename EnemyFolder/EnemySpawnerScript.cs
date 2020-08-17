using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public EnemyList enemyList;
    public GameObject enemyObject;
    

    public void SpawnEnemy(int minLevel, int maxLevel)
    {
        GameObject enemyInstantiate = Instantiate(enemyObject, transform.position, Quaternion.identity);
        EnemyScript enemyScript = enemyInstantiate.GetComponent<EnemyScript>();
        enemyScript.InitializeEnemy(enemyList.Slime);


    }
}
