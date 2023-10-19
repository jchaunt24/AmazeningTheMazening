using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Vector3 spawnerPosition;
    public GameObject[] enemyPrefabs;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnerPosition = transform.position;
        timer += Time.deltaTime;
        if(timer >= 5){
            int enemySpawnRandimizerOne = Random.Range(0,1);
            int enemySpawnRandimizerTwo = Random.Range(0,1);
            int enemyIndex = Random.Range(0,enemyPrefabs.Length);
            Vector3 offset = new Vector3(0,0,0);
            if(enemySpawnRandimizerOne == 1){
                offset.y = 1;
            }
            else{
                offset.y = -1;
            }
            Instantiate(enemyPrefabs[enemyIndex],spawnerPosition + offset, enemyPrefabs[enemyIndex].transform.rotation);
            
            if(enemySpawnRandimizerTwo == 1){
                offset.x = 1;
            }
            else{
                offset.x = -1;
            }
            Instantiate(enemyPrefabs[enemyIndex],spawnerPosition + offset, enemyPrefabs[enemyIndex].transform.rotation);
            timer = 0;
        }

    }
}
