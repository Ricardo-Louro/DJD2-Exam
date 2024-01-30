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
    private float[] currentValues;
    private bool changedValues;

    private void Start()
    {
        changedValues = true;
    }
    

    // Update is called once per frame
    private void Update()
    {
        if(changedValues)
        {
            bool failedTest = false;
            currentValues = new float[4] {letter1_transform.rotation.z,
                                          letter2_transform.rotation.z,
                                          letter3_transform.rotation.z,
                                          letter4_transform.rotation.z};

            for(int index = 0; index <= 3; index++)
            {
                float comparator = (currentValues[index] - solutionArray[index] / 360);

                if(comparator % 1 != 0)
                {
                    failedTest = true;
                }
            }

            if(!failedTest)
            {
                Debug.Log("SUCCESSFUL TEST");
            }

            changedValues = false;
        }
    }

    public void FlagChanges()
    {
        changedValues = true;
    }
}
