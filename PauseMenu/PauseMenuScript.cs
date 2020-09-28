using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject gameManager;

    public void PauseCalled()
    {
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    public void ResumeButtonPressed()
    {
        gameManager.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void SettingButtonPressed()
    {
        
    }

    public void QuitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
