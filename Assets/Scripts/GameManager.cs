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
    public GameObject spider;
    public GameObject BlueSlime;
    public GameObject door;
    public int count;
    public float Timer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Random.Range(1,3);

            Timer = 2f;
            //Instantiate();
        }
    }
}
