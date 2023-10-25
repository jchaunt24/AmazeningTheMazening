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
    public GameObject gameDisplay;
    public GameObject gameTitle;
    // Enemt Prefab List
    public GameObject[] enemyPrefabs;
    public GameObject[] drops;

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
            displayHealth.text = "Health: " + health;
            Timer -= Time.deltaTime;
            displayScore.text = "Score: " + score;
            if (Timer <= 0f)
            {
                Timer = 1.5f;
                if(health < 1){
                    gameOver.SetActive(true);
                }
            }
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
    
    // Pause and title Screen
    public void Pause(){
        gamePaused = true;
        gameDisplay.SetActive(false);
        gameTitle.SetActive(true);
    }
    public void Play(){
        gamePaused = false;
        gameDisplay.SetActive(true);
        gameTitle.SetActive(false);
    }
    public void DropItem(Transform transform){
        int randomItemNumber = Random.Range(0,1);
        Instantiate(drops[randomItemNumber],transform.position, drops[randomItemNumber].transform.rotation);
    }
}
