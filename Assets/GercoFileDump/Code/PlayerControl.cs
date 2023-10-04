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

    void Update()
    {           

     if (Input.GetKeyDown(KeyCode.Q))
        {
            if (targetRotation > -50)
            {
                if (targetLocation > -13 || targetRotation == 50)
                {
                    targetRotation -= 50;
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
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && targetLocation > -13)
        {
            targetLocation -= 7;
            targetRotation = 0;
        }

        if (Input.GetKeyDown(KeyCode.D) && targetLocation < 13)
        {
            targetLocation += 7;
            targetRotation = 0;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetLocation, this.transform.position.y, this.transform.position.z), Time.deltaTime * 10);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, targetRotation, 0), Time.deltaTime * 10);
    }

}


