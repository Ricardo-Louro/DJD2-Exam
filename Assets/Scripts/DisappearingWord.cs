using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisappearingWord : MonoBehaviour
{
    [SerializeField] private GameObject[]       spawnPoints;
    [SerializeField] private Collider           disappearCollider;
    [SerializeField] private Collider           lookCollider;

    [SerializeField] private Interactive        clockInteractive;

    new private Camera                          camera;
    private CameraManager                       cameraManager;
    private int                                 index;
    private bool                                active;
    private bool                                lookedAt;
    private Plane[]                             planes;

    private void Start()
    {
        active = true;
        index = 0;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cameraManager = camera.GetComponent<CameraManager>();
    }
    private void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(camera);

        if(active)
        {
            Debug.Log("active");
            if(cameraManager.accessibleHit.collider == lookCollider)
            {
                Debug.Log("collider got hit");
                lookedAt = true;
            }

            if(lookedAt)
            {
                if (!GeometryUtility.TestPlanesAABB(planes, disappearCollider.bounds))
                {
                    Disappear();
                }
            }
        }
    }

    private void Disappear()
    {
        GameObject spawn = spawnPoints[index];
        gameObject.transform.position = spawn.transform.position;
        gameObject.transform.rotation = spawn.transform.rotation;

        lookedAt = false;

        if(index != spawnPoints.Length -1)
        {
            index++;
        }
        else
        {
            foreach(Collider col in gameObject.GetComponents<Collider>())
            {
                Destroy(col);
            }

            active = false;
            clockInteractive.enabled = true;

            Destroy(this);
        }
    }
}