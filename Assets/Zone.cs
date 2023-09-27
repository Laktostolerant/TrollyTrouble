using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Zone : ScriptableObject
{
    [SerializeField] int weight;

    [SerializeField] GameObject[] tiles;
    public GameObject[] Tiles { get { return tiles; } private set { } }

    [SerializeField] GameObject tunnelPrefab;

    [Range(30, 100)]
    [SerializeField] int zoneMinSize;

    [Range(31, 300)]
    [SerializeField] int zoneMaxSize;

    [SerializeField] Skybox skybox;
    [SerializeField] float brightness;
}
