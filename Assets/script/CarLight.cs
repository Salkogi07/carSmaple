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

    private float rearLightIntensity = 0f; // Rear light intensity variable

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
        if (isDimmed == 0)
        {
            currentHeadLight = 0;
            rearLightIntensity = 0f; // Update rear light intensity variable
        }
        else if (isDimmed == 1)
        {
            currentHeadLight = lowIntensity;
            rearLightIntensity = 2.3f; // Update rear light intensity variable
        }
        else if (isDimmed == 2)
        {
            currentHeadLight = highIntensity;
            rearLightIntensity = 2.3f; // Update rear light intensity variable
        }

        // Apply rear light intensity
        rearLight[0].intensity = rearLightIntensity;
        rearLight[1].intensity = rearLightIntensity;
    }

    public void BreakLightOn()
    {
        // Use the rear light intensity variable
        rearLight[0].intensity = 4f;
        rearLight[1].intensity = 4f;
    }

    public void BreakLightOff()
    {
        // Use the rear light intensity variable
        rearLight[0].intensity = rearLightIntensity;
        rearLight[1].intensity = rearLightIntensity;
    }
}
