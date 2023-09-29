using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Zone : ScriptableObject
{
    [SerializeField] int weight;
    public int Weight { get { return weight; } set {  weight = value; } }


    [SerializeField] GameObject[] tiles;
    public GameObject[] Tiles { get { return tiles; } set { tiles = value; } }

    [SerializeField] GameObject tunnelPrefab;
    public GameObject TunnelPrefab { get {  return tunnelPrefab; } set {  tunnelPrefab = value; } }

    [Range(30, 100)]
    [SerializeField] int zoneMinSize;
    public int MinSize { get { return zoneMinSize; } set { zoneMinSize = value; } }


    [Range(31, 300)]
    [SerializeField] int zoneMaxSize;
    public int MaxSize { get { return zoneMaxSize; } set { zoneMaxSize = value; } }


    [SerializeField] Skybox skybox;
    [SerializeField] float brightness;
}
