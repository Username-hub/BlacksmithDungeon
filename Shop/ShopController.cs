using System;
using SaveLoadSystem;
using UnityEngine;

namespace Shop
{
    public class ShopController : MonoBehaviour
    {
        public GameList gameList;
        public GameSaveData gameSaveData;
        public GameObject panelPrefab;
        public GameObject leftPanel;
        private void Start()
        {
            gameSaveData = SaveSystem.LoadProgress();
            SetUpPanels();
        }

        
        private void SetUpPanels()
        {
            int len = gameList.gameObjectsList.Length;
            for (int i = 0; i < len; i++)
            {
                GameObject spawnedGame = Instantiate(panelPrefab, leftPanel.transform);
                ShopPanelScript shopPanelScript = spawnedGame.GetComponent<ShopPanelScript>();
                shopPanelScript.SetUpShopPanel(this,gameList.gameObjectsList[i],gameSaveData.gold);
            }
        }
    }
}