using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;  // The sensitivity of the mouse
    public Transform playerBody;  // The player's body transform
    private float xRotation = 0f;  // The x rotation of the camera

    private void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Get the mouse movement delta
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;



        // Rotate the camera vertically based on mouse movement, clamped between -90 and 90 degrees
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        // Rotate the player body horizontally based on mouse movement
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
