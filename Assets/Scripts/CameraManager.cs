using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float      cameraHeight;
    [SerializeField] private float      interactionRange = 3;

    private RaycastHit                   hit;
    public RaycastHit                   accessibleHit{get; private set;}

    private Transform                   playerTransform;
    private Camera                      cam;

    private float                       rotationX;
    private float                       rotationY;

    private TextMeshProUGUI             tmp;

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();

        GameObject player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        tmp = GameObject.Find("InteractionMessage").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {   
        UpdateRotation();
        UpdatePosition();
        Raycast();
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0);
    }

    private void UpdatePosition()
    {
        Vector3 playerPos = playerTransform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y + 0.5f, playerPos.z);
    }

    private void Raycast()
    {
        Vector3 middleScreen = cam.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, cam.nearClipPlane));

        if(Physics.Raycast(middleScreen, transform.forward, out hit))
        {
            accessibleHit = hit;
            Interactive interactive;
            if(CheckInteractive(out interactive))
                tmp.SetText(interactive.interactionMessage);
            else
                tmp.SetText("");
        }
    }

    private bool CheckInteractive(out Interactive interactiveComponent)
    {
        interactiveComponent = null;
        try
        {
            interactiveComponent = hit.collider.GetComponent<Interactive>();

            if(hit.distance > interactionRange)
                return false;
        }
        catch
        {}
        
        return interactiveComponent != null;
    }

    public void TryInteract()
    {
        Interactive interactive;
        if(CheckInteractive(out interactive))
            interactive.Interact();
    }

    public void ReceiveValues(float rotationX, float rotationY)
    {
        this.rotationX = rotationX;
        this.rotationY = rotationY;
    }
}