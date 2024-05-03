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

    bool isBlinking = false;
    Coroutine blinkCoroutine; // Store the coroutine instance

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
            if (!isBlinking)
            {
                blinkCoroutine = StartCoroutine(BlinkIcon());
            }
            warringImage.gameObject.SetActive(true); // 경고 이미지를 보여줍니다.
        }
        else
        {
            if (isBlinking)
            {
                StopCoroutine(blinkCoroutine); // 코루틴을 중지합니다.
                isBlinking = false;
                warringIcon.gameObject.SetActive(true); // 경고 아이콘을 보여줍니다.
            }
            warringImage.gameObject.SetActive(false); // 경고 이미지를 숨깁니다.
        }
    }

    IEnumerator BlinkIcon()
    {
        isBlinking = true;
        warringImage.gameObject.SetActive(true); // 깜박이기 시작할 때 이미지를 먼저 보이게 합니다.
        yield return new WaitForSeconds(0.5f); // 0.5초 동안 기다립니다.

        while (true)
        {
            warringIcon.gameObject.SetActive(!warringIcon.gameObject.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
