using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] private Collider           trigger;
    [SerializeField] private Collider           target;
    [SerializeField] new private Animation      animation;
    private CameraManager                       cameraManager;

    private void Start()
    {
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == cameraManager.gameObject)
        {
            if(cameraManager.accessibleHit.collider == target)
            {
                animation.Play();
                
                //Make sure to disable the colliders in the animation clip 

                Destroy(this);
            }
        }
    }
}
