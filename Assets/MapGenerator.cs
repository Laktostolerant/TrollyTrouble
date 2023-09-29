using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        int chosenZone = SelectRandomZoneIndex();
        int numberOftiles = Random.Range(zones[chosenZone].MinSize, zones[chosenZone].MaxSize);

        for(int i = 0; i < numberOftiles; i++)
        {
            SpawnNewTile(chosenZone);
        }

        Vector3 newTilePosition = originTransform.position;
        Instantiate(zones[chosenZone].TunnelPrefab, new Vector3(originTransform.position.x, originTransform.position.y, originTransform.position.z + (50 * numberOfTilesSpawned)), Quaternion.identity);

        //StartCoroutine(Fader(true));
    }


    private void FixedUpdate()
    {
        cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, cameraObj.transform.position.y, cameraObj.transform.position.z + 1.5f);
    }

    void SpawnNewTile(int zoneID)
    {
        Vector3 newTilePosition = originTransform.position;
        Quaternion rot = Quaternion.identity;

        newTilePosition = new Vector3(originTransform.position.x, originTransform.position.y, originTransform.position.z + (50 * numberOfTilesSpawned));
        GameObject temp = Instantiate(zones[zoneID].Tiles[Random.Range(0, zones[0].Tiles.Length)], newTilePosition, rot);
        tiles.Add(temp);

        numberOfTilesSpawned++;
    }

    public int SelectRandomZoneIndex()
    {
        int totalWeight = 0;
        int additiveWeight = 0;
        int randomChosenValue = Random.Range(0, totalWeight);

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

    IEnumerator Fader(bool darken)
    {
        Color c = fadeImage.color;
        int multiplier;


        multiplier = darken ? 1 : -1;

        for(int i = 0; i < 101; i++)
        {
            float incriment = i / 100f;

            Debug.Log("i: " + i);
            Debug.Log("incriment: " + incriment);

            c.a = incriment * multiplier;
            fadeImage.color = c;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
