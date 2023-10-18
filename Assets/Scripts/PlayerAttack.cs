using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeAttack;
    public Animator playerAnim;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0){
            timeBtwAttack = startTimeAttack;
            if(Input.GetKey(KeyCode.F)){
                playerAnim.SetTrigger("AttackTrig");
                GetComponent<PlayerController>().AttackAnim(true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies );
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);
                }
            }
        }
        else{
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}