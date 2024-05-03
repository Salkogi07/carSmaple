using UnityEngine;

public class CarLight : MonoBehaviour
{
    public GameObject headLight_Obj;
    public Light[] headLight;
    public float lowIntensity = 0.8f;
    public float highIntensity = 1.34f;
    private int isDimmed = 0;

    void Start()
    {
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
    }

    void ToggleLights()
    {
        if(isDimmed == 0)
        {
            headLight_Obj.SetActive(false);
        }
        else if(isDimmed == 1)
        {
            headLight_Obj.SetActive(true);
            headLight[0].intensity = lowIntensity;
            headLight[1].intensity = lowIntensity;
        }
        else if (isDimmed == 2)
        {
            headLight_Obj.SetActive(true);
            headLight[0].intensity = highIntensity;
            headLight[1].intensity = highIntensity;
        }
    }
}
