using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float cameraMin;
    public float cameraMax;
    public float cameraDistance;
    float zPosition;
    float yPosition;
    public bool inverted = false;
    public float cameraSpeed;

    // Use this for initialization
    void Start () {
        cameraDistance = Mathf.Pow(transform.localPosition.z, 2) + Mathf.Pow(transform.localPosition.y, 2);
        cameraMin = -1 * Mathf.Sqrt(cameraDistance);
    }
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxisRaw("rightVertical");
        if (inverted)
        {
            moveVertical *= -1;
        }

        zPosition = transform.localPosition.z + (cameraSpeed * moveVertical);

        if (Mathf.Sqrt(cameraDistance - Mathf.Pow(zPosition, 2)) >= 0)
        {
            yPosition = Mathf.Sqrt(cameraDistance - Mathf.Pow(zPosition, 2));
        }
        else
        {
            yPosition = 0;
        }

        Vector3 movement = new Vector3(transform.localPosition.x, yPosition, Mathf.Clamp(zPosition, cameraMin, cameraMax));

        transform.localPosition = movement; 

        transform.LookAt(target);
    }
}
