using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Letter : Interactive
{
    [SerializeField] private Sprite     sprite;
    private Image                       image; 
    private CameraManager               cameraManager;
    private bool                        letterToggle;

    private void Start()
    {
        interactionMessage = interactionMessages[0];
        cameraManager = GameObject.FindWithTag("MainCamera").GetComponent<CameraManager>();
        image = GameObject.Find("LettersUI").GetComponent<Image>();

        image.enabled = false;
        letterToggle = false;
    }
    private void Update()
    {
        if(cameraManager.accessibleHit.collider != gameObject.GetComponent<Collider>()
            && letterToggle)
        {
            letterToggle = false;
            image.enabled = false;
        }
    }
    public override void Interact()
    {
        if(!letterToggle)
        {
            letterToggle = true;
            image.sprite = sprite;
            image.enabled = true;
        }
        else
        {
            letterToggle = false;
            image.enabled = false;
            image.sprite = null;
        }    
    }
}
