using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] bool lookCursor = true;
    private CharacterController characterController;
    private float testVariable;
    private int anotherTest;
    private char lastTest;

    float cameraPitch = 0f;
    float walkSpeed = 6.0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        if(lookCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    private void UpdateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //print(mouseDelta);
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);

        cameraPitch -= mouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        //playerCamera.Rotate(Vector3.right * -(mouseDelta.y * mouseSensitivity), Space.Self);
    }

    private void UpdateMovement()
    {
        Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDir.Normalize();

        Vector3 velociy = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed;
        //When a GameObject is rotated, the blue arrow representing the Z axis of the GameObject also changes direction.
        //arroz com feijão
        //duni duni ni te
        characterController.Move(velociy * Time.deltaTime);
    }
}
