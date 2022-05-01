using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreGameText;
    public GameObject playerIsAlive;

    public Text currentScore;
    public Text highScore;
    private int savescore;

    private float initializeScore;

    private float scoreIncrement;

    private float increment;

    private bool time;
    private bool isAlive;
    private bool lastIfScore;

    private void Awake()
    {
        time = true;
        lastIfScore = true;
    }


    private void Start()
    {
        initializeScore = 0f;
        scoreIncrement = 10f;
        increment = 0f;
        highScore.text = PlayerPrefs.GetString("HighScore", "00");
    }

    private void Update()
    {
        isAlive = playerIsAlive;
        if(isAlive)
        {
            scoreGameText.text = (int)initializeScore + "";
            initializeScore += scoreIncrement * Time.deltaTime;

            if (initializeScore >= increment)
                time = true;

            if (time)
            {
                scoreIncrement += 10f;
                increment += 400f;
                time = false;
            }
        }
        else if(lastIfScore && !(isAlive))
        {
            currentScore.text = scoreGameText.text;
            Destroy(playerIsAlive);
            lastIfScore = false;

            savescore = int.Parse(currentScore.text);


            if (savescore > int.Parse(PlayerPrefs.GetString("HighScore","00")))
            {
                PlayerPrefs.SetString("HighScore", currentScore.text);
                highScore.text = currentScore.text;
            }

            

        }
        
    }
}
