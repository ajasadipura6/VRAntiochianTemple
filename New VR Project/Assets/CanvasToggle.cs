using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasToggle : MonoBehaviour
{
    public GameObject menuCanvas;
    public InputActionReference toggleAction;

    private void OnEnable()
    {
        toggleAction.action.performed += OnToggle;
        toggleAction.action.Enable();
    }

    private void OnDisable()
    {
        toggleAction.action.performed -= OnToggle;
        toggleAction.action.Disable();
    }

    private void OnToggle(InputAction.CallbackContext ctx)
    {
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }
}

