using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_L_control : MonoBehaviour
{
    public int id;
    // public GameObject[] nextSet = new GameObject[5];

    public List<GameObject> prevSet = new List<GameObject>();
    public List<GameObject> nextSet = new List<GameObject>();
    
    void Start()
    {
        id = int.Parse(this.gameObject.name);
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            
            StartCoroutine(activateNext());
        }
    }

    IEnumerator activateNext()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < nextSet.Count; i++)
        {
            nextSet[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        for (int i = 0; i < prevSet.Count; i++)
        {
            prevSet[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        this.transform.GetChild(0).gameObject.SetActive(false);

    }
}
