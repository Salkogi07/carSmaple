using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public WheelAlignment[] steerableWheels;

    public float BreakPower = 500;

    // Steering variables
    public float wheelRotateSpeed;
    public float wheelSteeringAngle;

    // Motor variables
    public float wheelAcceleration;
    public float wheelMaxSpeed;

    public Rigidbody RB;

    float KPH;
    float breakSpeed = 240;

    // Update is called once per frame
    void Update()
    {
        wheelControl();
    }

    // Applies steering and motor torque
    void wheelControl()
    {

        KPH = RB.velocity.magnitude * 2.23693629f;

        // 제한 속도 설정
        if (KPH > breakSpeed)
        {
            // 제한 속도를 초과할 경우 현재 속도를 제한 속도로 조정
            RB.velocity = (breakSpeed / 2.23693629f) * RB.velocity.normalized;
        }

        for (int i = 0; i < steerableWheels.Length; i++)
        {
            // Sets default steering angle
            steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, 0, Time.deltaTime * wheelRotateSpeed);
            // Sets default motor speed
            steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, 0, Time.deltaTime * wheelAcceleration);

            // Motor controls
            if (Input.GetKey(KeyCode.W))
            {
                steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration);
            }

            if (Input.GetKey(KeyCode.S))
            {
                breakSpeed = Mathf.Lerp(KPH,0,Time.deltaTime * 2);
            }
            else
            {
                breakSpeed = 240;
            }

            // Steering controls
            if (Input.GetKey(KeyCode.A))
            {
                steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, -wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
            }
        }
    }
}