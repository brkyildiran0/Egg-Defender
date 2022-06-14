using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject rim;
    [SerializeField] float spawnTimer = 1.0f;

    void Start()
    {
        StartCoroutine(SpawnRims());
    }

    IEnumerator SpawnRims()
    {
        while (true)
        {
            Instantiate(rim, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
