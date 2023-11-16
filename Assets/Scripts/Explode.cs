using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject projectile;
    Vector3 explodePosition;
    float thrust = 50f;
    void Update(){
        explodePosition = transform.position;
        
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Kaboom");
            Vector3 offset = new Vector3(0,0,0);
            offset.x = -1;
            var explodingparticle = Instantiate(projectile,explodePosition +offset, projectile.transform.rotation);
            explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.right * -thrust);
            explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
            offset.x = 1;
            explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
            explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.right * thrust);
            explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
            offset.x = 0;
            offset.y = -1;
            explodingparticle = Instantiate(projectile,explodePosition + offset, projectile.transform.rotation);
            explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * -thrust);
            explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
            offset.y = 1;
            explodingparticle = Instantiate(projectile,explodePosition+ offset, projectile.transform.rotation);
            explodingparticle.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
            explodingparticle.GetComponent<Rigidbody2D>().AddTorque(50);
            Destroy(gameObject);
        }
        
    }
}
