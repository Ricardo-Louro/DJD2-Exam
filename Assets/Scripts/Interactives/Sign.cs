//Imports
using UnityEngine;

//This class describes a sign-like behavior to display messages to the player
public class Sign : Interactive
{
    //Starts runs on the first frame in which this script is active
    private void Start()
    {
        //Stores a reference to the player's inventory
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    //Updates runs every frame after the first one in which this script is active
    private void Update()
    {
        //If the player's inventory contains all the requirements...
        if(CheckRequirements())
        {
            //Set the message which will be displayed when you look at the item
            interactionMessage = interactionMessages[0];
        }
    }

    //Empty Interact method as it is obligatory to incorporate it into every Interactive but we do not want it to have any behaviors on interaction
    public override void Interact()
    {}
}