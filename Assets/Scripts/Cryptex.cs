using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cryptex : MonoBehaviour
{
    [SerializeField] private float[] solutionArray;
    [SerializeField] private Transform letter1_transform;
    [SerializeField] private Transform letter2_transform;
    [SerializeField] private Transform letter3_transform;
    [SerializeField] private Transform letter4_transform;

    [SerializeField] private InputHandler currentInputs;

    private SceneSwitcher               sceneSwitcher;

    private bool changedValues;

    public IList<int> letter_value;

    private void Start()
    {
        changedValues = true;

        letter_value = new List<int>() { 0, 0, 0, 0 };

        sceneSwitcher = gameObject.GetComponent<SceneSwitcher>();
    }
    

    // Update is called once per frame
    private void Update()
    {
        if (changedValues)
        {
            if (letter_value[0] == solutionArray[0] &&
                letter_value[1] == solutionArray[1] &&
                letter_value[2] == solutionArray[2] &&
                letter_value[3] == solutionArray[3])
            {
                EndGame();
            }

            changedValues = false;
        }
    }

    public void FlagChanges()
    {
        changedValues = true;
    }

    private void EndGame()
    {
        sceneSwitcher.SwitchScene();

    }
}
