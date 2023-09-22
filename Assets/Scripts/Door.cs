using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 playerPosition;
    private float distance;
    Vector2 doorPosition;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = PlayerController.Instance.transform.position;
        doorPosition = transform.position;
        distance = Vector2.Distance(doorPosition, playerPosition);
        if(distance < 2){
            StartCoroutine(DoorClose());
            gameObject.SetActive(false);
        }  
    }

    IEnumerator DoorClose(){  
        yield return new WaitForSeconds(5); 
        gameObject.SetActive(true);
    }


}
