using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    public Camera m_Camera;

    //Orient the camera after all movement is completed this frame to avoid jittering
    //You might want to change Vector3.back to Vector3.front, depending on the initial orientation of your object. 
 
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
