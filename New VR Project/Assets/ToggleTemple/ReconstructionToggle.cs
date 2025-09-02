using UnityEngine;
using TMPro;  // If you're using TextMeshPro

public class ReconstructionToggle : MonoBehaviour
{
    public GameObject reconstructedVersion;  // The reconstructed version (starts off)
    private bool showingReconstruction = false;

    // UI Text element to show the current mode (use TextMeshPro or Unity Text)
    public TextMeshProUGUI modeText;  // TextMeshPro Text component
    // public UnityEngine.UI.Text modeText;  // If you are using Unity's default Text (uncomment this line instead)

    void Start()
    {
        // Ensure the reconstructed version starts hidden
        reconstructedVersion.SetActive(false);

        // Set initial UI text (Ruins Mode at start)
        UpdateUI(false);
    }

    void Update()
    {
        // Toggle on "T" key press (or use a VR controller input here)
        if (Input.GetKeyDown(KeyCode.T))  
        {
            showingReconstruction = !showingReconstruction;
            if (showingReconstruction)
            {
                ShowReconstruction();
            }
            else
            {
                HideReconstruction();
            }
        }
    }

    // Shows the reconstructed version on top of the ruins
    void ShowReconstruction()
    {
        reconstructedVersion.SetActive(true);
        UpdateUI(true);  // Set text to "Reconstructed Mode"
    }

    // Hides the reconstructed version, leaving only the ruins
    void HideReconstruction()
    {
        reconstructedVersion.SetActive(false);
        UpdateUI(false);  // Set text to "Ruins Mode"
    }

    // Update the UI Text based on the mode (true = reconstructed, false = ruins)
    void UpdateUI(bool isReconstructed)
    {
        if (isReconstructed)
        {
            modeText.text = "Reconstructed Mode";  // Display this when the reconstructed version is active
        }
        else
        {
            modeText.text = "Ruins Mode";  // Display this when showing only the ruins
        }
    }
}
