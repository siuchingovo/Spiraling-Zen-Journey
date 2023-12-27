using System.Collections.Generic;
using System.Linq;
using PathCreation;
using Unity.VisualScripting;
using UnityEngine;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer : PathSceneTool {

        [Header("Zen")]
        public GameObject[] prefab; //circles
        public int count; //count the amount of circles
        public GameObject circle_L_temp;

        public List<GameObject> prev_set_temp = new List<GameObject>();

        public bool spawnOnStart = false; //force not to spawn on start

        [Header("PathPlacer")]
        public GameObject holder;
        public float spacing = 3;
        const float minSpacing = .1f;


        void Generate () {
            if (pathCreator != null && prefab[0] != null && prefab[1] != null && holder != null && spawnOnStart) {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;
                int temp = 0;
                count = 0;
                GameObject clone;
                prev_set_temp.Clear();

                while (dst < path.length) {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);

                    //Spawn Large======================================
                    if (temp%9 == 4 || temp%9 == 8)
                    {   
                        
                        clone = Instantiate (prefab[1], point, rot, holder.transform); //Spawn Large=======
                        clone.name = temp.ToString();

                        //apped to prev_set==============
                        // circle_L_temp.GetComponent<circle_L_control>().prevSet.Add(clone); //self=====
                        for (int i = 0; i < prev_set_temp.Count; i++)
                        {
                            clone.GetComponent<circle_L_control>().prevSet.Add(prev_set_temp[i]);
                        }

                        prev_set_temp.Clear();

                        //append next=====
                        if (count > 4) 
                        {
                            circle_L_temp.GetComponent<circle_L_control>().nextSet.Add(clone);
                        }                  
                        circle_L_temp = clone;



                        dst += (spacing *1.3f);


                    }
                    else
                    {
                        
                        clone = Instantiate (prefab[0], point, rot, holder.transform); //Spawn Small=======
                        clone.name = temp.ToString();
                        if (temp%9 == 3 || temp%9 == 7)
                        {
                            dst += (spacing *1.3f);
                        }
                        else
                        {
                            dst += spacing;
                        }

                        //add previous small=-===-================
                        prev_set_temp.Add(clone);


                        if (count > 4) //append next set=============
                        {
                            circle_L_temp.GetComponent<circle_L_control>().nextSet.Add(clone);
                        }
                        
                    }
                    temp ++;
                    count++;
                    
                    //Only implement at the beginning=======================
                    //To be validated==================
                    if (count > 5)
                    {
                        clone.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    }    
                    
            }
        }
    }

        void DestroyObjects () {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
            }
        }

        protected override void PathUpdated () {
            if (pathCreator != null) {
                Generate ();
            }
        }
    }
}