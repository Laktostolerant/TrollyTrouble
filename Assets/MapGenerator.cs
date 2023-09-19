using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject tileObject;
    List<GameObject> tiles = new List<GameObject>();
    int numberOfTilesSpawned;

    [SerializeField] GameObject cameraObj;

    Vector3 cameraTargetPosition;

    [SerializeField] Transform originTransform;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewTile", 3, 0.25f);
    }

    private void FixedUpdate()
    {
        cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, cameraObj.transform.position.y, cameraObj.transform.position.z + 1.5f);
    }

    void SpawnNewTile()
    {
        Vector3 newTilePosition = originTransform.position;
        Quaternion rot = Quaternion.identity;

        newTilePosition = new Vector3(originTransform.position.x, originTransform.position.y, originTransform.position.z + (50 * numberOfTilesSpawned));
        GameObject temp = Instantiate(tileObject, newTilePosition, rot);
        tiles.Add(temp);

        numberOfTilesSpawned++;
        StartCoroutine(Despawn(temp));
    }

    IEnumerator Despawn(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        Destroy(obj);
    }
}
