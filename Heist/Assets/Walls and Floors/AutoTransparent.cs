using UnityEngine;
using System.Collections;

public class AutoTransparent : MonoBehaviour
{
    private Shader oldShader = null;
    private Color oldColor = Color.black;
    private float transparency = 0.3f;
    private const float targetTransparancy = 0.3f;
    private const float fallOff = 0.1f;
    public Renderer rend;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    public void BeTransparent()
    {
        transparency = targetTransparancy;

        if (oldShader == null)
        {
            oldShader = rend.material.shader;
            oldColor = rend.material.color;
            rend.material.shader = Shader.Find("Transparent/Diffuse");
        }
    }

    void Update()
    {
        if (transparency < 1.0f)
        {
            Color currentColor = rend.material.color;
            currentColor.a = transparency;
            rend.material.color = currentColor;
        }
        else
        {
            rend.material.shader = oldShader;
            rend.material.color = oldColor;
            Destroy(this);
        }

        transparency += ((1.0f - targetTransparancy) * Time.deltaTime) / fallOff;
    }
}