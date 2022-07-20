using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundLayer;
    public Vector3 velocity;
    private bool isGrounded;
    public float jumpHeight = 1.5f;


    void Start()
    {

    }


    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
