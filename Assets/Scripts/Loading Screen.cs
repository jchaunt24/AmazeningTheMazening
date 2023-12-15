using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadingImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Loading(){
        yield return new WaitForSeconds(2);
        LoadingImage.SetActive(false);
    }
}
