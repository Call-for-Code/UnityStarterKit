using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceDataTable : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;

    [SerializeField]
    Transform m_DataVizObject;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    Vector2 m_CenterScreen;
    bool m_Placed;

    void OnEnable()
    {
        // assumes device maintains orientation while placing
        m_CenterScreen = new Vector2(Screen.width/2, Screen.height/2);
    }

    void Update()
    {
        if (!m_Placed)
        {
            // set object position and rotation
            if (m_RaycastManager.Raycast(m_CenterScreen, s_Hits))
            {
                Pose hitPose = s_Hits[0].pose;
                m_DataVizObject.position = hitPose.position;
                
                // rotate object to always face camera
                float yRot = Quaternion.LookRotation((m_DataVizObject.position - Camera.main.transform.position)).eulerAngles.y;        
                m_DataVizObject.rotation = Quaternion.Euler(0, yRot, 0);
            }
            
            // listen for touch input to stop setting object position / rotation
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    m_Placed = true;
                }
            }
        }
    }
}
