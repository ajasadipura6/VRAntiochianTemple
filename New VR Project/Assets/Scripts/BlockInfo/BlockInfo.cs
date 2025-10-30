using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    public GameObject blockRecon; // Assign the block reconstruction in the Inspector

    private bool isVisible = false;

    void Start()
    {
        blockRecon.SetActive(false);   // Initially hide the block reconstruction
    }

    public void ShowBlock()
    {
        isVisible = true;
        blockRecon.SetActive(true);
    }

    public void HideBlock()
    {
        isVisible = false;
        blockRecon.SetActive(false);
    }

    public void TogglePDF()
    {
        BlockManager.Instance.SetActiveBlock(this);
    }
}
