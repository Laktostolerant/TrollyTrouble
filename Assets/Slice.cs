using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    [SerializeField] GameObject[] propSpawnPoints;
    [SerializeField] GameObject[] propList;

    List<GameObject> instantiatedProps = new List<GameObject>();

    private void Start()
    {
        foreach (var prop in propSpawnPoints)
        {
            if( Random.Range(0, 10) > 8)
            {
                SpawnProp(prop.transform.position);
            }
        }
    }

    void SpawnProp(Vector3 spawnPosition)
    {
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        Instantiate(propList[Random.Range(0, propList.Length)], spawnPosition, randomRotation, transform);
    }
}
