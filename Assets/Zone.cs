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


    [SerializeField] GameObject tunnelEntrance;
    public GameObject TunnelEntrance { get {  return tunnelEntrance; } set {  tunnelEntrance = value; } }


    [SerializeField] GameObject tunnelExit;
    public GameObject TunnelExit { get { return tunnelExit; } set { tunnelExit = value; } }


    [Range(1, 100)]
    [SerializeField] int zoneMinSize;
    public int MinSize { get { return zoneMinSize; } set { zoneMinSize = value; } }


    [Range(2, 300)]
    [SerializeField] int zoneMaxSize;
    public int MaxSize { get { return zoneMaxSize; } set { zoneMaxSize = value; } }


    [SerializeField] Skybox skybox;
    [SerializeField] float brightness;
}
