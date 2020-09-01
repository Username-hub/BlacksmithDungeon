using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Minigames.ArcheryMinigame
{
    public class ArrowAim : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        public float speed = 5.0f;
        private float timeInAim = 0;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.AddForce(new Vector2(speed,speed), ForceMode2D.Impulse);
        }

        private void Update()
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            timeInAim += Time.deltaTime;
        }

        public int StopAim()
        {
            return (int) timeInAim;
        }
    }
}