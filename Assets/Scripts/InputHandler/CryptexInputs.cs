using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CryptexInputs: InputHandler
{
    [SerializeField] private GameObject     regularCamera;
    [SerializeField] private GameObject     puzzleCamera;
    [SerializeField] private Cryptex        cryptex;
    
    private InputHandler                    regularInput;
    
    [SerializeField] private Transform      letter1_transform;
    [SerializeField] private Transform      letter2_transform;
    [SerializeField] private Transform      letter3_transform;
    [SerializeField] private Transform      letter4_transform;

    private float                           rotationAngle;

    private IList<Transform>                letterRotationList;
    private int                             index;
    
    private void Start()
    {
        regularInput = gameObject.GetComponent<GeneralInputs>();

        letterRotationList = new List<Transform> {letter1_transform,
                                                  letter2_transform,
                                                  letter3_transform,
                                                  letter4_transform};

        rotationAngle = 13.846f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPuzzle();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if(index > 0)
            {
                index--;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            if(index < letterRotationList.Count - 1)
            {
                index++;
            }
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            letterRotationList[index].Rotate(0, 0, rotationAngle);
            cryptex.FlagChanges();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            letterRotationList[index].Rotate(0, 0, -rotationAngle);
            cryptex.FlagChanges();
        }
        
    }

    private void ExitPuzzle()
    {
        regularCamera.SetActive(true);
        puzzleCamera.SetActive(false);
        regularInput.enabled = true;
        enabled = false;
    }
}
