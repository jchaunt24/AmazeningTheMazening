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

public class EnemyAI : MonoBehaviour, IDropItem
{
    public float speed;
    Vector2 playerPosition;
    Vector2 enemyposition;

    public int enemyID;
    public ParticleSystem gooParticle;
    private GameManager gameManager;
    private float distance;
    public Rigidbody2D rb;
    //private float thrust = 2.0f;
    //public bool targetcollision;
    public Collider2D collider;
    public int health;

    public bool colliding;
    [SerializeField]private GameObject[] drops;

    // Timer for Self Destruction

    public float timer;
    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
        
    // Update is called once per frame
    void Update()
    {
        if(gameManager.gamePaused == false){
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
            if(enemyID != 3){
                if(timer >= 30){
                    Destroy(gameObject);
                }
            }
            if(health <= 0){
                Destroy(gameObject);
            }
            

            if(colliding){
                speed = 0f;
            }
            else{
                if(enemyID == 1){
                    speed = 1.5f;
                }
                if(enemyID == 2){
                    speed = 3f;
                }
                if(enemyID == 3){
                    speed = .5f;
                }
            }
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("Damage Taken!!");
        DropItem(gameObject.transform.position);
    }


    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            colliding = true;
            gooParticle.Play();
        }
    }

    void OnCollisionExit2D(){
        colliding = false;
    }
    
    public void DropItem(Vector3 position){
        int randomItemNumber = Random.Range(0,2);
        Debug.Log(randomItemNumber);
        Instantiate(drops[randomItemNumber], position, drops[randomItemNumber].transform.rotation);
        Debug.Log("Item Dropped");
    }
    

}
