using System;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopController : MonoBehaviour
    {
        public UpperPanelScript upperPanelScript;
        public GameList gameList;
        public GameSaveData gameSaveData;
        public GameObject panelPrefab;
        public GameObject scrollPanel;
        public float shopPanelOffset = 5.0f;
        private int goldAmount;
        private void Start()
        {
            gameSaveData = SaveSystem.LoadProgress();
            goldAmount = gameSaveData.gold;
            SetUpPanels();
            upperPanelScript.SetupUpperPanel(goldAmount);
        }

        public void itemBouth(int goldChange)
        {
            goldAmount -= goldChange;
            Debug.Log(goldAmount.ToString() + " / " + goldChange.ToString());
            upperPanelScript.SetupUpperPanel(goldAmount);
            SaveSystem.SaveProgress(goldAmount, gameSaveData.lvl, gameSaveData.XP);
        }

        public int GetGold()
        {
            return goldAmount;}

        private Vector2 nextAnchordPos;
        private float totalHight;
        public ScrollRect scrollRect;
        private void SetUpPanels()
        {
            nextAnchordPos = new Vector2(0,0);
            int len = gameList.gameObjectsList.Length;
            
            //resize panel
            totalHight = 0;//len * 617.0f;//panelPrefab.GetComponent<RectTransform>().rect.height;
            
            
            for (int i = 0; i < len; i++)
            {
                GameObject spawnedGame = Instantiate(panelPrefab, scrollPanel.transform);
                RectTransform spawnedRect = spawnedGame.GetComponent<RectTransform>();
                spawnedRect.anchoredPosition = nextAnchordPos;
                nextAnchordPos += Vector2.down * (spawnedRect.rect.height + shopPanelOffset);
                totalHight += (spawnedRect.rect.height + shopPanelOffset);
                
                ShopPanelScript shopPanelScript = spawnedGame.GetComponent<ShopPanelScript>();
                shopPanelScript.SetUpShopPanel(this,gameList.gameObjectsList[i],gameSaveData.gold);
                
            }
            if (scrollPanel.GetComponent<RectTransform>().rect.height < Mathf.Abs(totalHight))
            {
                scrollPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollPanel.GetComponent<RectTransform>().sizeDelta.x, totalHight + 20.0f);
            }

            scrollRect.verticalNormalizedPosition = 1.0f;

        }
    }
}