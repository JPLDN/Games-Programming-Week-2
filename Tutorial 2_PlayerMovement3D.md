# Player Movement 3D Unity Tutorial
## In this tutorial, we will be showing how Player Movement is done in a 3d environment in Unity

### Firstly, you want create or open up a scene in Unity 3D.

1. For my tutorial, I simply used a Capsule as a temporary object to be used as my player, so I created it by going to GameObject at the top of Unity -> 3D Object and selected Capsule.
2. We'll click our Player then on right side, click add component, and add Character Controller.
3. If you haven't already, create a scripts folder by clicking your assets folder in Unity, right click and select Create -> Folder and call it Scripts.
4. Now create a script by right clicking in the Scripts folder, click "create" then select Create "C# script".
5. Double click on the script and Visual Studios should pop-up. 
```.cs
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 3f;
    public float runSpeed = 7f;
    public float jumpPower = 7f;
    public float gravity = 12f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;


    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;
```
These are the variables we're going to be using for our player movement. Firstly the public variables: the playerCamera is simply to reference the First Person Camera for our first tutorial, for our mouse controlled look-direction. The walkSpeed, runSpeed, jumpPower and gravity variables defines the movement parameters for those exact actions, running, walking, jumping and the gravity. lookSpeed and lookXLimit variables are to controll how fast the player can look around with the mouse movements and the verticle angle limits for looking up and down. And finally for default height, it's simply just to set the default height of the player (used when player is grounded).

For our private variables: moveDirection is about the player's movement direction (including gravity and jumping). rotationX is about tracking the camera's vertical rotation (looking up and down). characterController is a reference to Unity's character controller component which is used for player movement And last, canMove is a flag to toggle whether if the player is allowed to move or not.

6. We now begin coding the other parts of the script. We're going to lock and hide the cursor in our void start placement which locks the cursor to the centre of the screen for first person movement, as well as reference our character controller component. 
```.cs
void Start()
{
    characterController = GetComponent<CharacterController>();
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}
```
7. Now we go into void Update and begin coding there. 
```.cs
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
```

