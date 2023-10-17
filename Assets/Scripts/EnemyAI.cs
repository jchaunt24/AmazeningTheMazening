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

    public int enemyID;

    private float distance;
    public Rigidbody2D rb;
    private float thrust = 2.0f;
    public bool targetcollision;
    public Collider2D collider;
    public int health;

    // Timer for Self Destruction

    public float timer;

    void Start(){
        if(enemyID == 1){
            health = 15;
        }   
        if(enemyID == 2){
            health = 6;
        }
    }
        
    // Update is called once per frame
    void Update()
    {
        playerPosition = PlayerController.Instance.transform.position;
        enemyposition = transform.position;
        distance = Vector2.Distance(enemyposition, playerPosition);
        Vector2 direction = enemyposition - playerPosition;
        direction.Normalize();
        if(enemyID == 1){
            if(distance < 5){
                transform.position = Vector2.MoveTowards(enemyposition, playerPosition,speed *Time.deltaTime);
            }   
        }
        else if(enemyID == 2){
            if(distance < 8){
                transform.position = Vector2.MoveTowards(enemyposition, playerPosition,speed *Time.deltaTime);
            }
        }
        else if(enemyID == 3){
            if(distance < 10){
                transform.position = Vector2.MoveTowards(enemyposition, playerPosition,speed *Time.deltaTime);
            }
        }
        timer += Time.deltaTime;
        if(timer >= 30){
            Destroy(gameObject);
        }
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("Damage Taken!!");
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            Vector3 contactPoint = other.contacts[0].point;
            Vector3 center = other.collider.bounds.center;
            targetcollision = true;
            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;
            bool bottom = contactPoint.y < center.y;

            if(right) GetComponent<Rigidbody2D>().AddForce(transform.right * thrust,ForceMode2D.Impulse);
            if(left) GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust,ForceMode2D.Impulse);
            if(top) GetComponent<Rigidbody2D>().AddForce(transform.up * thrust,ForceMode2D.Impulse);
            if(left) GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust,ForceMode2D.Impulse);
        }
    }

    void FalseCollision(){
        targetcollision = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
