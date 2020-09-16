using System.Collections;
using System.Collections.Generic;
using Minigames;
using Minigames.ArcheryMinigame;
using TMPro;
using UnityEngine;

public class ArcheryMinigameScript : MinigameBase
{
    public TextMeshProUGUI pointCount;

    public GameObject aimPrefab;

    private GameObject aim;
    private ArrowAim arrowAim;

    public GameObject sight;
    // Start is called before the first frame update
    void Start()
    {
        MinigameStart(minigameManager);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0)
        {
            EndGame();
        }
        if(Input.touchCount > 0)
        {
            sight.transform.position = Input.GetTouch(0).position;
        }

    }

    public override void MinigameStart(MinigameManager minigameManager)
    {
        aim = Instantiate(aimPrefab, transform);
        aim.transform.SetAsFirstSibling();
        arrowAim = aim.GetComponent<ArrowAim>();
        arrowAim.text = pointCount;
    }

    private void EndGame()
    {
        
    }
}
