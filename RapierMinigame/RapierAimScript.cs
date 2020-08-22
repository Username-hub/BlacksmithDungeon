using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RapierAimScript : MonoBehaviour
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
        Vector2 position = transform.position;
        position.x = Random.Range(-maxX, maxX);
        position.y = Random.Range(-maxY, maxY);
        transform.position = position;
    }

    private void AimHit()
    {
        rapierMinigameScript.AimHit();
        SetNewPosition();
    }
    private void Update()
    {
        if (Input.touchCount >= 1)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray.origin, ray.direction, out raycastHit))
            {
                if (raycastHit.collider.gameObject == this.gameObject)
                {
                    
                }
            }
        }
    }
}
