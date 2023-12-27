using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnflowers : MonoBehaviour
{

    public bool flowers = false;
    public GameObject flowerspawn;
    public Transform playerdistance;
    public Transform flowerTransform;

    private float maxScale = 5;
    private float minScale = 4;
    public float Activationdistance;
    

    // Start is called before the first frame update
    void Start()
    {
        playerdistance = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
       if(flowers == true){
       flowerspawn.SetActive(true);  
       } 


        float currentDistance1 = Vector3.Distance(playerdistance.position, flowerTransform.position);


        // Normalize the distance based on the activation distance
        float normalizedDistance1 = Mathf.Clamp01(currentDistance1 / Activationdistance);


        // Calculate the new scale of the glass ball
        float scale1 = Mathf.Lerp(maxScale, minScale, normalizedDistance1);
  

        // Apply the new scale to the glass ball
        flowerTransform.localScale = new Vector3(scale1,scale1,scale1);
    }

    void OnTriggerEnter(Collider other){
       
       if(other.tag == "MainCamera"){
        flowers = true;
        
       }  
    }
}
