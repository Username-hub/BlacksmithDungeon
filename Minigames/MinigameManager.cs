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
            game2 = minigameBases[1];
            button2.sprite = game2.WeaponSprite;
            game3 = minigameBases[2];
            button3.sprite = game3.WeaponSprite;
        }
        
        public void StartMinigame(GameObject gameObject)
        {
            weaponChoosePanel.SetActive(false);
            gameObject.SetActive(true);
            MinigameBase minigameBase = gameObject.GetComponent<MinigameBase>();
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
                    StartMinigame(minigameList.GetMinigamePanelById(game1.minigameId));
                    break;
                case 2:
                    StartMinigame(minigameList.GetMinigamePanelById(game2.minigameId));
                    break;
                case 3:
                    StartMinigame(minigameList.GetMinigamePanelById(game3.minigameId));
                    break;
                default:
                    StartMinigame(minigameList.GetMinigamePanelById(game1.minigameId));
                    break;
            }
        }
    }
}