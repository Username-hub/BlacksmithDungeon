using System;
using System.Collections;
using System.Collections.Generic;
using Minigames;
using TMPro;
using UnityEngine;

public class HammerMinigameScript : MinigameBase
{
    private float timeLeft;
    public float currentPower;
    public float maxPower;
    public float powerAdd = 0.1f;
    public float declineMultiplier;
    public Transform hammerTransform;
    public TextMeshProUGUI pointCount;

    public void Update()
    {
        //timer
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            EndGame();
        }

        //chek for touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                currentPower += powerAdd;
            }
        }

        //decline over time
        currentPower -= Time.deltaTime * declineMultiplier;
        
        // max and min
        if (currentPower < 0)
        {
            currentPower = 0;
        }else if (currentPower > maxPower)
        {
            currentPower = maxPower;
        }

        pointCount.text = currentPower.ToString();
        hammerTransform.eulerAngles = new Vector3(0,0,(currentPower/maxPower) * 180);
    }

    public void DebugAddPower()
    {
        currentPower += powerAdd;
    }

    public override void MinigameStart(MinigameManager minigameManager)
    {
        this.minigameManager = minigameManager;
        timeLeft = gameTimer;
        currentPower = 0;
    }

    private void EndGame()
    {
        minigameManager.MinigameEnd((int) currentPower);
        Destroy(gameObject);
    }
}
