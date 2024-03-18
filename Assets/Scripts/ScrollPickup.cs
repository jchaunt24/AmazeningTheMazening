using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    void Update(){
    }
        
        
    void OnTriggerEnter2D(Collider2D other){
            if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy")){  
                Destroy(gameObject);
            }   
        
    }
}
}

