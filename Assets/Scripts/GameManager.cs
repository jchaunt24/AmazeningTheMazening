using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
/*
    Name: Jacob Chaunt          ID: 18912
    Teacher: Mrs. Boscombe
    Date: 9/21/23
    Project: Movement
*/
    // Start is called before the first frame update
    public int score;
    public TextMeshProUGUI displayScore;

    public int health;
    public TextMeshProUGUI displayHealth;

    public GameObject gameOver;
    public float Timer;
    void Start()
    {  
        score = 101;
        health = 20;
        displayScore.text = "Score: " + score;
        displayHealth.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            score -= 1;
            displayScore.text = "Score: " + score;
            Timer = 1.5f;
            if(score < 1){
                gameOver.SetActive(true);
            }

        }
    }

    public void UpdateHealth(int healthToChange){
        health = health + healthToChange;
        displayHealth.text = "Health: " + health;
        if(health < 1){
            gameOver.SetActive(true);
        }
    }
}
