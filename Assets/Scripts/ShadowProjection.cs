using UnityEngine;

public class ShadowProjection : MonoBehaviour
{
    [SerializeField] private ShadowPuzzleInputs shadowInputHandler;
    [SerializeField] private ActivatePuzzle activateShadowPuzzle;
    private Vector3 current_rotation;
    private Vector3 solved_rotation;

    // Start is called before the first frame update
    void Start()
    {
        solved_rotation = new Vector3(18f, 339f, 0f);    
    }

    // Update is called once per frame
    void Update()
    {
        current_rotation = gameObject.transform.eulerAngles;
        CheckSolution();
    }

    private void CheckSolution()
    {
        Debug.Log(current_rotation);
        if ((current_rotation.x > solved_rotation.x - 10f && current_rotation.x < solved_rotation.x + 10f) &&
            (current_rotation.y > solved_rotation.y - 10f && current_rotation.y < solved_rotation.y + 10f) &&
            (current_rotation.z > solved_rotation.z - 10f && current_rotation.z < solved_rotation.z + 10f))
        {
            Debug.Log("SOLVED!");
            activateShadowPuzzle.ConsumeRequirementsPub();
            Destroy(activateShadowPuzzle);
            shadowInputHandler.ExitPuzzle();
        }
    }
}
