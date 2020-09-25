using System.Collections.Generic;
using UnityEngine;

namespace Minigames
{
    public class MinigameList : MonoBehaviour
    {
        public int gamesCount = 3;
        public GameObject rapierMinigame;
        public MinigameObject rapierObject;

        public GameObject archeryMinigame;
        public MinigameObject archeryObject;

        public GameObject hammerMinigame;
        public MinigameObject hammerObject;
        
        public MinigameObject GetMinigameBaseByNum(int num)
        {
            switch (num)
            {
                case 1:
                    return rapierObject;
                case 2:
                    return archeryObject;
                case 3:
                    return hammerObject;
                default:
                    return rapierObject; 
            }
        }
        public List<MinigameObject> Get3RandomMinigameBase()
        {
            List<MinigameObject> result = new List<MinigameObject>();

            List<int> numbersToChose =new List<int>();
            for (int i = 1; i <= gamesCount; i++)
            {
                numbersToChose.Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                int num = numbersToChose[Random.Range(0, numbersToChose.Count - 1)];
                
                result.Add(GetMinigameBaseByNum(num));

                numbersToChose.Remove(num);
            }
            return result;
        }
        public GameObject GetMinigamePanelById(int id)
        {
            switch (id)
            {
                case 1:
                    return rapierMinigame;
                case 2:
                    return archeryMinigame;
                case 3:
                    return hammerMinigame;
                default:
                    return rapierMinigame;
            }
        }
    }
}