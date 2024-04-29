using UnityEngine;

public class Gear : MonoBehaviour
{
    // 0:P, 1:R, 2:N, 3:D 
    string[] gears = { "P", "R", "N", "D" };
    int currentGear = 0;

    void Start()
    {
        Debug.Log("현재 기어: " + gears[currentGear]);
    }

    void Update()
    {
        //기어조작부분
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DecreaseGear();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            IncreaseGear();
        }

        //기어변환부분
        if (currentGear == 0)
        {
            Parking();
        }
        if (currentGear == 1)
        {
            Rewind();
        }
        if (currentGear == 2)
        {
            Neutrality();
        }
        if (currentGear == 3)
        {
            Driving();
        }
    }

    void IncreaseGear()
    {
        if (currentGear < gears.Length - 1)
        {
            currentGear++;
            Debug.Log("기어를 증가시켰습니다. 현재 기어: " + gears[currentGear]);
        }
        else
        {
            Debug.Log("이미 다땅김");
        }
    }

    void DecreaseGear()
    {
        if (currentGear > 0)
        {
            currentGear--;
            Debug.Log("기어를 감소시켰습니다. 현재 기어: " + gears[currentGear]);
        }
        else
        {
            Debug.Log("이미 다땅김");
        }
    }
    void Parking()
    {
        
    }
    void Rewind()
    {

    }
    void Neutrality()
    {

    }
    void Driving()
    {

    }
}