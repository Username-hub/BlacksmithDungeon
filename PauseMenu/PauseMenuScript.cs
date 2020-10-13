using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject gameManagerObj;
    public void PauseCalled()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    public void ResumeButtonPressed()
    {
        Time.timeScale = 1;
        gameManagerObj.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void SettingButtonPressed()
    {
        
    }

    public void QuitButtonPressed()
    {
        gameManagerObj.SetActive(true);
        Time.timeScale = 1;
        gameManagerObj.GetComponent<GameManager>().EndRun();
    }
}
