using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public GameManager gm;
    public float scrollSpeed = 1;
    public float scrollTime = 1.1f;
    
    public Renderer wall;

    public float currentMoveTime;
    
    // Start is called before the first frame update
    public void StartMove(Transform enemyTransform)
    {
        enemy = enemyTransform;
        currentMoveTime = scrollTime;
    }

    public float scrollBackDist = 2;
    // Update is called once per frame
    private float moveDist = 0;
    private Transform enemy;
    void Update()
    {
        if (currentMoveTime > 0)
        {
            //Move wall
            Vector2 position = wall.transform.position;
            position.x -= scrollSpeed * Time.deltaTime;
            moveDist += Mathf.Abs(position.x - wall.transform.position.x);
            wall.transform.position = position;
            
            
            //move enemy
            Vector2 enemyPos = enemy.position;
            enemyPos.x -= scrollSpeed * Time.deltaTime;
            enemy.position = enemyPos;
            
            if (moveDist >= scrollBackDist)
            {
                wall.transform.position = new Vector2(position.x + moveDist, position.y);
                moveDist = 0;
            }
            currentMoveTime -= Time.deltaTime;
            if (currentMoveTime <= 0)
            {
                //
                gm.EndOfBackgroundMove();
            }
        }
        
    }
}
