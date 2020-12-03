using System.Collections.Generic;
using UnityEngine;

namespace Minigames
{
    public class MinigameList : MonoBehaviour
    {
        [SerializeField] public GameObject[] gameList;
        [SerializeField] public MinigameObject[] gameObjectDataList;

        public List<MinigameObject> Get3RandomMinigameBase()
        {
            List<MinigameObject> result = new List<MinigameObject>();

            List<int> numbersToChose =new List<int>();
            for (int i = 0; i < gameObjectDataList.Length; i++)
            {
                numbersToChose.Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                int num = numbersToChose[Random.Range(0, numbersToChose.Count - 1)];
                
                result.Add(gameObjectDataList[num]);

                numbersToChose.Remove(num);
            }
            return result;
        }
        public GameObject GetMinigamePanelById(int id)
        {
            return gameList[id - 1];
        }
    }
}