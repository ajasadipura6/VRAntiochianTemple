using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    public GameObject pdfWindow; // Assign the PDF display panel in the Inspector

    private bool isVisible = false;

    void Start()
    {
        pdfWindow.SetActive(false);   // Initially hide the PDF window
    }

    public void TogglePDF()
    {
        isVisible = !isVisible;
        pdfWindow.SetActive(isVisible);
    }
}
