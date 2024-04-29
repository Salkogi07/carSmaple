using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCalculator : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    Gear gear;

    public Text SpeedText;
    public Text GearText;
    public Text RPMText;
    public Image warringImage;
    public Image warringIcon;

    int time;
    bool isBlinking = false;
    float blinkInterval = 0.5f; // Adjust this interval as needed

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gear = GetComponent<Gear>();
    }

    void FixedUpdate()
    {
        Vector3 vel = rb.velocity;
        Speed = rb.velocity.magnitude * 2.23693629f;

        SpeedText.text = Speed.ToString("0");
        GearText.text = gear.gears[gear.currentGear];

        if (Speed >= 240)
        {
            warringImage.gameObject.SetActive(true);
            if (!isBlinking)
            {
                StartCoroutine(BlinkIcon());
            }
        }
        else
        {
            warringImage.gameObject.SetActive(false);
            if (isBlinking)
            {
                StopCoroutine(BlinkIcon());
                isBlinking = false;
                warringIcon.gameObject.SetActive(true); // Ensure icon is visible when not blinking
            }
        }
    }

    IEnumerator BlinkIcon()
    {
        isBlinking = true;        
        while (true)
        {
            warringIcon.gameObject.SetActive(!warringIcon.gameObject.activeSelf);
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
