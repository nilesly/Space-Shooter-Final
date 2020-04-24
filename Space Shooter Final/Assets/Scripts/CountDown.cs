using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private GameController gameController;

    public int timeLimit = 1;
    public float timeLeft;
    public Text timeText;

    private float seconds;

    void Awake()
        {
            timeLeft = 30f;
        }

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }


    void Update()
    {
        if (timeLeft <= 0)
        {
            // Game over!
            gameController.gameover = true;
            gameController.GameOver();
        }

        timeLeft -= Time.deltaTime;

        UpdateTime();
    }

    public void UpdateTime()
    {
        seconds = timeLeft % 30;

        timeText.text = "Time Remaing: " + seconds; 
    }
}
