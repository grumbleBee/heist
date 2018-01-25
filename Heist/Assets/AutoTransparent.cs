using UnityEngine;
using System.Collections;

public class AutoTransparent : MonoBehaviour
{
    public Material transMaterial;
    private Shader transShader;
    private Shader defaultShader;
    private Material defaultMaterial;
    private Color defaultColor;
    private float transparency = 0.3f;
    private const float targetTransparancy = 0.3f;
    private const float fallOff = 0.1f;
    public Renderer rend;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        defaultShader = rend.material.shader;
        defaultMaterial = rend.material;
        defaultColor = rend.material.color;
        transMaterial = (Resources.Load("Transparency", typeof(Material)) as Material);
        transShader = transMaterial.shader;
    }

    public void BeTransparent()
    {
        transparency = targetTransparancy;
        //yell at me daddy ;)
        rend.material.shader = transShader;
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
            rend.material = defaultMaterial;
            rend.material.color = defaultColor;
            rend.material.shader = defaultShader;
            Destroy(this);
        }

        transparency += ((1.0f - targetTransparancy) * Time.deltaTime) / fallOff;
    }
}