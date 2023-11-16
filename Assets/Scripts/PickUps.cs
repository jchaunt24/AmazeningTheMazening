using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public float timer;

    void Update(){
        timer += Time.deltaTime;
        if(timer >= 5){
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy")){  
            Destroy(gameObject);
        }   
    }
    
}
