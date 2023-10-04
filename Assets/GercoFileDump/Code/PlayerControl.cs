using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using EZCameraShake;
public class PlayerControl : MonoBehaviour
{
    public float targetRotation = 0;
    public float targetLocation = 0;
    [SerializeField] GameObject Trolley;

    void Update()
    {           

     if (Input.GetKeyDown(KeyCode.Q))
        {
            if (targetRotation > -50)
            {
                if (targetLocation > -13 || targetRotation == 50)
                {
                    targetRotation -= 50;
                    CameraShaker.Instance.ShakeOnce(1f, 1f, 0.1f, 2f);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (targetRotation < 50)
            {
                if (targetLocation < 13 || targetRotation == -50)
                {
                    targetRotation += 50;
                    CameraShaker.Instance.ShakeOnce(1f, 1f, 0.1f, 2f);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && targetLocation > -13)
        {
            targetLocation -= 7;
            targetRotation = 0;
            CameraShaker.Instance.ShakeOnce(1f, 1f, 0.1f, 2f);
        }

        if (Input.GetKeyDown(KeyCode.D) && targetLocation < 13)
        {
            targetLocation += 7;
            targetRotation = 0;
            CameraShaker.Instance.ShakeOnce(1f, 1f, 0.1f, 2f);
        }

        Trolley.transform.position = Vector3.Lerp(Trolley.transform.position, new Vector3(targetLocation, Trolley.transform.position.y, Trolley.transform.position.z), Time.deltaTime * 10);
        Trolley.transform.rotation = Quaternion.Lerp(Trolley.transform.rotation, Quaternion.Euler(0, targetRotation, 0), Time.deltaTime * 10);
    }

}


