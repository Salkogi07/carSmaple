using System;
using System.Net.NetworkInformation;
using UnityEngine;

public class CarLight : MonoBehaviour
{
    public GameObject headLight_Obj;
    public Light[] headLight;
    public GameObject rearLight_Obj;
    public Light[] rearLight;

    public float lowIntensity = 0.8f;
    public float highIntensity = 1.34f;
    public float highBeamLight = 2f;
    public float currentHeadLight = 0;
    private int isDimmed = 0;
    private bool highBeam = false;
    public bool breakLight = true;

    void Start()
    {
        headLight[0] = headLight_Obj.transform.Find("0").gameObject.GetComponent<Light>();
        headLight[1] = headLight_Obj.transform.Find("1").gameObject.GetComponent<Light>();

        rearLight[0] = rearLight_Obj.transform.Find("0").gameObject.GetComponent<Light>();
        rearLight[1] = rearLight_Obj.transform.Find("1").gameObject.GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isDimmed++;
            if (isDimmed == 3)
                isDimmed = 0;
            ToggleLights();
        }

        if (Input.GetKey(KeyCode.J))
        {
            highBeam = false;
        }
        else
        {
            highBeam = true;
        }

        HighBeam();
    }

    private void HighBeam()
    {
        if (highBeam)
        {
            headLight[0].intensity = currentHeadLight;
            headLight[1].intensity = currentHeadLight;
        }
        else
        {
            headLight[0].intensity = highBeamLight;
            headLight[1].intensity = highBeamLight;
        }
    }

    private void ToggleLights()
    {
        if(isDimmed == 0)
        {
            currentHeadLight = 0;
            rearLight[0].intensity = 0f;
            rearLight[1].intensity = 0f;
        }
        else if(isDimmed == 1)
        {
            currentHeadLight = lowIntensity;
            headLight[0].intensity = lowIntensity;
            headLight[1].intensity = lowIntensity;
            rearLight[0].intensity = 2.3f;
            rearLight[1].intensity = 2.3f;
        }
        else if (isDimmed == 2)
        {
            currentHeadLight = highIntensity;
            headLight[0].intensity = highIntensity;
            headLight[1].intensity = highIntensity;
            rearLight[0].intensity = 2.3f;
            rearLight[1].intensity = 2.3f;
        }
    }

    public void BreakLightOn()
    {
        rearLight[0].intensity = 4f;
        rearLight[1].intensity = 4f;
    }

    public void BreakLightOff()
    {
        rearLight[0].intensity = 0f;
        rearLight[1].intensity = 0f;
    }
}
