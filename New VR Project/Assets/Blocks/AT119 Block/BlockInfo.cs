using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    public GameObject blockRecon; // Assign the block reconstruction in the Inspector
    public GameObject pdfWindow; // Assign the PDF display panel in the Inspector

    private bool isVisible = false;

    void Start()
    {
        blockRecon.SetActive(false);   // Initially hide the block reconstruction
        pdfWindow.SetActive(false);   // Initially hide the PDF window
    }

    public void TogglePDF()
    {
        isVisible = !isVisible;
        blockRecon.SetActive(isVisible);
        pdfWindow.SetActive(isVisible);
    }
}
