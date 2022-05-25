using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    [SerializeField] GameObject targetObject;
    [SerializeField] bool isPlayerDetected = false;
    [SerializeField] GameObject turretBullet;
    [SerializeField] GameObject muzzlePosition;
    private float lastFire = 0;
    [SerializeField] float rateOfFire = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        if (isPlayerDetected)
        {
            Vector3 targetPosition = targetObject.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);

            Ray ray = new Ray(muzzlePosition.transform.position, targetPosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 20f))
            {
                if(hit.collider.tag == "Player")
                {
                    if(Time.time > rateOfFire + lastFire)
                    {
                        Instantiate(turretBullet, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
                        lastFire = Time.time;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerDetected = true;
            targetObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerDetected = false;
            targetObject = null;
        }
    }

    IEnumerator turretFire()
    {
        //
        yield return new WaitForSeconds(rateOfFire);
        Debug.Log("Fire!");
    }
}