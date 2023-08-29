using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMotor : MonoBehaviour
{
    [SerializeField] float gravity = -9.8f;
    [SerializeField] int speed = 5;
    [SerializeField] float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrouded;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrouded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrouded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if(isGrouded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
