using System;
using UnityEngine;

namespace Minigames.SwordMinigame
{
    public class AimPartScript : MonoBehaviour
    {
        public float lifeTimer;

        private void Update()
        {
            lifeTimer -= Time.deltaTime;
            if(lifeTimer <= 0)
                Destroy(gameObject);
        }
    }
}