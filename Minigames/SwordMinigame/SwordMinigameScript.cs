using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Minigames.SwordMinigame
{
    public class SwordMinigameScript : MinigameBase
    {
        public float aimAngleMax;
        public float aimAngleMin;
        public AimSpawnerScript aimSpawnerScriptLeft;
        public AimSpawnerScript aimSpawnerScriptRight;
        public TextMeshProUGUI pointCount;

        public float aimCallDawn;
        public float toNextAim;
        private int points;
        private float timeLeft;
        public GameObject swordPrefab;
        private GameObject swordObject;
        private void Update()
        {
            timeLeft -= Time.deltaTime;
            toNextAim -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                EndGame(points);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    swordObject = Instantiate(swordPrefab, transform.position,Quaternion.identity,transform);
                    swordObject.GetComponent<SwordScript>().minigameBase = this;
                    swordObject.transform.position = touch.position;
                }else if (touch.phase == TouchPhase.Moved)
                {
                    swordObject.transform.position = touch.position;
                }else if (touch.phase == TouchPhase.Ended)
                {
                    Destroy(swordObject);
                }
            }

            if (toNextAim <= 0)
            {
                SpawnAim();
                toNextAim = aimCallDawn;
            }
            
        }

        public void AimGetHit()
        {
            points++;
            pointCount.text = points.ToString();
            toNextAim -= 1.0f;
        }
        

        public override void MinigameStart(MinigameManager minigameManager)
        {
            this.minigameManager = minigameManager;
            points = 0;
            timeLeft = gameTimer;
            toNextAim = aimCallDawn;
            SpawnAim();
        }

        private void SpawnAim()
        {
            int x = Random.Range(0,2);
            if (x == 0)
            {
                aimSpawnerScriptLeft.SpawnAim(aimAngleMax, aimAngleMin);
            }
            else
            {
                aimSpawnerScriptRight.SpawnAim(-aimAngleMax, -aimAngleMin);
            }
        }
        private void EndGame(int damage)
        {
            minigameManager.MinigameEnd(damage);
            Destroy(gameObject);
        }
    }
}