using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public WheelAlignment[] steerableWheels;

    public float BreakPower;

    // Steering variables
    public float wheelRotateSpeed;
    public float wheelSteeringAngle;

    // Motor variables
    public float wheelAcceleration;
    public float wheelMaxSpeed;

    public Rigidbody RB;
    public Gear gear;
    public CarLight carLight;

    float KPH;
    float breakSpeed = 250;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        gear = GetComponent<Gear>();
        carLight = GetComponent<CarLight>();
    }

    // Update is called once per frame
    void Update()
    {
        wheelControl();
    }


    // Applies steering and motor torque
    void wheelControl()
    {
        bool rotateWheelKey = true;
        bool frontWheelKey = true;
        bool frontWheel = true;
        KPH = RB.velocity.magnitude * 3.6f;

        // 제한 속도 설정
        if (KPH > breakSpeed)
        {
            // 제한 속도를 초과할 경우 현재 속도를 제한 속도로 조정
            RB.velocity = (breakSpeed / 3.6f) * RB.velocity.normalized;
        }

        for (int i = 0; i < steerableWheels.Length; i++)
        {
            // Sets default steering angle
            steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, 0, Time.deltaTime * wheelRotateSpeed);
            // Sets default motor speed
            steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, 0, Time.deltaTime * wheelAcceleration);

            if (gear.currentGear == 0)
            {
                frontWheel = true;
                rotateWheelKey = false;
                frontWheelKey = false;
                steerableWheels[i].wheelCol.motorTorque = 0;
                breakSpeed = Mathf.Lerp(KPH, 0, Time.deltaTime * 2);
            }
            else if(gear.currentGear == 1)
            {
                frontWheel = false;
                frontWheelKey = true;
                rotateWheelKey = true;
            }
            else if(gear.currentGear == 2)
            {
                frontWheel = true;
                rotateWheelKey = false;
                frontWheelKey = false;
                steerableWheels[i].wheelCol.motorTorque = 0;
            }
            else if (gear.currentGear == 3)
            {
                frontWheel = true;
                frontWheelKey = true;
                rotateWheelKey = true;
            }

            if (frontWheel)
            {
                if (frontWheelKey)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration);
                    }
                }
            }
            else
            {
                if (frontWheelKey)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        steerableWheels[i].wheelCol.motorTorque = Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration * 100);
                    }
                }
            }

            // Motor controls
            if (rotateWheelKey)
            {
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

            if (Input.GetKey(KeyCode.S))
            {
                
                carLight.BreakLightOn();
                steerableWheels[i].wheelCol.motorTorque = 0;
                breakSpeed = Mathf.Lerp(KPH,0,Time.deltaTime * 2);
            }
            else
            {
                carLight.BreakLightOff();
                if(gear.currentGear != 0)
                {
                    breakSpeed = 250;
                }
            }    
        }
    }
}