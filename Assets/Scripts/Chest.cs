using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour,IDropItem
{    
    public bool playerInRange;
    private GameManager gameManager;
    Vector3 chestPosition;
    public Animator chestAnim;
    public bool opening;
    [SerializeField]private GameObject[] drops;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        chestAnim = GetComponent<Animator>();
        opening = false;
    }

    void OnAwake(){
        chestPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange && !opening){
            opening = true;
            chestAnim.SetTrigger("ChestOpen");
            Debug.Log($"Chest Open: {gameObject.transform.position}");
            StartCoroutine(ChestDestroy());
            //Destroy(gameObject);
        }
    }
    IEnumerator ChestDestroy(){
        yield return new WaitForSeconds(2);
        DropItem(gameObject.transform.position);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;
        }
    }
    public void DropItem(Vector3 position){
        for(int i = 0; i < 2; i++){
            int randomItemNumber = Random.Range(0,2);
            Debug.Log(randomItemNumber);
            Vector3 offset = new Vector3(0,.2f,0);
            position = position + offset;
            Instantiate(drops[randomItemNumber], position, drops[randomItemNumber].transform.rotation);
            Debug.Log("Item Dropped");
        } 
    }
}