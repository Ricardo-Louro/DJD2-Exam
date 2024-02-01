using UnityEngine;


[RequireComponent(typeof(Animator))]
public class SettingsMenu : MonoBehaviour
{

    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.Play("Settings Menu Appearing");
    }
    
    // Called by the back button.
    public void Close()
    {
        animator.Play("Settings Menu Disappearing");
    }

    // Called by Settings Menu Disappearing on an event.
    public void DisableSettingsMenu()
    {
        gameObject.SetActive(false);
    }
    
}
