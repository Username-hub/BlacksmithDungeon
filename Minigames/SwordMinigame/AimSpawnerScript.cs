using UnityEngine;

namespace Minigames.SwordMinigame
{
    public class AimSpawnerScript : MonoBehaviour
    {
        public GameObject aimPrefab;
        public float thrust;

        public void SpawnAim(float aimAngleMax, float aimAngleMin)
        {
            float aimAngle = Random.Range(aimAngleMax, aimAngleMin);
            GameObject spawnedAim = Instantiate(aimPrefab, transform.parent.transform);
            spawnedAim.transform.position = transform.position;
            Rigidbody2D aimRB = spawnedAim.GetComponent<Rigidbody2D>();
            float x = Mathf.Sqrt(2) * Mathf.Sin(aimAngle * Mathf.Deg2Rad);
            float y = Mathf.Sqrt(2) * Mathf.Cos(aimAngle * Mathf.Deg2Rad);
            Vector2 forceVector = new Vector2(x,y);
            aimRB.AddForce(forceVector * thrust, ForceMode2D.Impulse);
        }
    }
}