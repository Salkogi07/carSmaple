using UnityEngine;

public class Gear : MonoBehaviour
{
    // 0:P, 1:R, 2:N, 3:D 
    string[] gears = { "P", "R", "N", "D" };
    int currentGear = 0;

    void Start()
    {
        Debug.Log("���� ���: " + gears[currentGear]);
    }

    void Update()
    {
        //������ۺκ�
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DecreaseGear();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            IncreaseGear();
        }

        //��ȯ�κ�
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
            Debug.Log("�� �������׽��ϴ�. ���� ���: " + gears[currentGear]);
        }
        else
        {
            Debug.Log("�̹� �ٶ���");
        }
    }

    void DecreaseGear()
    {
        if (currentGear > 0)
        {
            currentGear--;
            Debug.Log("�� ���ҽ��׽��ϴ�. ���� ���: " + gears[currentGear]);
        }
        else
        {
            Debug.Log("�̹� �ٶ���");
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