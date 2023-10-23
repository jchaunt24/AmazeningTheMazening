using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Time between Attacks(Cool down)
    public float timer = 0;
    // Animation for the player
    public Animator playerAnim;
    // Where the attack is centered(Circular Attacks)
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    private Animator anim;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gamePaused == false){
            timer -= Time.deltaTime;
            if(timer < .1f){
                if(Input.GetAxisRaw("Fire1") > .5f){
                    Debug.Log("Player Hit Attack");
                    playerAnim.SetTrigger("AttackTrig");
                    GetComponent<PlayerController>().AttackAnim(true);
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies );
                    for(int i = 0; i < enemiesToDamage.Length; i++){
                        enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);
                    }
                    timer = 1;
                }
                
            }
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
