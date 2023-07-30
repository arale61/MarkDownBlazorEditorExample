using Markdig;

namespace BlazorApp.Data;

public class MDBlock
{
    public MDBlock(int position, string content)
    {
        this.Position = position;
        this.Content = content;
    }

    public int Position {get;set;} = 0;
    public string Content {get;set;} = string.Empty;
}
