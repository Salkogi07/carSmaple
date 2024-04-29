using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoomCar : MonoBehaviour
{
    public float targetValue = 10f; // 감지할 특정 값
    private float currentValue; // 현재 값
    private float detectionTime1 = 7f; // 감지 시간
    private float detectionTime2 = 10f; // 감지 시간
    private float detectionTime3 = 4f; // 감지 시간
    private float elapsedTime = 0f; // 경과 시간
    private bool isDetected = false; // 감지 여부

    public GameObject boom1;
    public GameObject boom2;
    public GameObject boom3;

    private void Update()
    {
        // 현재 값이 감지할 값과 같은지 확인
        if (currentValue == targetValue)
        {
            // 경과 시간 증가
            elapsedTime += Time.deltaTime;

            // 경과 시간이 감지 시간을 초과하면 감지 완료
            if (elapsedTime >= detectionTime1)
            {
                isDetected = true;
                Debug.Log("Value detected for 3 seconds!");
            }
        }
        else
        {
            // 현재 값이 감지할 값과 다르면 감지 초기화
            elapsedTime = 0f;
            isDetected = false;
        }
    }
}
