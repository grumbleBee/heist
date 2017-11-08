using UnityEngine;
using System.Collections;

public class Transparency : MonoBehaviour
{
    float maxDistance = 5f;

    void Start()
    {
        //maxDistance = GameObject.Find("Main Camera").GetComponent<CameraMovement>().cameraDistance;
    }

    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, maxDistance);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();

            if (rend)
            {
                rend.material.shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = rend.material.color;
                tempColor.a = 0.3F;
                rend.material.color = tempColor;
            }
        }
    }
}