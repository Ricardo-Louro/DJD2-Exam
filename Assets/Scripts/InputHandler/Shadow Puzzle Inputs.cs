using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShadowPuzzleInputs : InputHandler
{
    [SerializeField] private GameObject regularCamera;
    [SerializeField] private GameObject puzzleCamera;
    [SerializeField] private GameObject puzzleObject;
    private InputHandler regularInput;

    // Start is called before the first frame update
    private void Start()
    {
        regularInput = gameObject.GetComponent<GeneralInputs>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            ExitPuzzle();
        else
        {
            puzzleObject.transform.Rotate(0, -Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), Space.World);
        }

    }

    public void ExitPuzzle()
    {
        regularCamera.SetActive(true);
        puzzleCamera.SetActive(false);
        regularInput.enabled = true;
        enabled = false;
    }
}
