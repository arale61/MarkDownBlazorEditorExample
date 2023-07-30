namespace BlazorApp.Data;

public class MDBlockModel
{
    private List<MDBlock> blocks = new List<MDBlock>();

    public MDBlockModel(IEnumerable<MDBlock>? initialBlocks)
    {
        if(initialBlocks != null)
        {
            blocks.AddRange(initialBlocks);
        }
    }

    public void HandleBlockEdited(MDBlock editedBlock)
    {
        var rem = blocks.Count() - 1 - editedBlock.Position;

        if (rem > 0)
        {
            if(!string.IsNullOrEmpty(editedBlock.Content.Trim().Trim('\r','\n')))
            {
                var firstPart = blocks
                    .Where(b => b.Position <= editedBlock.Position)
                    .ToList();

                firstPart.Add(new MDBlock(editedBlock.Position+1, ""));

                var secondPart = blocks
                    .Where(b => b.Position > editedBlock.Position)
                    .Select(b => new MDBlock(b.Position + 1, b.Content))
                    .ToList();
                
                firstPart.AddRange(secondPart);
                
                blocks = firstPart;
            }
            else
            {
                var firstPart = blocks
                    .Where(b => b.Position < editedBlock.Position)
                    .ToList();

                var secondPart = blocks
                    .Where(b => b.Position > editedBlock.Position)
                    .Select(b => new MDBlock(b.Position -1, b.Content))
                    .ToList();
                
                firstPart.AddRange(secondPart);
                
                blocks = firstPart;
            }
        }
        else if (rem == 0)
        {
            if(!string.IsNullOrEmpty(editedBlock.Content.Trim().Trim('\r','\n')))
            {
                blocks.Add(new MDBlock(editedBlock.Position + 1, ""));
            }
        }
    }

    public List<MDBlock> GetBlocks()
    {
        return blocks;
    }
}