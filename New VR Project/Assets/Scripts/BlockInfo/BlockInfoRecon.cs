using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BlockInfoRecon : MonoBehaviour
{
    public GameObject blockRecon; // Assign the block reconstruction in the Inspector
    public GameObject pdfWindow; // Assign the PDF display panel in the Inspector

    private bool isVisible = false;

    void Start()
    {
        blockRecon.SetActive(false);   // Initially hide the block reconstruction
        pdfWindow.SetActive(false);   // Initially hide the PDF window
    }

    public void ShowPDF()
    {
        isVisible = true;
        blockRecon.SetActive(true);
        pdfWindow.SetActive(true);
    }

    public void HidePDF()
    {
        isVisible = false;
        blockRecon.SetActive(false);
        pdfWindow.SetActive(false);
    }

    public void TogglePDF()
    {
        BlockManager.Instance.SetActiveBlock(this);
    }
    // XRSimpleInteractable
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        TogglePDF();  
    }
}


// public class BlockInfoRecon : MonoBehaviour
// {
//     [Header("UI Elements")]
//     public GameObject blockRecon; // Assign the block reconstruction in the Inspector
//     public GameObject pdfWindow; // Assign the PDF display panel in the Inspector

//     [Header("Input")]
//     public InputActionReference triggerButton; // Assign the trigger button action in the Inspector
    
//     private bool isVisible = false;

//     void Start()
//     {
//         blockRecon.SetActive(false);   // Initially hide the block reconstruction
//         pdfWindow.SetActive(false);   // Initially hide the PDF window
//     }
//     void Update()
//     {
//         // Detect if trigger was pressed THIS frame
//         if (triggerButton.action.WasPressedThisFrame())
//         {
//             TogglePDF();
//         }
//     }
//     public void ShowPDF()
//     {
//         isVisible = true;
//         blockRecon.SetActive(true);
//         pdfWindow.SetActive(true);
//     }

//     public void HidePDF()
//     {
//         isVisible = false;
//         blockRecon.SetActive(false);
//         pdfWindow.SetActive(false);
//     }

//     public void TogglePDF()
//     {
//         BlockManager.Instance.SetActiveBlock(this);
//     }
// }
