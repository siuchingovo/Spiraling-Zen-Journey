using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMoving : MonoBehaviour
{
    GameObject centerEyeAnchor;
    Transform centerTransform;
    Transform OVRTransform;
    GameObject ovrCameraRig;
    Vector3 tmp;
    // Start is called before the first frame update
    void Start()
    {
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        ovrCameraRig = GameObject.Find("OVRCameraRig");
    }

    // Update is called once per frame
    void Update()
    {
        if(centerEyeAnchor != null){
            print("found it\n");
            centerTransform = centerEyeAnchor.transform;
            Debug.Log(centerTransform.position + "PXP");
            Debug.Log(ovrCameraRig.transform.position + "QXQ");
            tmp = new Vector3(centerTransform.position.x, centerTransform.position.y, centerTransform.position.z);
            Debug.Log(tmp + "tmp");
            // ovrCameraRig.transform.position = tmp;
        }
        else{
            Debug.Log("error\n");
        }
    }
}
