using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    public GameObject door;
    Vector2 playerPosition;
    private float distance;
    Vector2 doorPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator DoorClose(){  
        yield return new WaitForSeconds(2); 
        door.SetActive(true);
    }
    void OnTriggerEnter2D(){
        door.SetActive(false);
        StartCoroutine(DoorClose());
    }
}
