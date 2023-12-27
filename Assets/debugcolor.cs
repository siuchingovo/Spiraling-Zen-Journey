using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugcolor : MonoBehaviour
{
 

    Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
         //Fetch the Material from the Renderer of the GameObject
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name + "  " + other.tag);
        if (other.tag == "Player")
        {
            m_Material.color = Color.red;
           
        }
    }
}
