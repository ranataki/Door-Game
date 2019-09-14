using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public bool gameOver;
    public bool gameStart;

    public float score;
    public float highscore;

    public Guy guy;
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
 
        if (gameStart)
        {
            Debug.Log(gameStart);
            gameOver = false;
            IncrementScore();

            if (enemy.touchingTarget)
            {
                Debug.Log("GameOver");
                gameOver = true;
                gameStart = false;
            }
        }
        if (gameOver)
        {
            //cancel increment score function
        }
    }

    public void IncrementScore()
    {
        if (guy.touchingTarget)
        {
            score += 1;
            Debug.Log("Increasing score");
            Debug.Log(score);
        }
    }
}
