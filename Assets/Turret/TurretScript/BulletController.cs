using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 1000f;
    private float lifeTime = 8f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(rb.transform.forward * bulletSpeed);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Här kan vi kolla om vi träffar spelaren. 
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<movement>().Damadge();
            Destroy(gameObject);
        }
    }
}