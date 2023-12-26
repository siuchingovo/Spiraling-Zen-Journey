using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_L_control : MonoBehaviour
{
    public int id;
    // public GameObject[] nextSet = new GameObject[5];
    public zen_SceneManager zen_SceneManager;

    public List<GameObject> prevSet = new List<GameObject>();
    public List<GameObject> nextSet = new List<GameObject>();
    public int[] audio_id = new int[4];
    
    void Start()
    {   
        zen_SceneManager = GameObject.FindWithTag("SceneManager").GetComponent<zen_SceneManager>();
        id = int.Parse(this.gameObject.name);
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            if (id == audio_id[0])
            {
                zen_SceneManager.brightCirclesOn(0);
            }
            else if (id == audio_id[1])
            {
                zen_SceneManager.brightCirclesOn(1);
            }
            else if (id == audio_id[2])
            {
                zen_SceneManager.brightCirclesOn(2);
            }
            else if (id == audio_id[3])
            {
                zen_SceneManager.brightCirclesOn(3);
            }
            StartCoroutine(activateNext());
        }
    }

    IEnumerator activateNext()
    {
        yield return new WaitForSeconds(7.5f);

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
