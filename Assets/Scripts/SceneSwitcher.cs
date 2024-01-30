//Imports
using UnityEngine;
using UnityEngine.SceneManagement;

//Class which handles switching the current scene
public class SceneSwitcher : MonoBehaviour
{
    //The desired scene's name
    [SerializeField] private string sceneName;
    
    //Switches the scenes to the desired one
    public void SwitchScene()
    {
        //Loads the scene which has the selected scene name
        SceneManager.LoadScene(sceneName);
    }
}
