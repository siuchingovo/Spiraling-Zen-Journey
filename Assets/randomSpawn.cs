using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    public GameObject[] flowers;
    public int randomNum;
    
    void Start()
    {
        randomNum = Random.Range(0, 2);
        Instantiate(flowers[randomNum], this.transform);

    }

    
    void Update()
    {
        
    }
}
