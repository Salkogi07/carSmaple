using UnityEngine;

public class Gear : MonoBehaviour
{
    // 0:P, 1:R, 2:N, 3:D 
    public string[] gears = { "P", "R", "N", "D" };
    public int currentGear = 0;

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
    }

    void IncreaseGear()
    {
        if (currentGear < 3)
        {
            currentGear++;
        }
    }

    void DecreaseGear()
    {
        if (currentGear > 0)
        {
            currentGear--;
        }

    }
}