using UnityEngine;

namespace Minigames
{
    public class MinigameList : MonoBehaviour
    {
        public GameObject rapierMinigame;
        public MinigameObject rapierObject;

        public GameObject archeryMinigame;
        public MinigameObject archeryObject;
        public MinigameObject GetRandomMinigameBase()
        {
            int randNum = Random.Range(1, 3);
            switch (randNum)
            {
                case 1:
                    return rapierObject;
                case 2:
                    return archeryObject;
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
                case 2:
                    return archeryMinigame;
                default:
                    return rapierMinigame;
            }
        }
    }
}