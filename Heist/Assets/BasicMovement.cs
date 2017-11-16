using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float movementSpeed = 1;
    public float sneakSpeed = .5f;
    public bool sneak = false;
    public GameObject model;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {    
        float moveHorizontal = Input.GetAxisRaw("leftHorizontal");
        float moveVertical = Input.GetAxisRaw("leftVertical");
        float sneakAxis = Input.GetAxisRaw("sneakAxis");

        Vector3 movement = (new Vector3(moveHorizontal, 0.0f, moveVertical));
        movement = transform.TransformDirection(movement);
        //transform.Translate(movement * movementSpeed * Time.deltaTime);
        //transform.Rotate(0, Input.GetAxis("rightHorizontal") * movementSpeed, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, Input.GetAxis("rightHorizontal") * movementSpeed, 0f));
        if (sneakAxis > -1f)
        {
            rb.MovePosition(rb.position + movement * sneakAxis * Time.deltaTime);
            if (sneak == false)
            {
                model.transform.localScale += new Vector3(0, -(transform.localScale.y * .5f), 0);
                sneak = true;
            }
        }
        else
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
            if (sneak == true)
            {
                model.transform.localScale += new Vector3(0, (transform.localScale.y *.5f), 0);
                sneak = false;
            }
        } 
    }
}
