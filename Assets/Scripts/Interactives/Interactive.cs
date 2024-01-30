using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    [SerializeField] protected List<PickableItem>   requirements;
    [SerializeField] public List<string>            interactionMessages;
    [SerializeField] protected bool                 consumesRequirements;
    public string                                   interactionMessage {get; protected set;}
    protected PlayerInventory                       playerInventory;

    public abstract void Interact();   

    protected bool CheckRequirements()
    {
        foreach(PickableItem item in requirements)
        {
            if(!playerInventory.Has(item))
            {
                return false;
            }
        }
        return true;
    } 

    protected void ConsumeRequirements()
    {
        foreach(PickableItem item in requirements)
        {
            if(playerInventory.Has(item))
            {
                playerInventory.Remove(item);
            }
        }
    }
}