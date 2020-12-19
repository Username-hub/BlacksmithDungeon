using System.Collections;
using System.Collections.Generic;
using Shop;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpperPanelScript : MonoBehaviour
{
    public TextMeshProUGUI goldCount;
    // Start is called before the first frame update
    public void SetupUpperPanel(int gold)
    {
        goldCount.text = gold.ToString();
    }
    public void PressedBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
