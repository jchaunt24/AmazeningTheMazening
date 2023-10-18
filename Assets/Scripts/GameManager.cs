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
    public float enemyTimer;

    // Enemt Prefab List
    public GameObject[] enemyPrefabs;
    // Locations for enemy spawn
    void Start()
    {  
        // States what the Original Values are to the player
        health = 100;
        displayScore.text = "Score: " + score;
        displayHealth.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
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
        // Enemy Spawner
        enemyTimer -= Time.deltaTime;
        if(enemyTimer <= 0){
            int enemyIndex = Random.Range(0,enemyPrefabs.Length);
            //Room 1
            Instantiate(enemyPrefabs[enemyIndex],new Vector3(-8,10,0), enemyPrefabs[enemyIndex].transform.rotation);
            // Room 2
            Instantiate(enemyPrefabs[enemyIndex],new Vector3(14,12,0), enemyPrefabs[enemyIndex].transform.rotation);
            // Room 3
            Instantiate(enemyPrefabs[enemyIndex],new Vector3(14,2,0), enemyPrefabs[enemyIndex].transform.rotation);

            // Boss Room 1
            Instantiate(enemyPrefabs[enemyIndex],new Vector3(-4,35,0), enemyPrefabs[enemyIndex].transform.rotation);
            Instantiate(enemyPrefabs[enemyIndex],new Vector3(18,35,0), enemyPrefabs[enemyIndex].transform.rotation);
            Instantiate(enemyPrefabs[enemyIndex],new Vector3(6,25,0), enemyPrefabs[enemyIndex].transform.rotation);
            enemyTimer = 10;
        }
    }

    // Player Health System
    public void UpdateHealth(int healthToChange){
        health = health + healthToChange;
        displayHealth.text = "Health: " + health;
    }

    public void DeathParticiles(Vector3 EnemyPosition){
        
    }

    public void AddScore(int scoreToAdd){
        score = score += scoreToAdd;
    }
}
