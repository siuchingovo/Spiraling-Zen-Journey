using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class brightCircle_Control : MonoBehaviour
{
    public int id;
    public PlayableDirector[] timeline;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            if (id == 0)
            {
                distroyBrightCircle();
            }
            else if (id == 1) //c15
            {
                timeline[1].Play();
            }
            else if (id == 2) // c25
            {
                timeline[2].Play();
            }
            else if (id == 3) //c35
            {
                timeline[3].Play();
            }
            else if (id == 4) //last
            {
                timeline[4].Play();
            }
             
        }
    }

    public void distroyBrightCircle()
    {
        Destroy(gameObject);
    }
}
