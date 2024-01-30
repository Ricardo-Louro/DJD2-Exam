using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePuzzle : Interactive
{
    [SerializeField] private GameObject inputHandler;
    [SerializeField] private GameObject newCamera;
    [SerializeField] private InputHandler chosenInputs;

    public override void Interact()
    {
        ToggleCam();
        ToggleInputHandlers();
    }

    private void ToggleCam()
    {
        newCamera.SetActive(true);
        Camera.main.gameObject.SetActive(false);
    }

    private void ToggleInputHandlers()
    {
        InputHandler[] inputHandlers = inputHandler.GetComponents<InputHandler>();

        foreach(InputHandler inputHandler in inputHandlers)
        {
            if(inputHandler != chosenInputs)
                inputHandler.enabled = false;
            else
                inputHandler.enabled = true;
        }
    }
}
