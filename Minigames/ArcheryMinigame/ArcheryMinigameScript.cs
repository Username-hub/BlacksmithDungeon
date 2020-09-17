using System.Collections;
using System.Collections.Generic;
using Minigames;
using Minigames.ArcheryMinigame;
using TMPro;
using UnityEngine;

public class ArcheryMinigameScript : MinigameBase
{
    public float offsetX = -10;
    public float offsetY = 10;
    public TextMeshProUGUI pointCount;

    public GameObject aimPrefab;

    private GameObject aim;
    private ArrowAim arrowAim;

    public GameObject sight;
    // Start is called before the first frame update
    private float timeLeft;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            EndGame();
        }
        if(Input.touchCount > 0)
        {
            Vector2 position = Input.GetTouch(0).position;
            position.x += offsetX;
            position.y += offsetY;
            sight.transform.position = position;
        }

    }

    public override void MinigameStart(MinigameManager minigameManager)
    {
        timeLeft = gameTimer;
        aim = Instantiate(aimPrefab, transform);
        aim.transform.SetAsFirstSibling();
        arrowAim = aim.GetComponent<ArrowAim>();
        arrowAim.text = pointCount;
    }

    private void EndGame()
    {
        int damage = arrowAim.StopAim();
        Destroy(arrowAim.gameObject);
        minigameManager.MinigameEnd(damage);
        gameObject.SetActive(false);
    }
}
