using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float jumpForce;
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


        Vector3 movementVector = transform.forward * moveVertical * moveForce;
        rb.AddForce(movementVector,ForceMode.Force);
        //Vector3 movement = new Vector3(moveHorizontal,0,moveVertical) * -1;
        //rb.AddForce(movement * moveForce, ForceMode.Force);
        Vector3 rotationVector = new Vector3(0, moveHorizontal * turnSpeed * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationVector));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }

}
