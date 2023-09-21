using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
/*
    Name: Jacob Chaunt          ID: 18912
    Teacher: Mrs. Boscombe
    Date: 9/21/23
    Project: Movement
*/
    // Start is called before the first frame update
    public GameObject slime;
    void Start()
    {
        Instantiate(slime);
        Instantiate(slime);
        Instantiate(slime);
        Instantiate(slime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
