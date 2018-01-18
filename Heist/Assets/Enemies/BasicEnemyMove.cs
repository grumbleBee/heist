using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMove : MonoBehaviour
{
    public GameObject[] points;
    public Rigidbody rb;
    public float normalSpeed = .5f;
    public float runSpeed = .1f;
    public bool detected = false;
    public int pointIndex = 0;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == points[pointIndex])
        {
                pointIndex++;
        }
    }
    void FixedUpdate()
    {
        if (!detected)
        {
            if (pointIndex >= points.Length)
            {
                pointIndex = 0;
            }
            transform.LookAt(points[pointIndex].transform);
            transform.position += transform.forward * normalSpeed;
        }
    }
}
