using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Minigames.CrossbowMinigame
{
    public class CrossbowBoltScript : MonoBehaviour
    {
        private float timeUntilDestroy = 5.0f;
        private float timer;
        public float speed = 100.0f;
        private void Start()
        {
            timer = 0;
            GetComponent<Rigidbody2D>().AddForce(transform.up * speed,ForceMode2D.Impulse);
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= timeUntilDestroy)
            {
                Destroy(gameObject); 
            }
        } 
    }
}