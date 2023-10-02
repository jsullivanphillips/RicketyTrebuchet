using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Chrystal_BH : MonoBehaviour
{
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject Bubble;
    [SerializeField] private float ScaleSpeed;
    [SerializeField] private float BubbleScaleSpeed;
    [SerializeField] private float DimSpeed;
    [SerializeField] private float ColorFadeSpeed;
    [SerializeField] private Light2D LightComp;
    [SerializeField] private float maxRadius;
    [SerializeField] private float Speed_damper;
    [SerializeField] private SpriteRenderer Chryst_Render;
    [SerializeField] private SpriteRenderer BubbleRender;

    [SerializeField] public float ShrinkSpeedIncrease = 1;

    private void Start()
    {
        Chryst_Render = this.GetComponent<SpriteRenderer>();
        BubbleRender = Bubble.GetComponentInChildren<SpriteRenderer>();
        LightComp = lights.GetComponent<Light2D>();
        maxRadius = LightComp.pointLightOuterRadius;
    }

    private void Update()
    {
        Speed_damper = (LightComp.pointLightOuterRadius)/ (maxRadius+3) + 0.2f;
        if (LightComp.pointLightOuterRadius <= 5)
        {
            Color Mycolor = Chryst_Render.color;
            Color Bubblecolor = BubbleRender.color;
            Bubblecolor.a -= ColorFadeSpeed / 100;
            Mycolor.a -= ColorFadeSpeed / 100;
            Chryst_Render.color = Mycolor;
            BubbleRender.color = Bubblecolor;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bubble.GetComponent<Transform>().localScale -= new Vector3(BubbleScaleSpeed, BubbleScaleSpeed, BubbleScaleSpeed) * Speed_damper * ShrinkSpeedIncrease;

        LightComp.pointLightOuterRadius -= ((ScaleSpeed / 100) * Speed_damper)* ShrinkSpeedIncrease;
        LightComp.pointLightInnerRadius -= ((ScaleSpeed/400) * Speed_damper) * ShrinkSpeedIncrease;
        if(LightComp.intensity > 0)
        {
            LightComp.intensity -= ((DimSpeed/100) * Speed_damper) * ShrinkSpeedIncrease;
        }
        if (LightComp.pointLightOuterRadius <= 3.5)
        {
            Destroy(this.gameObject);
        }
        //lights.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * ScaleSpeed;
    }
}