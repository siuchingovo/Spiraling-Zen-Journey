using PathCreation;
using UnityEngine;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer : PathSceneTool {

        public GameObject[] prefab;
        public int count;
        public GameObject holder;
        public float spacing = 3;

        const float minSpacing = .1f;

        void Generate () {
            if (pathCreator != null && prefab[0] != null && prefab[1] != null && holder != null) {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;
                int temp = 0;

                while (dst < path.length) {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);
                    if (temp%9 == 4 || temp%9 == 8)
                    {
                        Instantiate (prefab[1], point, rot, holder.transform);
                    }
                    else
                    {
                        Instantiate (prefab[0], point, rot, holder.transform);
                    }
                    temp ++;
                    count++;
                    dst += spacing;
                    
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