using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class RapierAimScript : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public RapierMinigameScript rapierMinigameScript;

    public float maxX = 500;
    public float maxY = 180;

    private void Start()
    {
        SetNewPosition();
    }

    private void SetNewPosition()
    {
        Vector2 position = new Vector2();
        position.x = Random.Range(-maxX, maxX);
        position.y = Random.Range(-maxY, maxY);
        gameObject.GetComponent<RectTransform>().anchoredPosition = position;
    }

    private void AimHit()
    {
        rapierMinigameScript.AimHit();
        SetNewPosition();
    }
    
    private void OnMouseDown()
    {
        AimHit();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AimHit();
    }
}
