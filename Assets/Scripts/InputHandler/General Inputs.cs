using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralInputs : InputHandler
{
    [SerializeField] private GameObject         exitConfirmationScreen;
    private InputHandler                        exitConfirmationInputs;
    private PlayerMovement                      playerMovement;
    private CameraManager                       cameraManager;
    private KeyCode                             interactionKey = KeyCode.Mouse0;
    private float                               rotationX;
    private float                               rotationY;

    private float                               horizontalInput;
    private float                               verticalInput;
    private float                               mouseX;
    private float                               mouseY;
    [SerializeField] private float              mouseSensitivityX;
    [SerializeField] private float              mouseSensitivityY;
    private float                               mouseXLimit = 88f;


    // Update is called at the start
    private void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        cameraManager = GameObject.FindWithTag("MainCamera").GetComponent<CameraManager>();
        exitConfirmationInputs = gameObject.GetComponent<ExitConfirmationInputs>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        ReceiveKeyboardInput();
        ReceiveMouseInput();
        HandleMouseInput();

        SendValues();
    }

    private void ReceiveKeyboardInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void ReceiveMouseInput()
    {
        mouseX = mouseSensitivityX * Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        mouseY = mouseSensitivityY * Input.GetAxisRaw("Mouse Y") * Time.deltaTime;

        if (Input.GetKeyDown(interactionKey))
        {
            cameraManager.TryInteract();   
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitConfirmationScreen.SetActive(true);

            InputHandler[] inputHandlers = gameObject.GetComponents<InputHandler>();

            foreach(InputHandler inputHandler in inputHandlers)
            {
                if(inputHandler != exitConfirmationInputs)
                {
                    inputHandler.enabled = false;
                }
                else
                {
                    inputHandler.enabled = true;
                }
            }
        }
    }

    private void HandleMouseInput()
    {
        rotationX += mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, -mouseXLimit, mouseXLimit);
    }

    private void SendValues()
    {
        playerMovement.ReceiveValues(rotationY, verticalInput, horizontalInput);
        cameraManager.ReceiveValues(rotationX, rotationY);
    }
}