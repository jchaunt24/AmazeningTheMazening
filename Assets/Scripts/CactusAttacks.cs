using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusAttacks : MonoBehaviour
{
    public GameObject projectile;
    Vector3 explodePosition;
    public float timer;
    public float spawnTime = .5f;
    float thrust = 50f;
    void Update(){
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
            timer = 0;
        }
    }
}
