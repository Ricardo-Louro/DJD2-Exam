//Imports
using System.Linq;
using UnityEngine;

//Class determining the behavior of each individual Crucifix in the Crucifix Puzzle
public class Crucifix : Interactive
{
    //The index corresponding to this particular crucifix within the solution array
    [SerializeField] private int                solutionIndex;
    //Static array containing the current status of the puzzle so that every crucifix has access to the exact same one
    private static bool[]                       solutionArray = new bool [] {false,false,false,false,false, false};
    //Static array containing the correct solution to the puzzle so it can be checked against the current one
    private static bool[]                       actualSolutionArray = new bool[] {false, true, true, false, true, false};
    //Bool containing the current status of the crucifix to be utilized when updating the current solution array
    private bool                                currentStatus;
    //Reference to the animator component attached to this crucifix
    private Animator                            animator;

    //TEMPORARY image to be displayed when achieving the correct solution
    [SerializeField] private GameObject         endImage;

    //Start runs on the first frame in which this script is active
    private void Start()
    {
        //Set the current status as false
        currentStatus = false;
        //Declare a reference to the animator component attached to this crucifix
        animator = gameObject.GetComponent<Animator>();
        //Set the interaction message to be the desired one
        interactionMessage = interactionMessages[0];
    }

    //Method which declares the behavior to be executed when this object is interacted with
    public override void Interact()
    {
        //Toggle the current state of this crucifix
        ToggleState();

        //If the current state of this crucifix is set as true (face up)...
        if(currentStatus == true)
        {
            //Activate the animation trigger which rotates the crucifix down
            animator.SetTrigger("RotateDown");
        }
        //If the current state of this crucifix is set as true (face up)...
        else
        {
            //Activate the animation trigger which rotates the crucifix up
            animator.SetTrigger("RotateUp");
        }

        //Update the current solution array in the proper index with the new status
        solutionArray[solutionIndex] = currentStatus;

        //If the solution has been achieved
        if(CheckSolution())
        {
            //TEMPORARY set the end prototype image as true
            endImage.SetActive(true);
        }
    }

    //Toggles the current state of the crucifix
    private void ToggleState()
    {
        //Switches the current state of the crucifix with the opposite one (false with true and vice versa)
        currentStatus = !currentStatus;
    }

    //Checks if the solution has been achieved
    private bool CheckSolution()
    {
        //Returns the comparison of the solution array with the correct solution array. If they're the same, return true. If not, return false.
        return Enumerable.SequenceEqual(solutionArray, actualSolutionArray);
    }
}
