using UnityEngine;
using UnityEngine.UI;

namespace Minigames
{
    public class MinigameManager : MonoBehaviour
    {
        public GameManager GameManager;
        public GameObject weaponChoosePanel;
        public MinigameList minigameList;
        
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
            game1 = minigameList.GetRandomMinigameBase();
            button1.sprite = game1.WeaponSprite;
            game2 = minigameList.GetRandomMinigameBase();
            button2.sprite = game2.WeaponSprite;
            game3 = minigameList.GetRandomMinigameBase();
            button3.sprite = game3.WeaponSprite;
        }
        
        public void StartMinigame(GameObject gameObject)
        {
            weaponChoosePanel.SetActive(false);
            gameObject.SetActive(true);
            MinigameBase minigameBase = gameObject.GetComponent<MinigameBase>();
            minigameBase.MinigameStart(this);
        }
        public void MinigameEnd(int damage)
        {
            
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