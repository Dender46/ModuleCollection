using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraCenteralized : MonoBehaviour
{
    [SerializeField]
    GameObject POI;

    [SerializeField] float YMin = 0.0f;
    [SerializeField] float YMax = 85.0f;

    [SerializeField] float m_Distance = 7.0f;
    [SerializeField] float m_Sensitivity = 100.0f;
    [SerializeField] float m_DampingSpeed = 0.1f;

    private Vector3 m_Offset;

    void Start()
    {
        m_Offset.y = Mathf.Clamp(m_Offset.y, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -m_Distance);
        Quaternion rotation = Quaternion.Euler(m_Offset.y, m_Offset.x, 0);
        transform.position = POI.transform.position + rotation * Direction;
 
        transform.LookAt(POI.transform.position);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            m_Offset.x += Input.GetAxis("Mouse X") * m_Sensitivity * Time.deltaTime;
            m_Offset.y += Input.GetAxis("Mouse Y") * m_Sensitivity * Time.deltaTime;
            m_Offset.y = Mathf.Clamp(m_Offset.y, YMin, YMax);
        }
            
        /* This doesn't work :(
        transform.RotateAround(POI.transform.position, Vector3.up, m_Offset.x * m_Sensitivity * Time.deltaTime);
        transform.RotateAround(POI.transform.position, Vector3.right, m_Offset.y * m_Sensitivity * Time.deltaTime);
            
        Vector3 LookTowards = POI.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(LookTowards);
        */

        Vector3 Direction = new Vector3(0, 0, -m_Distance);
        Quaternion rotation = Quaternion.Euler(m_Offset.y, m_Offset.x, 0);
        transform.position = POI.transform.position + rotation * Direction;
 
        transform.LookAt(POI.transform.position);
    }
}

