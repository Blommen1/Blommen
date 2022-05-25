using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject bullet;
    public float bulletspeed = 100f;
    public float JumpVelocity = 5f;
    public int life = 100;


    private Vector3 Movementspeed;
    [SerializeField]private float Walkspeed = 1f;
    private Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Rigidbody = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        Movementspeed = new Vector3 (H, 0, V);

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX, 0);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,
            this.transform.position + new Vector3(1, 0, 0),
                this.transform.rotation) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = this.transform.forward * bulletspeed;
        }

    }
    private void FixedUpdate()
    {
        Vector3 Direction = transform.TransformDirection(Movementspeed);
        Rigidbody.velocity = Direction* Walkspeed* Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }


    }
    public void Damadge()
    {
        life--;
    }
    
}
