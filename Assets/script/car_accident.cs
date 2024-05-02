using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomb : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private float displayTime = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) // Player와의 충돌이 아닌 경우에만 실행
        {
            Debug.Log("접촉 감지");

            // 충돌 시 프리팹 생성
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, collision.GetContact(0).point, Quaternion.identity);

            // 일정 시간이 지난 후에 파괴
            Destroy(spawnedPrefab, displayTime);
        }
    }
}
