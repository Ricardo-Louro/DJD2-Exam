//Imports
using UnityEngine;

//Class which defines the player's movement
public class PlayerMovement : MonoBehaviour
{
    //The value for the player's movement speed
    [SerializeField] private float      moveSpeed = 3;
    //The character controller component
    private CharacterController         charController;
    //The value of the player's rotation on the Y Axis
    private float                       rotationY;
    //The value of the input on the vertical axis (from 0 to 1)
    private float                       verticalInput;
    //The value of the input on the horizontal axis (from 0 to 1)
    private float                       horizontalInput;
    
    //Start is called before the first frame update
    private void Start()
    {
        //Stores the reference to the character controller
        charController = gameObject.GetComponent<CharacterController>();
    }

    //Update is called every frame after the first frame in which this script is active
    private void Update()
    {
        //Rotate the player on the Y Axis
        RotatePlayer();
        //Move the player's position
        MovePlayer();
    }
    
    //Rotate the player on the Y Axis
    private void RotatePlayer()
    {
        //Set the player's rotation as the rotationY value on the Y Axis and as 0 on all others
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    //Move the player's position
    private void MovePlayer()
    {
        //Calculate a move direction vector based on the inputs and the current orientation of the player
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        
        //Move the player according in this direction vector based on the selected movement speed without influence from the frame rate
        charController.SimpleMove(moveDirection.normalized * moveSpeed);
    }

    //This method is public so it can be called and allows this script to receive values from others
    public void ReceiveValues(float rotationY, float verticalInput, float horizontalInput)
    {
        //Set the rotationY value to be the one provided in this method's signature
        this.rotationY = rotationY;
        //Set the vertical input value to be the one provided in this method's signature
        this.verticalInput = verticalInput;
        //Set the horizontal input value to be the one provided in this method's signature
        this.horizontalInput = horizontalInput; 
    }
}