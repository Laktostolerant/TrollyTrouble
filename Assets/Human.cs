using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    bool obstructed;
    LayerMask humanMask = (1 << 0) | (0 << 6);
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2f, 5f);
        Invoke("CheckAhead", 0);
        animator = GetComponentInChildren<Animator>();
        //animator.speed = Random.Range()
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (obstructed)
            return;

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + speed), Time.fixedDeltaTime * speed);
    }

    void CheckAhead()
    {
        Vector3 originPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

        Debug.DrawRay(originPos, transform.forward * 5, Color.red, 0.5f);
        if (Physics.Raycast(originPos, Vector3.forward, 5, humanMask))
        {
            obstructed = true;
            animator.SetBool("running", false);
        }
        else
        {
            obstructed = false;
            animator.SetBool("running", true);
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
