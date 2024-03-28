using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusAttacks : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject projectile;
    Vector3 explodePosition;
    public float timer;
    public float spawnTime = .5f;
    float thrust = 50f;
    public int attackcount;
    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update(){
        if(gameManager.gamePaused == false){
            timer += Time.deltaTime;
            if(timer >= spawnTime){
                explodePosition = transform.position;
                Debug.Log("Kaboom");
                Vector3 offset = new Vector3(0,0,0);
                offset.x = -2;
                var explodingparticle = Instantiate(projectile,explodePosition +offset, projectile.transform.rotation);
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.right * -thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                offset.x = 2;
                explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.right * thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                offset.x = 0;
                offset.y = -2;
                explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * -thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                offset.y = 2;
                explodingparticle = Instantiate(projectile,explodePosition+ offset, projectile.transform.rotation);
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                

                // Diagonals
                offset.x = -2;
                offset.y = 2;
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.right * -thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                offset.x = 2;
                offset.y = -2;
                explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.right * thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                offset.y = -2;
                offset.x = 2;
                explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * -thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                offset.y = 2;
                offset.x = -2;
                explodingparticle = Instantiate(projectile,explodePosition+ offset, projectile.transform.rotation);
                explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
                explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
                attackcount += 1;
                timer = 0;
                if(attackcount == 3){
                    attackcount = 0;
                    //full screen attack
                    offset.x = -4;
                    offset.y= 9;
                    for (int i = 0; i < 25; i++) {
                        explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
                        explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * -thrust);
                        offset.x = offset.x + 2;
                    }
                    offset.x = -5;
                    offset.y = -8;
                    for (int i = 0; i < 25; i++) {
                        explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
                        explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
                        offset.x = offset.x + 1;
                    }
                }
            }
        }
    }
}
