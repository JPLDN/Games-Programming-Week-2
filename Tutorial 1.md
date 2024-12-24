# 3D First Person Camera POV 
## In this tutorial, we will be demonstrating how you create a First Person View Point of View in 3D Unity. The player will be in First Person and the camera will move according to the Player's mouse movements.

1. Create a scene in Unity, and then create a Game Object that will be used as your player and attach the Main Camera of the scene into the Player, becoming a child object to the Player Object.
2. Reset the Camera's Transform position, then change the Y axis Transform to 1. X and Z axis Transform Positions should be on 0.

### Now it's time to code, if you haven't already, Click on your assets folder, right click inside the folder, click Create -> Folder.

1. Create a C# Script inside the Script folder, by opening the Script folder, right clicking inside the folder, click Create -> C# Script
2. Open the script by double clicking and Visual Studios should open up.
3. We're first going to start off with Variables, so create some space above the void Start() statement by click above it and pressing Spacebar.
```.cs
public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0;

    bool lockedCursor = true;
```
The "public Transform player;" variable is to reference the player.
The "public float mouseSensitivity = 2f;" is to provide a value to the mouseSensitity, the value determines how strong the Mouse Sensitivity is.
The "float cameraVerticalRotation = 0;" is to simply make sure the camera is in its default position, straight, when pressing play in Unity.

4. Next, we go down to void Update(), and then we're going to collect the mouse input. 
```.cs
void Update()
{
  
    float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
    float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
```
This collects the Mouse Inputs, allowing you to move the camera with your mouse through both the X and Y axis. 
The "* mouseSensitivity* part is so that the inputs of your X and Y axis mouse movements have a value, and we previously put the value as 2, which determines how strong the mouse sensitivity is when moving your mouse.
