using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFader : MonoBehaviour
{
    [SerializeField] bool darken;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Train")
        {
            MapGenerator mapGenerator = FindObjectOfType<MapGenerator>();
            mapGenerator.GoToFader(darken);
        }
    }
}
