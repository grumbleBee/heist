using UnityEngine;
using System.Collections;

public class Transparency : MonoBehaviour
{
    public float distance;

    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, distance);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();

            if (rend)
            {
                AutoTransparent AT = rend.GetComponent<AutoTransparent>();
                if (AT == null)
                {
                    AT = rend.gameObject.AddComponent<AutoTransparent>();
                }
                AT.BeTransparent();
            }
        }
    }
}