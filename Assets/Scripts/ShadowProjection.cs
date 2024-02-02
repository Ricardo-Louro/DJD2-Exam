using UnityEngine;

public class ShadowProjection : MonoBehaviour
{
    [SerializeField] private ShadowPuzzleInputs     shadowInputHandler;
    [SerializeField] private ActivatePuzzle         activateShadowPuzzle;

    [SerializeField] private GameObject             final_letter;

    private Vector3                                 current_rotation;
    private Vector3                                 solved_rotation;

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
        if ((current_rotation.x > solved_rotation.x - 10f && current_rotation.x < solved_rotation.x + 10f) &&
            (current_rotation.y > solved_rotation.y - 10f && current_rotation.y < solved_rotation.y + 10f) &&
            (current_rotation.z > solved_rotation.z - 10f && current_rotation.z < solved_rotation.z + 10f))
        {
            activateShadowPuzzle.ConsumeRequirementsPub();
            Destroy(activateShadowPuzzle);
            final_letter.SetActive(true);
            shadowInputHandler.ExitPuzzle();
            Destroy(this);
        }
    }
}
