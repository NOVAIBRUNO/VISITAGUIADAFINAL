using UnityEngine;

public class SimpleFPS : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 1f;
    public float flySpeed = 5f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // MOUSE
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, mouseX, 0f);

        if (Camera.main != null)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        // MOVIMENTO
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;

        // SUBIR/DESCER
        if (Input.GetKey(KeyCode.Space))
            move.y += flySpeed;

        if (Input.GetKey(KeyCode.LeftControl))
            move.y -= flySpeed;

        transform.position += move * speed * Time.deltaTime;
    }
}