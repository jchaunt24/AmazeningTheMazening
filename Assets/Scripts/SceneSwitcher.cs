using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextScene;
    public static Vector3 locationToTeleport;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        /*
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
        */
        if(other.CompareTag("Player")){
            gameManager.Teleport(nextScene);
        }
    }
}
