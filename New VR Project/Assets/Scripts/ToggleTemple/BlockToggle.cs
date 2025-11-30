using UnityEngine;

public class BlockToggle : MonoBehaviour
{

    public GameObject reconstructedBlocks;
    private bool showingBlocks = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            showingBlocks = !showingBlocks;
            ToggleAllBlocks(showingBlocks);
        }
    }

    void ToggleAllBlocks(bool state)
    {
        foreach (Transform child in reconstructedBlocks.transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}
