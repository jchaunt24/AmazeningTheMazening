using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Name: Jacob Chaunt          ID: 18912
Teacher: Mrs. Boscombe
Date: 9/19/23
Project: Movement
Video: https://www.youtube.com/watch?v=whzomFgjT50&t=426s
*/

public class PlayerController : MonoBehaviour
{
    // So the enemy can find the player
    private GameManager gameManager;
    public static PlayerController Instance {get; private set;}
    // Movement
    private float moveSpeed = 2f;
    Vector2 movement;
    public bool canMove;
    
     // Player Animations and Rigidbody
    public Rigidbody2D rb;
    public Animator animator; 

    // Combat Related
    public int hp;
    public float attackTimerCoolDown;

    
    

    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(gameManager.gamePaused == false){
            // Animation Calculations
            animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
            
            // Movement Calculations
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // only one input per axis of movement at one time
            if((movement.x == 1) || (movement.x == -1)){
                movement.y = 0;
                animator.SetFloat("Vertical", 0);
            }
            else{
                movement.x = 0;
                animator.SetFloat("Horizontal", 0);
            }
            // Attacking and Not Moving Code
            if(canMove == false){
                moveSpeed = 0f;
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                attackTimerCoolDown -= Time.deltaTime;
                if (attackTimerCoolDown <= 0f)
                {
                    moveSpeed = 2f;
                    canMove = true;
                }
            }
        }
    }

    // moves player during the set frames
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Cannot Move during the attacking animation(called by player attack)
    public void AttackAnim(bool attacking){
        if(attacking == true){
            attackTimerCoolDown = 1f;
            canMove = false;
        }
    }
    // If hit by an object that has the tag "Enemy" the player will take damage
    // Damage Script
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
           gameManager.UpdateHealth(-1);
        }
    }
}
