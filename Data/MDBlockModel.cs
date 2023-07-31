namespace BlazorApp.Data;

public class MDBlockModel
{
    private List<MDBlock> blocks = new List<MDBlock>();

    public MDBlockModel(IEnumerable<MDBlock>? initialBlocks = null)
    {
        if(initialBlocks != null)
        {
            blocks.AddRange(initialBlocks);
        }
    }

    private MDBlock? lastEditedBlock = null;
    public MDBlock? LastEditedBlock 
    {
        get 
        {
            return lastEditedBlock;
        }
    }

    public bool HandleBlockEdited(MDBlock editedBlock)
    {
        var rem = blocks.Count() - 1;
        lastEditedBlock = editedBlock;

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

                return true;
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

                return false;
            }
        }
        else if (rem < 0)
        {
            blocks.Add(new MDBlock(0, "# Dummy"));
            return false;
        }
        else if (rem == 0)
        {
            if(!string.IsNullOrEmpty(editedBlock.Content.Trim().Trim('\r','\n')))
            {
                blocks.Add(new MDBlock(editedBlock.Position + 1, ""));
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public List<MDBlock> GetBlocks()
    {
        return blocks;
    }

    public string GetMarkdown()
    {
        var rcontents = blocks
            .Where(b => !string.IsNullOrEmpty(b.Content.Trim('\r','\n')))
            .Select((b) => $"{b.Content}").ToList();

        return String.Join("\n", rcontents);
    }

    public void CleanAllEmptyBlocks()
    {
        blocks = blocks
            .Where((b)=>!string.IsNullOrWhiteSpace(b.Content.Trim('\r','\n')))
            .ToList();
    }

    public void SetBlocks(List<MDBlock> blocks_r)
    {
        blocks = blocks_r;
    }
}