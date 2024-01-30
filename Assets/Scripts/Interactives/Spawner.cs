//Imports
using UnityEngine;

//Class which adds elements to the player's inventory
public class Spawner : Interactive
{
    //The item which is to be added to the player's inventory
    [SerializeField] private PickableItem item;

    //Start runs on the first frame in which this object is active
    private void Start()
    {
        //Store a reference to the player's inventory
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    //Updates runs on every frame after the first one while this object is active
    private void Update()
    {
        //If the player's inventory contains all the requirements...
        if(CheckRequirements())
        {
            //Assign the interaction message (meaning it can now be interacted with)
            interactionMessage = interactionMessages[0];
        }
    }

    //If the player interacts with the game object which incorporates this script
    public override void Interact()
    {
        //If the player's inventory contains all the requirements...
        if(CheckRequirements())
        {   
            //If it is flagged to consume the requirements...
            if(consumesRequirements)
            {
                //Remove all the requirements from the player's inventory
                ConsumeRequirements();
            }

            //If the player does not already have the relevant item...
            if(!playerInventory.Has(item))
            {
                //Add the relevant item to the player's inventory
                playerInventory.Add(item);
                //Destroy this script so it cannot be triggered again
                Destroy(this);
            }
        }
    }
}