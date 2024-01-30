//Imports
using UnityEngine;
using UnityEngine.SceneManagement;

//Class which handles switching the current scene immediately for use in Timelines
public class SceneSwitcherTL : MonoBehaviour
{
    //The desired scene's name
    [SerializeField] private string     sceneName;

    //Start runs on the first frame where this script is active
    private void Start()
    {
        //Switch scenes with the desired one
        SceneManager.LoadScene(sceneName);
    }
}
