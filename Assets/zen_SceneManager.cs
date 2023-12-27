using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zen_SceneManager : MonoBehaviour
{
    public GameObject[] brightCircles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Turn on the bright circles =================
    public void brightCirclesOn(int id)
    {
        brightCircles[id].SetActive(true);
    }
}
