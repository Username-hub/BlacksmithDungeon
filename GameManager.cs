﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public EnemySpawnerScript enemySpawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerScript.SpawnEnemy(1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CallWeaponChoseScreen()
    {
        
    }
}
