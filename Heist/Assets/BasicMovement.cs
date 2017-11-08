using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float movementSpeed = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxisRaw("leftHorizontal");
        float moveVertical = Input.GetAxisRaw("leftVertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * movementSpeed * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("rightHorizontal") * movementSpeed, 0);
    }
}
