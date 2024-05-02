using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomb : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private float displayTime = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) // Player���� �浹�� �ƴ� ��쿡�� ����
        {
            Debug.Log("���� ����");

            // �浹 �� ������ ����
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, collision.GetContact(0).point, Quaternion.identity);

            // ���� �ð��� ���� �Ŀ� �ı�
            Destroy(spawnedPrefab, displayTime);
        }
    }
}
