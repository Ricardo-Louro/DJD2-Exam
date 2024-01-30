using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // Adjust this to control the mouse sensitivity

    private void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player's body based on the mouse input
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        // Rotate the camera up and down based on the mouse input
        float currentRotationX = transform.rotation.eulerAngles.x;
        float newRotationX = currentRotationX - mouseY * sensitivity;
        newRotationX = Mathf.Clamp(newRotationX, -90f, 90f); // Limit the vertical rotation

        transform.rotation = Quaternion.Euler(newRotationX, transform.rotation.eulerAngles.y, 0f);
    }
}
