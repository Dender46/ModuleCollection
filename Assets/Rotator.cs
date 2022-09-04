using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float m_Speed = 1.0f;
    public float m_Diameter = 1.0f;

    Vector3 CentralPos;

    private float sinVal;

    void Start()
    {
        Vector3 center = transform.position;
        center.x -=  m_Diameter * 0.5f;
        center.z -= m_Diameter * 0.5f;

        //transform.position = center;
    }

    void Update()
    {
        Vector3 newPos = transform.position;

        float time = Time.time * m_Speed * Mathf.PI;
        float diameter = m_Diameter * Time.deltaTime;

        newPos.x += Mathf.Sin(time) * diameter;
        newPos.z += Mathf.Cos(time) * diameter;
        
        //newPos.x = Mathf.Clamp(newPos.x, -m_Diameter * Mathf.PI, m_Diameter * Mathf.PI);
        //newPos.z = Mathf.Clamp(newPos.z, -m_Diameter * Mathf.PI, m_Diameter * Mathf.PI);

        transform.position = newPos;
    }
}
