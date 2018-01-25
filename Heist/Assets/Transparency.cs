using UnityEngine;
using System.Collections;

public class Transparency : MonoBehaviour
{
    public float distance;

    void Update()
    {
        RaycastHit[] hits;
        int layerMask = 1 << 8;
        hits = Physics.RaycastAll(transform.position, transform.forward, distance, layerMask);

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