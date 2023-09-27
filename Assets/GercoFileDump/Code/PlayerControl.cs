using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (this.transform.eulerAngles.y < 55)
            {
                if (this.transform.position.x > -13 || this.transform.eulerAngles.y > 45)
                {
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y - 50, this.transform.eulerAngles.z);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.transform.eulerAngles.y < 45 || this.transform.eulerAngles.y > 300)
            {
                if (this.transform.position.x < 13 || this.transform.eulerAngles.y > 300)
                {
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 50, this.transform.eulerAngles.z);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && this.transform.position.x > -13)
        {
            this.transform.position = new Vector3(this.transform.position.x - 7, this.transform.position.y, this.transform.position.z);
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 0, this.transform.eulerAngles.z);
        }

        if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x < 13)
        {
            this.transform.position = new Vector3(this.transform.position.x + 7, this.transform.position.y, this.transform.position.z);
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 0, this.transform.eulerAngles.z);
        }

    }
}
