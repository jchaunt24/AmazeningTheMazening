using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDropItem
{
/*
    Name: Jacob Chaunt          ID: 18912
    Teacher: Mrs. Boscombe
    Date: 9/21/23
    Project: Movement
*/
    // Start is called before the first frame update

    // Score Counter Display
    public static int score;
    public TextMeshProUGUI displayScore;
    public Vector3 savedTransform;

    // Health Counter Display 
    public static float health;
    public bool damageCooldown = false;
    int savedHealth;
    float damageCountdown;
    public GameObject player;
    public Image HealthBar;
    //public static GameManager Instance;

    // Gamer Over and Enemy Spawning
    public GameObject gameOver;
    public float Timer;
    public GameObject gameDisplay;
    public GameObject gameTitle;
    public GameObject gameControls;
    public GameObject exitButton;
    public GameObject playButton;
    public GameObject controlButton;
    public string gameScene;
    public bool dying;
    // Enemt Prefab List
    public GameObject[] enemyPrefabs;
    public GameObject[] drops;
    

    // Game Paused
    public bool gamePaused = false; 
    public static bool Loaded = false;
    
    void Start()
    {  
        // States what the Original Values are to the player
        health = 25;
        displayScore.text = "Score: " + score;
        if(gameScene == "TheMaze"){
            gamePaused = true;
            Debug.Log("TheMaze");
        }
        else{
            gamePaused = false;
            Debug.Log("Other");
        }
        if(Loaded){
            gameDisplay.SetActive(true);
            gameTitle.SetActive(false);
            gamePaused = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = health / 50; 
        
        if(gamePaused == false){
            // Score Counter and Game Over Timer
            displayScore.text = "Score: " + score;  
            if(health < 1){
                gamePaused = true;
                StartCoroutine(GameOverAnim());
            }
        }
    }
    // Player Gameover Animation
    IEnumerator GameOverAnim(){
        dying = true;
        
        yield return new WaitForSeconds(8);
        gameOver.SetActive(true);
        
    }

    // Player Health System
    public void UpdateHealth(int healthToChange){
        health = health + healthToChange;
        health = Mathf.Clamp(health, 0, 50);
        HealthBar.fillAmount = health / 50; 

    }
    public void AddScore(int scoreToAdd){
        score = score += scoreToAdd;
    }
    // Pause and title Screen
    public void Pause(){
        gamePaused = true;
        gameDisplay.SetActive(false);
        gameTitle.SetActive(true);
        gameControls.SetActive(false);
        exitButton.SetActive(true);
        playButton.SetActive(true);
        controlButton.SetActive(true);
    }
    public void Play(){
        gamePaused = false;
        gameDisplay.SetActive(true);
        gameTitle.SetActive(false);
        Loaded = true;
    }
    public void Controls(){
        gameControls.SetActive(true);
        exitButton.SetActive(false);
        playButton.SetActive(false);
        controlButton.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }
    public void Restart(){
        health = 25;
        HealthBar.fillAmount = health / 50; 
        score = 0;
        Loaded = false;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

   /* public void DropItem(Transform transform){
        int randomItemNumber = Random.Range(0,2);
        Debug.Log(randomItemNumber);
        Instantiate(drops[randomItemNumber],transform.position, drops[randomItemNumber].transform.rotation);
        Debug.Log("Item Dropped");
        
    }*/

    public void DropItem(Vector3 position){
        int randomItemNumber = Random.Range(0,2);
        Debug.Log(randomItemNumber);
        Instantiate(drops[randomItemNumber], position, drops[randomItemNumber].transform.rotation);
        Debug.Log("Item Dropped");
        
    }
    public void Teleport(string nextScene){
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
