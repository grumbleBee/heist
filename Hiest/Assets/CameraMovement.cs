using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float cameraMin;
    public float cameraMax;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxisRaw("rightVertical");

        float cameraPosition = transform.localPosition.z + moveVertical;

        Vector3 movement = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Clamp(cameraPosition, cameraMin, cameraMax));

        transform.localPosition = movement; 

        transform.LookAt(target);
    }
}
