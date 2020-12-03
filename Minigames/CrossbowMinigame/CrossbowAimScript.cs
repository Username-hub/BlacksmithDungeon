using System;
using UnityEngine;

namespace Minigames.CrossbowMinigame
{
    public class CrossbowAimScript : MonoBehaviour
    {
        public CrossbowMinigameScript crossbowMinigameScript;
        private void OnTriggerEnter2D(Collider2D other)
        {
            CrossbowBoltScript crossbowBoltScript = other.GetComponent<CrossbowBoltScript>();
            if (crossbowBoltScript != null)
            {
                Destroy(other.gameObject);
                crossbowMinigameScript.AimGetHit();
                Destroy(gameObject);
            }
        }
    }
}