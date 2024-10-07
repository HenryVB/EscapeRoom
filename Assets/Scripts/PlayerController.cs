using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float turnSpeed = 50f;
    [SerializeField]
    private float jumpForce = 5f;
    private Rigidbody rb;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");


        Vector3 movement = transform.forward * moveVertical * moveForce;
        rb.AddForce(movement);
        //Vector3 movement = new Vector3(moveHorizontal,0,moveVertical) * -1;
        //rb.AddForce(movement * moveForce, ForceMode.Force);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, moveHorizontal * turnSpeed * Time.fixedDeltaTime, 0)));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }

        /*
        float rotationOrientation = 0;

        if (Input.GetKeyDown(KeyCode.Q))
            rotationOrientation = 1;
        else if (Input.GetKeyDown(KeyCode.E))
            rotationOrientation = -1;

        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, rotationOrientation * turnSpeed * Time.deltaTime, 0)));
        */
    }

}
