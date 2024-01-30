using UnityEngine;

public class GhostCamera : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    private GameObject player;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float mouseSensitivityX;
    [SerializeField] private float mouseSensitivityY;
    private float horizontalInput;
    private float verticalInput;

    private float rotationX;
    private float mouseX;
    private float rotationY;
    private float mouseY;

    //Start is called at the first frame in which this script is active
    private void Start()
    {
        player = gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = mouseSensitivityX * Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        mouseY = mouseSensitivityY * Input.GetAxisRaw("Mouse Y") * Time.deltaTime;

        rotationX += mouseX;
        rotationY += mouseY;

        player.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0);
        cam.transform.rotation = player.transform.rotation;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //Calculate a move direction vector based on the inputs and the current orientation of the player
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        //Move the player according in this direction vector based on the selected movement speed without influence from the frame rate
        player.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        cam.transform.position = player.transform.position;
    }
}
