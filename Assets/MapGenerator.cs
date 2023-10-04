using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject tileObject;
    List<GameObject> tiles = new List<GameObject>();
    int numberOfTilesSpawned;

    [SerializeField] Zone[] zones;

    [SerializeField] GameObject cameraObj;

    Vector3 cameraTargetPosition;

    [SerializeField] Transform originTransform;

    [SerializeField] Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        GenerateZone();
    }

    void GenerateZone()
    {
        Debug.Log("aye made a new zone");

        int chosenZone = SelectRandomZoneIndex();
        int numberOftiles = UnityEngine.Random.Range(zones[chosenZone].MinSize, zones[chosenZone].MaxSize);

        for(int i = 0; i < numberOftiles; i++)
        {
            SelectNewZoneTileFromList(chosenZone);
        }

        SpawnNewTile(zones[chosenZone].TunnelEntrance);
        numberOftiles++;
        SpawnNewTile(zones[chosenZone].TunnelExit);
        numberOftiles++;
    }


    private void FixedUpdate()
    {
        cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, cameraObj.transform.position.y, cameraObj.transform.position.z + 1.5f);
    }

    void SelectNewZoneTileFromList(int zoneID)
    {
        GameObject chosenTile = zones[zoneID].Tiles[UnityEngine.Random.Range(0, zones[0].Tiles.Length)];
        SpawnNewTile(chosenTile);
    }

    void SpawnNewTile(GameObject tile)
    {
        Vector3 newTilePosition = originTransform.position;
        Quaternion rot = Quaternion.identity;

        newTilePosition = new Vector3(originTransform.position.x, originTransform.position.y, originTransform.position.z + (50 * numberOfTilesSpawned));
        GameObject temp = Instantiate(tile, newTilePosition, rot);
        tiles.Add(temp);

        numberOfTilesSpawned++;
    }

    public int SelectRandomZoneIndex()
    {
        int totalWeight = 0;
        int additiveWeight = 0;
        int randomChosenValue = UnityEngine.Random.Range(0, totalWeight);

        if (zones == null || zones.Length == 0)
        {
            Debug.LogError("The 'zones' array is empty or null.");
            return -1; // Error code
        }

        // Calculate the total weight
        foreach (Zone zone in zones)
        {
            totalWeight += zone.Weight;
        }

        // Use Random.Range to select an index based on the weights

        for (int i = 0; i < zones.Length; i++)
        {
            additiveWeight += zones[i].Weight;
            if (randomChosenValue < additiveWeight)
            {
                return i; // Return the index of the selected zone
            }
        }

        Debug.LogError("Failed to select a random zone index.");
        return -1;
    }

    IEnumerator KillPreviousZone()
    {
        Debug.Log("time to put the ol' buggers in limbo.");

        List<GameObject> limboList = new List<GameObject>();

        foreach (GameObject zone in tiles)
        {
            limboList.Add(zone);
        }

        GenerateZone();

        yield return new WaitForSeconds(3);

        foreach (GameObject zone in limboList)
        {
            Destroy(zone);
        }
    }

    public void GoToFader(bool darken)
    {
        StartCoroutine(Fader(darken));  
    }

    IEnumerator Fader(bool darken)
    {
        Debug.Log("fadin time");

        if(!darken)
            StartCoroutine(KillPreviousZone());

        Color c = fadeImage.color;

        for (int i = 0; i < 101; i++)
        {
            float incriment = i / 100f;

            c.a = darken ? incriment : 1 - incriment;
            fadeImage.color = c;
            yield return new WaitForSeconds(0.005f);
        }
    }

}
