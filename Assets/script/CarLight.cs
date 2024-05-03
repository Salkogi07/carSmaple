using System;
using System.Net.NetworkInformation;
using UnityEngine;

public class CarLight : MonoBehaviour
{
    public GameObject headLight_Obj;
    public Light[] headLight;
    public GameObject rearLight_Obj;

    public float lowIntensity = 0.8f;
    public float highIntensity = 1.34f;
    public float highBeamLight = 2f;
    public float currentLight = 0;
    private int isDimmed = 0;
    private bool highBeam = false;

    void Start()
    {
        rearLight_Obj.SetActive(false);
        headLight[0] = headLight_Obj.transform.Find("0").gameObject.GetComponent<Light>();
        headLight[1] = headLight_Obj.transform.Find("1").gameObject.GetComponent<Light>();
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
            headLight[0].intensity = currentLight;
            headLight[1].intensity = currentLight;
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
            currentLight = 0;
        }
        else if(isDimmed == 1)
        {
            currentLight = lowIntensity;
            headLight[0].intensity = lowIntensity;
            headLight[1].intensity = lowIntensity;
        }
        else if (isDimmed == 2)
        {
            currentLight = highIntensity;
            headLight[0].intensity = highIntensity;
            headLight[1].intensity = highIntensity;
        }
    }

    public void BreakLightOn()
    {
        rearLight_Obj.SetActive(true);
    }

    public void BreakLightOff()
    {
        rearLight_Obj.SetActive(false);
    }
}
