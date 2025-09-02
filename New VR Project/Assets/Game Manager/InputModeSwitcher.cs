using UnityEngine;

public class InputModeSwitcher : MonoBehaviour
{
    public GameObject playerController;   // Drag in your player (like your First Person Controller)
    public GameObject droneCamera;        // Drag in the DroneCamera GameObject

    private bool usingDrone = false;

    void Start()
    {
        // Make sure we start in player mode (or whichever makes sense for your app)
        SwitchToPlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))  // Change 'C' to whatever key you want
        {
            if (usingDrone)
                SwitchToPlayer();
            else
                SwitchToDrone();
        }
    }

    void SwitchToDrone()
    {
        usingDrone = true;
        droneCamera.SetActive(true);
        playerController.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void SwitchToPlayer()
    {
        usingDrone = false;
        droneCamera.SetActive(false);
        playerController.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;  // Or None if you want a visible cursor in player mode
        Cursor.visible = false;                     // Adjust this depending on your player setup
    }
}
