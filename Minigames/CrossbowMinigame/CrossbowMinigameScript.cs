using System;
using UnityEngine;

namespace Minigames.CrossbowMinigame
{
    public class CrossbowMinigameScript : MinigameBase
    {
        public float rotationSpeed;
        public GameObject crossBow;
        public Transform shootPoint;
        public GameObject boltPrefab;

        public int aimsToSpawn;
        public AimSpawnerScript aimSpawnerScript;
        private float timeLeft;
        private int points;
        private int direction;
        
        private void Start()
        {
            direction = 1;
            points = 0;
            timeLeft = gameTimer;
            aimSpawnerScript.spawnAims(aimsToSpawn);
        }

        private void Update()
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
                EndGame(points);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    ShootBolt();
                }
            }

            if (crossBow.transform.eulerAngles.z >= 180.0f || crossBow.transform.eulerAngles.z <= 0) direction *= -1;
            
            crossBow.transform.eulerAngles =new Vector3(0, 0, crossBow.transform.eulerAngles.z + (direction * rotationSpeed * Time.deltaTime));
        }
        public void ShootBolt()
        {
            Instantiate(boltPrefab, shootPoint.position, shootPoint.rotation,gameObject.transform);
            
        }
        public void AimGetHit()
        {
            points++;
        }
        public override void MinigameStart(MinigameManager minigameManager)
        {
            this.minigameManager = minigameManager;
            points = 0;
            timeLeft = gameTimer;
        }

        private void EndGame(int damage)
        {
            minigameManager.MinigameEnd(damage);
            Destroy(gameObject);
        }
    }
}