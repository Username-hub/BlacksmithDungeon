using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RapierMinigameScript : MonoBehaviour
{
    public float GameTimer = 3.0f;
    private float TimeLeft;

    private void Update()
    {
        TimeLeft -= Time.deltaTime;
    }

    public GameObject rapierAimPrefab;
    private GameObject rapierAim;

    public TextMeshProUGUI pointDisplay;
    private int pointCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
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
    private void EndMiniGame()
    {
        
    }
}
