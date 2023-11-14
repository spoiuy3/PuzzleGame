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
        // 2�ʸ��� SpawnObject �Լ��� �ݺ� ȣ��
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
        Tracker.a = a;
    }

    
    void SpawnObject()
    {
        // objectToSpawn�� ���� ���� ��ġ�� ����
        GameObject spawnedObject = Instantiate(mob, transform.position, Quaternion.identity);


        // ���� �ð� �ڿ� ��������� ����
        Destroy(spawnedObject, destroyDelay);
    }

}
