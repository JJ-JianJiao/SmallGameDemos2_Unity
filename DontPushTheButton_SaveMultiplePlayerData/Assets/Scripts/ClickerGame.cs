using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerGame : MonoBehaviour
{
    public Text instructionText;
    public Text scoreText;
    public Button doneButton;

    int score;

    float timestamp;
    float timeDelay;

    bool gameStart;
    bool gameDone;

    // Use this for initialization
    void Start()
    {
        score = 0;
        timestamp = Time.time;
        timeDelay = 3.0f;
        gameStart = false;
        gameDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timestamp + timeDelay && !gameStart)
        {
            instructionText.text = "GO!!!";
            gameStart = true;
            timeDelay = 10f;
            timestamp = Time.time;
        }

        if (gameStart)
        {
            if (Time.time < timestamp + timeDelay)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    score++;
                    scoreText.text = "Score: " + score;
                }
            }
            else
            {
                if (!gameDone)
                {
                    instructionText.text = "Finished!!!";
                    doneButton.gameObject.SetActive(true);
                    gameDone = true;

                }                
            }
        }
    }

    public void FinishGame()
    {
        GetComponent<Spawner>().SaveScore(score);
    }
}
