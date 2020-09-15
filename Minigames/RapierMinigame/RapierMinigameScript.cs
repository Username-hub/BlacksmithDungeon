using System;
using System.Collections;
using System.Collections.Generic;
using Minigames;
using TMPro;
using UnityEngine;

public class RapierMinigameScript : MinigameBase
{
    public float GameTimer = 3.0f;
    private float TimeLeft;

    private void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            EndGame(pointCount);
        }
    }

    public GameObject rapierAimPrefab;
    private GameObject rapierAim;

    public TextMeshProUGUI pointDisplay;
    private int pointCount = 0;

    public override void MinigameStart(MinigameManager gameManager)
    {
        this.minigameManager = gameManager;
        pointCount = 0;
        TimeLeft = GameTimer;
        rapierAim = Instantiate(rapierAimPrefab, transform);
        RapierAimScript rapierAimScript = rapierAim.GetComponent<RapierAimScript>();
        rapierAimScript.rapierMinigameScript = this;
    }

    public void AimHit()
    {
        pointCount++;
        pointDisplay.text = pointCount.ToString();
    }
    void EndGame(int damage)
    {
        Destroy(rapierAim);
        minigameManager.MinigameEnd(damage);
        gameObject.SetActive(false);
    }
}
