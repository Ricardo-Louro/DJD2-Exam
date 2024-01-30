//Imports
using UnityEngine;

//Class which determines the doll's behavior to move between positions
public class Doll : MonoBehaviour
{
    //Array which determines the possible spawn points of the doll
    [SerializeField] private GameObject[]       spawnPoints;
    //The doll's collider to be used when testing to see if the player is looking at the doll or not
    new private Collider                        collider;
    //The main camera to be used when testing to see if the player is looking at the doll or not
    private Camera                              cam;
    //An index value to be used when determining the next spawn point (is the index in the array of the position in which the doll is currently at)
    private int                                 index;
    //An index value to be used when determining the next spawn point (is the index in the array of the position in which the doll will teleport to)
    private int                                 new_index;
    //A flag to see if the doll has been looked at or not 
    private bool                                lookedAt;
    //An array of planes to test if the doll is within the camera's area or not
    private Plane[]                             planes;

    //Start runs on the first frame in which this script is active
    private void Start()
    {
        //Set the index as 0
        index = 0;
        //Store a reference to the main camera
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        //Store a reference to the doll's collider
        collider = gameObject.GetComponent<Collider>();
    }

    //Update runs every frame after the first frame in which this script is active
    private void Update()
    {
        //Calculate and store the planes of the camera
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        //If the doll is within the camera area...
        if(GeometryUtility.TestPlanesAABB(planes, collider.bounds))
        {
            //Set the lookAt flag as true
            lookedAt = true;
        }
        //If the doll is outside the camera area...
        else
        {
            //If the lookedAt flag is true...
            if(lookedAt)
            {
                //Move the doll to another position
                Disappear();
            }
        }
    }

    //This method moves the doll to another position
    private void Disappear()
    {
        //While the new index is equal to the current index...
        while(new_index == index)
        {
            //Determine a new index randomly between the value of 0 and the amount of spawn points
            new_index = Random.Range(0, spawnPoints.Length);
            
            //PS: While this theoretically can go on for long enough to be noticeable or even indefinitely, the odds are so low that I've decided to ignore it
        }
        
        //Set the index to have the value of the new index
        index = new_index;
        //Set the spawn to be the spawn in the desired index of the array
        GameObject spawn = spawnPoints[index];
        //Set the doll's position to be that of the desired spawn point
        gameObject.transform.position = spawn.transform.position;
        //Set the doll's rotation to be that of the desired spawn point
        gameObject.transform.rotation = spawn.transform.rotation;

        //Set the lookedAt flag as false
        lookedAt = false;
    }
}