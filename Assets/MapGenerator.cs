using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject tileObject;
    List<GameObject> tiles = new List<GameObject>();

    [SerializeField] GameObject cameraObj;

    [SerializeField] Transform originTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private void FixedUpdate()
    {
        cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, transform.position.y, transform.position.z);
    }

    IEnumerator Spawner()
    {
        Vector3 newTilePosition = originTransform.position;
        Quaternion rot = Quaternion.identity;

        for (int i = 0; i < 250; i++)
        {
            newTilePosition = new Vector3(originTransform.position.x, originTransform.position.y, originTransform.position.z + (50 * i));
            GameObject temp = Instantiate(tileObject, newTilePosition, rot);
            tiles.Add(temp);
            StartCoroutine(Despawn(temp));

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Despawn(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        Destroy(obj);
    }
}
