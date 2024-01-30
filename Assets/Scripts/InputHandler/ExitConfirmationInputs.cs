using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitConfirmationInputs : InputHandler
{
    [SerializeField] private GameObject     exitConfirmationScreen;
    private InputHandler                    regularInput;

    // Start is called before the first frame update
    void Start()
    {
        regularInput = gameObject.GetComponent<GeneralInputs>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Application.Quit();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitConfirmationScreen.SetActive(false);

            InputHandler[] inputHandlers = gameObject.GetComponents<InputHandler>();

            foreach(InputHandler inputHandler in inputHandlers)
            {
                if(inputHandler != regularInput)
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
}
