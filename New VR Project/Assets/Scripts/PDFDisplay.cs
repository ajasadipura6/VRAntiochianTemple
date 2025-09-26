using UnityEngine;
using UnityEngine.UI;

public class PDFDisplay : MonoBehaviour
{
    public GameObject pdfWindow;      // Reference to the standalone PDF window (outside of the Canvas)
    public RawImage pdfImage;         // The Raw Image to display the PDF page
    public Texture2D[] pdfPages;      // Array of converted PDF pages (as textures)
    private int currentPage = 0;

    void Start()
    {
        pdfWindow.SetActive(false);   // Initially hide the PDF window
    }

    public void ShowPDF(int pageIndex)
    {
        if (pageIndex >= 0 && pageIndex < pdfPages.Length)
        {
            pdfImage.texture = pdfPages[pageIndex]; // Display the specific PDF page
            currentPage = pageIndex;
            pdfWindow.SetActive(true);  // Show the PDF window when clicked
        }
    }

    public void ClosePDF()
    {
        pdfWindow.SetActive(false);   // Hide the PDF window when closed
    }

    public void NextPage()
    {
        if (currentPage < pdfPages.Length - 1)
        {
            currentPage++;
            pdfImage.texture = pdfPages[currentPage];
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            pdfImage.texture = pdfPages[currentPage];
        }
    }
}
