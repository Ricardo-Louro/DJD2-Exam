using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickableItem : Interactive
{
    [SerializeField] new public string name;
    [SerializeField] public Sprite UI_image;

    private void Start()
    {
        interactionMessage = interactionMessages[0];
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    public override void Interact()
    {
        playerInventory.Add(this);
        Destroy(gameObject);
    }
}
