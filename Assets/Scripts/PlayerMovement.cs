using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Varibales: transform for object references, floats are numbers either - or +, Layermask references layers, bool for true or false, Vectors for directions and magnitudes
    // CharacterController is a reference to the controller component
    [SerializeField] Transform playerCamera;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float speed = 6.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    public float jumpHeight = 6f;
    float velocityY;
    bool isGrounded;

    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;

    CharacterController controller;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // hitting play defines our varibale by using GetComponent to tell script about CharacterController.
        // if state is bool = true, lock and show cursor
        controller = GetComponent<CharacterController>();

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouse();
        UpdateMove();
    }

    void UpdateMouse()

        // new Vector 2 for x and y of mouse movement, damping the movement between the target and current position.
        // Defining CameraCap Varibale and setting limits in the y axis using Mathf Clamp, specifing that we're talking about angles.
        // *cam movement by mouse sense and Vectors adding force.
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraCap -= currentMouseDelta.y * mouseSensitivity;

        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMove()
    {

        // Defines true condition for isGrounded and also Dimensions. Using a vectr for a target direction when using WASD, instant force.
        // Normalized to stop doubling speed when holding W & D or W & A. Smoothing force by damping between instant push of target and velocity taking in value of smooth move.
        // Defining VelocityY which is added and equal to gravity multiplied by 2f and Time.deltaTime. 
        // Defining another Vector3 pushing forward * current y and doing same with x axis * speed float. Vector up for upwards move * velocityY
        // Moving controller with variable which defines movement and *Time.deltaTime.
        // if statements conditions are met when it does calculation of all 3 values * and then square rooted which defines the value of velocityY which we added earlier.
        // Final thing fixes a bug with script

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontol"), Input.GetAxis("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        velocityY += gravity * 2f * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump")) ;
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded! && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }

    }
}


