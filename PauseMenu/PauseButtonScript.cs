using UnityEngine;

namespace PauseMenu
{
    public class PauseButtonScript : MonoBehaviour
    {
        public GameObject pauseMenuPanel;
        
        public void PauseButtonPressed()
        {
            pauseMenuPanel.SetActive(true);
            pauseMenuPanel.GetComponentInChildren<PauseMenuScript>().PauseCalled();
        }
    }
}