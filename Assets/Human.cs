using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    bool obstructed;
    LayerMask humanMask = (1 << 0) | (0 << 6);

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1.2f, 2f);
        Invoke("CheckAhead", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (obstructed)
            return;

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + speed), Time.fixedDeltaTime);
    }

    void CheckAhead()
    {

        Vector3 originPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

        Debug.DrawRay(originPos, transform.forward * 5, Color.red, 0.5f);
        if (Physics.Raycast(originPos, Vector3.forward, 5, humanMask))
        {
            obstructed = true;
            Animator animator = GetComponentInChildren<Animator>();
            animator.SetBool("running", false);
            return;
        }

        Invoke("CheckAhead", 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pruner"))
        {
            Debug.Log("im die.");
            Destroy(gameObject);
        }
    }
}
