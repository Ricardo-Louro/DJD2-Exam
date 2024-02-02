using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePuzzle : Interactive
{
    [SerializeField] private GameObject inputHandler;
    [SerializeField] private GameObject newCamera;
    [SerializeField] private InputHandler chosenInputs;

    public void Start()
    {
        interactionMessage = interactionMessages[0];
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    public override void Interact()
    {
        if(CheckRequirements())
        {
            ToggleCam();
            ToggleInputHandlers();
        }
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

    public void ConsumeRequirementsPub()
    {
        ConsumeRequirements();
    }
}
