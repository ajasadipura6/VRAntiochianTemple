using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance { get; private set; }

    private BlockInfo activeBlock;
    private BlockInfoRecon activeBlockRecon;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Called when a normal BlockInfo (no PDF) is clicked
    public void SetActiveBlock(BlockInfo newBlock)
    {
        // Hide any currently active recon block (if one is open)
        if (activeBlockRecon != null)
        {
            activeBlockRecon.HidePDF();
            activeBlockRecon = null;
        }

        // If clicking the same block again → hide it
        if (activeBlock == newBlock)
        {
            activeBlock.HideBlock();
            activeBlock = null;
            return;
        }

        // Hide the previous block
        if (activeBlock != null)
            activeBlock.HideBlock();

        // Show the new block
        activeBlock = newBlock;
        activeBlock.ShowBlock();
    }

    // Called when a BlockInfoRecon (with PDF) is clicked
    public void SetActiveBlock(BlockInfoRecon newBlockRecon)
    {
        // Hide any normal block
        if (activeBlock != null)
        {
            activeBlock.HideBlock();
            activeBlock = null;
        }

        // If clicking the same recon block again → hide it
        if (activeBlockRecon == newBlockRecon)
        {
            activeBlockRecon.HidePDF();
            activeBlockRecon = null;
            return;
        }

        // Hide any previous recon block
        if (activeBlockRecon != null)
            activeBlockRecon.HidePDF();

        // Show the new one
        activeBlockRecon = newBlockRecon;
        activeBlockRecon.ShowPDF();
    }

    public void ClearAll()
    {
        if (activeBlock != null)
        {
            activeBlock.HideBlock();
            activeBlock = null;
        }

        if (activeBlockRecon != null)
        {
            activeBlockRecon.HidePDF();
            activeBlockRecon = null;
        }
    }
}
