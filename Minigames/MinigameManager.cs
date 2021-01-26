using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Minigames
{
    public class MinigameManager : MonoBehaviour
    {
        public GameManager GameManager;
        public GameObject weaponChoosePanel;
        public MinigameList minigameList;
        public GameObject timer;
        public Image button1;
        private MinigameObject game1;
        public Image button2;
        private MinigameObject game2;
        public Image button3;
        private MinigameObject game3;

        private GameObject currentMiniGame;
        public void  StartMinigameManager()
        {
            weaponChoosePanel.SetActive(true);
            StartButtons();
        }

        private void StartButtons()
        {
            List<MinigameObject> minigameBases = minigameList.Get3RandomMinigameBase();
            game1 = minigameBases[0];
            button1.sprite = game1.WeaponSprite;
            button1.SetNativeSize();
            
            game2 = minigameBases[1];
            button2.sprite = game2.WeaponSprite;
            button2.SetNativeSize();
            
            game3 = minigameBases[2];
            button3.sprite = game3.WeaponSprite;
            button3.SetNativeSize();
        }
        
        public void StartMinigame(GameObject gameObjectPrefab)
        {
            weaponChoosePanel.SetActive(false);
            GameObject spawnGame = Instantiate(gameObjectPrefab, gameObject.transform);
            spawnGame.transform.SetSiblingIndex(1);
            MinigameBase minigameBase = spawnGame.GetComponent<MinigameBase>();
            minigameBase.MinigameStart(this);
            timer.SetActive(true);
            timer.GetComponent<TimerScript>().StartTimer(minigameBase.gameTimer);
        }
        public void MinigameEnd(int damage)
        {
            GameManager.EndOfHeroAttack(damage);
            timer.SetActive(false);
        }

        public void ButtonPressed(int button)
        {
            switch (button)
            {
                case 1:
                    StartMinigame(minigameList.GetMinigamePrefabById(game1.minigameId));
                    break;
                case 2:
                    StartMinigame(minigameList.GetMinigamePrefabById(game2.minigameId));
                    break;
                case 3:
                    StartMinigame(minigameList.GetMinigamePrefabById(game3.minigameId));
                    break;
                default:
                    StartMinigame(minigameList.GetMinigamePrefabById(game1.minigameId));
                    break;
            }
        }
    }
}