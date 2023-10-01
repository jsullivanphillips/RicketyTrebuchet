using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Chrystal_BH : MonoBehaviour
{
    [SerializeField] private GameObject lights;
    [SerializeField] private float ScaleSpeed;
    [SerializeField] private float DimSpeed;
    [SerializeField] private float ColorFadeSpeed;
    [SerializeField] private Light2D LightComp;
    [SerializeField] private float maxRadius;
    [SerializeField] private float Speed_damper;
    [SerializeField] private SpriteRenderer Chryst_Render;

    private void Start()
    {
        Chryst_Render = this.GetComponent<SpriteRenderer>();
        LightComp = lights.GetComponent<Light2D>();
        maxRadius = LightComp.pointLightOuterRadius;
    }

    private void Update()
    {
        Speed_damper = (LightComp.pointLightOuterRadius)/ (maxRadius+3) + 0.2f;
        if (LightComp.pointLightOuterRadius <= 5)
        {
            Color Mycolor = Chryst_Render.color;
            Mycolor.a -= ColorFadeSpeed / 100;
            Chryst_Render.color = Mycolor;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        LightComp.pointLightOuterRadius -= ((ScaleSpeed / 100) * Speed_damper);
        LightComp.pointLightInnerRadius -= (ScaleSpeed/400) * Speed_damper;
        if(LightComp.intensity > 0)
        {
            LightComp.intensity -= (DimSpeed/100) * Speed_damper;
        }
        if (LightComp.pointLightOuterRadius <= 0.6)
        {
            Destroy(this.gameObject);
        }
        //lights.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * ScaleSpeed;
    }
}
