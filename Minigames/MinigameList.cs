using UnityEngine;

namespace Minigames
{
    public class MinigameList : MonoBehaviour
    {
        public GameObject rapierMinigame;
        public MinigameObject rapierObject;

        public MinigameObject GetRandomMinigameBase()
        {
            int randNum = Random.Range(1, 2);
            switch (randNum)
            {
                case 1:
                    return rapierObject;
                default:
                    return rapierObject; 
            }
        }

        public GameObject GetMinigamePanelById(int id)
        {
            switch (id)
            {
                case 1:
                    return rapierMinigame;
                default:
                    return rapierMinigame;
            }
        }
    }
}