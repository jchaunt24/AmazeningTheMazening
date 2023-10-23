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

    // Score Counter Display
    public int score;
    public TextMeshProUGUI displayScore;

    // Health Counter Display 
    public int health;
    public TextMeshProUGUI displayHealth;

    // Gamer Over and Enemy Spawning
    public GameObject gameOver;
    public float Timer;
    public GameObject game
    // Enemt Prefab List
    public GameObject[] enemyPrefabs;

    // Game Paused
    public bool gamePaused = false; 

    void Start()
    {  
        // States what the Original Values are to the player
        health = 100;
        displayScore.text = "Score: " + score;
        displayHealth.text = "Health: " + health;
        gamePaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePaused == false){
            // Score Counter and Game Over Timer
            Timer -= Time.deltaTime;
            displayScore.text = "Score: " + score;
            if (Timer <= 0f)
            {
                health -= 1;
                Timer = 1.5f;
                if(health < 1){
                    gameOver.SetActive(true);
                }

            }
        }
        else{

        }
        
    }

    // Player Health System
    public void UpdateHealth(int healthToChange){
        health = health + healthToChange;
        displayHealth.text = "Health: " + health;
    }


    public void AddScore(int scoreToAdd){
        score = score += scoreToAdd;
    }
}
