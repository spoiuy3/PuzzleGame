using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public GameObject mob;
    public float spawnInterval = 2f;
    public float moveSpeed = 5f;
    public float destroyDelay = 10f;
    public Vector3 a;

    void Start()
    {
        // 2초마다 SpawnObject 함수를 반복 호출
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
        Tracker.a = a;
    }

    
    void SpawnObject()
    {
        // objectToSpawn을 현재 스폰 위치에 생성
        GameObject spawnedObject = Instantiate(mob, transform.position, Quaternion.identity);


        // 일정 시간 뒤에 사라지도록 설정
        Destroy(spawnedObject, destroyDelay);
    }

}
