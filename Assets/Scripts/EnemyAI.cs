using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Name: Jacob Chaunt          ID: 18912
Teacher: Mrs. Boscombe
Credit: Mrs.Boscombe, ChatGBT
Date: 9/21/23
Project: Movement
https://www.youtube.com/watch?v=2SXa10ILJms&t=28s
*/

public class EnemyAI : MonoBehaviour
{
    public float speed;
    Vector2 playerPosition;
    Vector2 enemyposition;

    private float distance;

    void Start(){
        
    }
        
    // Update is called once per frame
    void Update()
    {
        playerPosition = PlayerController.Instance.transform.position;
        enemyposition = transform.position;
        distance = Vector2.Distance(enemyposition, playerPosition);
        Vector2 direction = enemyposition - playerPosition;
        direction.Normalize();

        if(distance < 15){
            transform.position = Vector2.MoveTowards(enemyposition, playerPosition,speed *Time.deltaTime);
        }
    }
}
