//Imports
using System.Collections;
using UnityEngine;
using Plane = UnityEngine.Plane;
using Vector3 = UnityEngine.Vector3;

//This class will teleport the player between Phase 1 and Phase 2 of the game
public class Teleporter : MonoBehaviour
{
    //The game object which determines the zone the player cannot be looking at to trigger the effect
    [SerializeField] private GameObject     noLookZone;
    //Reference to the player so I can more easily access its relevant components
    private GameObject                      player;
    //The player's collider to determine whether the player is in the desired zone to trigger the effect or not
    private Collider                        playerCollider;
    //The player controller to be disabled while the player is being teleported so as to not have the position value overwritten in the middle of it
    private CharacterController             playerController;
    //The collider to see if the its bounds are inside the no look area or not
    private Collider                        noLookCollider;
    //The main camera utilized in the function to determine what is in the player's camera area or not
    private Camera                          cam;
    //The camera's planes utilized in the function to determine what is in the player's camera area or not
    private Plane[]                         planes;
    //Flag utilized to move the player in the update frame so the visual side of the effect syncs properly 
    private bool                            move;
    //Bool utilized as a flag to start the Destruction coroutine only once
    private bool                            destroy;
    //Object which contains all the elements relevant to Phase1 as children
    private GameObject                      phase1;
    

    // Start is called before the first frame update
    private void Start()
    {
        //Stores the look area's collider
        noLookCollider = noLookZone.GetComponent<Collider>();
        //Stores the reference to the player
        player = GameObject.FindWithTag("Player");
        //Store the reference to the player's collider
        playerCollider = player.GetComponent<CapsuleCollider>();
        //Stores the reference to the player's Character Controller
        playerController = player.GetComponent<CharacterController>();
        //Stores a reference to the main camera
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        //Stores a reference to the object which contains all the elements relevant to Phase1 as children
        phase1 = GameObject.Find("Phase1");

        //Sets the move flag to false
        move = false;
        //Sets the destroy flag to true
        destroy = false;
    }

    //Update is called every frame after the first one
    private void Update()
    {
        //If the move flag is true...
        if(move)
        {
            //Move the player to the desired location (in this case, the Phase2 area)
            MovePlayer();
            //Set the move flag to false so that this only happens once.
            move = false;
            //Set the destroy flag to true
            destroy = true;
        }
        //If the destroy flag is true... 
        if(destroy)
        {
            //Start the coroutine which destroys all of the phase 1 objects
            StartCoroutine(DestroyPhase());
            //Set the destroy flag to false so that this only happens once
            destroy = false;
        }
    }
    
    //While something is colliding with the trigger
    private void OnTriggerStay(Collider other)
    {
        //If the colliding object is the player...
        if(other == playerCollider)
        {
           //Calculate the planes of the player's camera area 
            planes = GeometryUtility.CalculateFrustumPlanes(cam);
        
            //If the target object's collider's bounds are NOT within the plane...
            if(!GeometryUtility.TestPlanesAABB(planes, noLookCollider.bounds))
            {
                //Set the move flag to true
                move = true;
            }
        }
    }

    //This method teleports the player to the desired area
    private void MovePlayer()
    {
        //Disable the playerController so as to not have it overwrite the player's position
        playerController.enabled = false;
        //Update the player's position to the desired one (in this case, an addition 20 units on the z axis)
        player.transform.position = new Vector3(player.transform.position.x,
                                                player.transform.position.y,
                                                player.transform.position.z + 20);
        //Re-enable the playerController as the position has already been set
        playerController.enabled = true;
    }

    //Co-routine which handles the destruction of all Phase 1 objects
    private IEnumerator DestroyPhase()
    {
        //Wait for 0.2 seconds before carrying out the next instruction
        yield return new WaitForSeconds(0.2f);
        //Destroy the phase1 object, destroying all its children (all relevant Phase 1 objects)
        Destroy(phase1);
    }
}