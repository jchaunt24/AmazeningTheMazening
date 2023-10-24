using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);
    }
}
