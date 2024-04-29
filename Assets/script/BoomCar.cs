using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoomCar : MonoBehaviour
{
    public float targetValue = 10f; // ������ Ư�� ��
    private float currentValue; // ���� ��
    private float detectionTime1 = 7f; // ���� �ð�
    private float detectionTime2 = 10f; // ���� �ð�
    private float detectionTime3 = 4f; // ���� �ð�
    private float elapsedTime = 0f; // ��� �ð�
    private bool isDetected = false; // ���� ����

    public GameObject boom1;
    public GameObject boom2;
    public GameObject boom3;

    private void Update()
    {
        // ���� ���� ������ ���� ������ Ȯ��
        if (currentValue == targetValue)
        {
            // ��� �ð� ����
            elapsedTime += Time.deltaTime;

            // ��� �ð��� ���� �ð��� �ʰ��ϸ� ���� �Ϸ�
            if (elapsedTime >= detectionTime1)
            {
                isDetected = true;
                Debug.Log("Value detected for 3 seconds!");
            }
        }
        else
        {
            // ���� ���� ������ ���� �ٸ��� ���� �ʱ�ȭ
            elapsedTime = 0f;
            isDetected = false;
        }
    }
}
