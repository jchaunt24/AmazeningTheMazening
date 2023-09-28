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
    public static PlayerController Instance {get; private set;}
    // Move Speed
    private float moveSpeed = 2f;

    // Player Rigid Body
    public Rigidbody2D rb;

    // Vector to calculate movement
    Vector2 movement;

    // Animator
    public Animator animator; 

    public int hp;


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
        
    }

    // moves player
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision){
        hp -= 1;
    }
}