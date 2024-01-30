//Imports
using UnityEngine;

//Class which allows us to enable another object by interacting with the one which incorporates this script 
public class Switch : Interactive
{
    //The object to be activated
    [SerializeField] private GameObject activateObject;
    //A flag to determine whether the current gameObject is to be destroyed or not
    [SerializeField] private bool destroyObject;
    
    //Start runs on the first frame in which this object is active
    private void Start()
    {
        //Set the interaction message
        interactionMessage = interactionMessages[0];
        //Store a reference to the player's inventory
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    //Runs when the player interacts with this object
    public override void Interact()
    {
        //If the player has all the necessary requirements...
        if(CheckRequirements())
        {
            //If it is flagged to consume the requirements...
            if(consumesRequirements)
            {
                //Clear the player's inventory from said requirements
                ConsumeRequirements();
            }
            
            //Activate the desired object
            activateObject.SetActive(true);
            
            //If it is flagged to have the switch game object destroyed...
            if(destroyObject)
            {
                //Destroy the switch game object...
                Destroy(gameObject);
            }
            //If it is not flagged to have the switch game object destroyed...
            else
            {
                //Destroy only this script so it cannot be triggered again
                Destroy(this);
            }
        }
    }
}
