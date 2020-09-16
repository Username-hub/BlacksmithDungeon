using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Image timerBar;
    // Start is called before the first frame update
    void Start()
    {
        //timeLeft = 0;
    }

    private float mingameTime;

    private float timeLeft;

    public void StartTimer(float time)
    {
        mingameTime = time;
        timeLeft = mingameTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            timerBar.fillAmount =  (mingameTime - timeLeft) / mingameTime;
        }
    }
}
