using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] private SceneSwitcher _sceneSwitcher;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _sceneSwitcher.SwitchScene();
        }
    }
}
