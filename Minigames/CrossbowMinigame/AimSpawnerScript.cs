using UnityEngine;

namespace Minigames.CrossbowMinigame
{
    public class AimSpawnerScript : MonoBehaviour
    {
        public float radius;
        public float minAngle;
        public float maxAngle;
        public GameObject aimPrefab;
        public CrossbowMinigameScript crossbowMinigameScript;
        public void spawnAims(int count)
        {
            for (int i = 0; i < count; i++)
            {
                spawnAim();
            }
        }

        private void spawnAim()
        {
            float angle = Random.Range(minAngle, maxAngle);
            GameObject aimObj = Instantiate(aimPrefab, new Vector3(transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle),
                transform.position.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle)), Quaternion.identity, gameObject.transform);
            CrossbowAimScript crossbowAimScript = aimObj.GetComponent<CrossbowAimScript>();
            crossbowAimScript.crossbowMinigameScript = crossbowMinigameScript;
        }
    }
}