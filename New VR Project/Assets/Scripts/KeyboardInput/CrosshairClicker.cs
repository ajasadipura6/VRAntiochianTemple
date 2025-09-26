using UnityEngine;
using UnityEngine.UI;

public class CrosshairClicker : MonoBehaviour
{
    public Image crosshairImage; // Assign your Crosshair UI Image
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.green;
    public float raycastRange = 100f;

    void Update()
    {
        // Raycast from the camera's position forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastRange))
        {
            BlockInfo block = hit.collider.GetComponent<BlockInfo>();
            BlockInfoRecon blockRecon = hit.collider.GetComponent<BlockInfoRecon>();

            if (block)
            {
                crosshairImage.color = hoverColor;

                if (Input.GetMouseButtonDown(0)) // Left-click to toggle
                {
                    block.TogglePDF();
                }
            }
            else if (blockRecon)
            {
                crosshairImage.color = hoverColor;

                if (Input.GetMouseButtonDown(0)) // Left-click to toggle
                {
                    blockRecon.TogglePDF();
                }
            }
            else
            {
                crosshairImage.color = defaultColor;
            }
        }
        else
        {
            crosshairImage.color = defaultColor;
        }
    }
}
