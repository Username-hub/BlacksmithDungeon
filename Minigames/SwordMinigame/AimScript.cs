using System;
using UnityEngine;

namespace Minigames.SwordMinigame
{
    public class AimScript : MonoBehaviour
    {
        public GameObject upperPart;
        public GameObject lowerPart;
        public float thrust;
        public float lifeTimer;

        private void Update()
        {
            lifeTimer -= Time.deltaTime;
            if (lifeTimer <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            SwordScript swordScript = other.gameObject.GetComponent<SwordScript>();
            if (swordScript != null)
            {
                swordScript.HitAim();
                GameObject UpPart = Instantiate(upperPart,transform.position,Quaternion.identity,transform.parent.transform);
                UpPart.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,-0.5f) * thrust,ForceMode2D.Impulse);
                GameObject LPart = Instantiate(lowerPart,transform.position,Quaternion.identity,transform.parent.transform);
                LPart.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,-0.5f) * thrust,ForceMode2D.Impulse);
                Destroy(gameObject);
                
            }
        }
        
        
    }
}