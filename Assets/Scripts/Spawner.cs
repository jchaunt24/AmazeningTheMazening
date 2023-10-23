using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Pause Features
    private GameManager gameManager;
    // Location
    Vector3 spawnerPosition;
    // List of Enemies the spawner can spawn
    public GameObject[] enemyPrefabs;
    // Timer to keep track of when enemies last spawned
    public float timer;
    // Time Between spawning the enemies
    public float spawnTime;
    

    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameManager.gamePaused == false){
            // Finds the spawner position
            spawnerPosition = transform.position;
            // Timer to spawn the enemies
            timer += Time.deltaTime;
            if(timer >= spawnTime){
                // Calculations for where the enemy will spawn, on what side of the spawner
                int enemySpawnRandimizerOne = Random.Range(0,1);
                int enemySpawnRandimizerTwo = Random.Range(0,1);
                // Decides which enemy on the list to spawn
                int enemyIndex = Random.Range(0,enemyPrefabs.Length);

                // Offsets on where the enemy will spawn
                Vector3 offset = new Vector3(0,0,0);
                if(enemySpawnRandimizerOne == 1){
                    offset.y = 1;
                }
                else{
                    offset.y = -1;
                }
                // Spawn Enemies
                Instantiate(enemyPrefabs[enemyIndex],spawnerPosition + offset, enemyPrefabs[enemyIndex].transform.rotation);
                
                if(enemySpawnRandimizerTwo == 1){
                    offset.x = 1;
                }
                else{
                    offset.x = -1;
                }
                // Spawn Enemies
                Instantiate(enemyPrefabs[enemyIndex],spawnerPosition + offset, enemyPrefabs[enemyIndex].transform.rotation);
                timer = 0;
            }

        }
    }
}
