using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAlignment : MonoBehaviour
{
    public GameObject wheelBase;
    public GameObject wheelGraphic;

    public WheelCollider wheelCol;

    public bool steerable;

    public float steeringAngle;

    RaycastHit hit;

    // 스프링과 댐퍼 상수
    public float springForce = 30000f; // 스프링 상수
    public float damperRate = 1000f; // 댐퍼 상수

    private Vector3 wheelPrevPos;
    private float wheelPrevCompression;

    void Start()
    {
        wheelPrevPos = wheelCol.transform.position;
    }

    void Update()
    {
        alignMeshToCollider();
    }

    void alignMeshToCollider()
    {
        // 지면과의 충돌을 검사하고 충돌 시 움직임을 계산
        if (Physics.Raycast(wheelCol.transform.position, -wheelCol.transform.up, out hit, wheelCol.suspensionDistance + wheelCol.radius))
        {
            Vector3 groundPos = hit.point + wheelCol.transform.up * wheelCol.radius;

            // 스프링 및 댐퍼 효과 적용
            float compression = 1f - ((groundPos - wheelCol.transform.position).magnitude / wheelCol.suspensionDistance);
            float compressionDelta = compression - wheelPrevCompression;
            Vector3 suspensionForce = wheelCol.transform.up * compressionDelta * springForce - wheelCol.transform.up * Vector3.Dot(wheelCol.attachedRigidbody.velocity, wheelCol.transform.up) * damperRate;

            // 물리 업데이트
            wheelCol.attachedRigidbody.AddForceAtPosition(suspensionForce, wheelCol.transform.position);

            wheelPrevCompression = compression;

            // 그래픽 위치 설정
            wheelGraphic.transform.position = groundPos;
        }
        else
        {
            // 충돌하지 않으면 기본 위치에 그래픽 표시
            wheelGraphic.transform.position = wheelCol.transform.position - (wheelCol.transform.up * wheelCol.suspensionDistance);
        }

        // 휠 조향 각도 적용
        if (steerable)
        {
            wheelCol.steerAngle = steeringAngle;
        }

        // 그래픽 회전
        wheelGraphic.transform.eulerAngles = new Vector3(wheelBase.transform.eulerAngles.x, wheelBase.transform.eulerAngles.y + wheelCol.steerAngle, wheelBase.transform.eulerAngles.z);
        wheelGraphic.transform.Rotate(wheelCol.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}
