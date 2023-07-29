# MarkDown Blazor Editor Example

## Motivation
After being watching some **#viciostv** was curious about **Markdig** and also about **Blazor**.
I drafted this simple sample for it.

## How to test it

```
git clone https://github.com/arale61/MarkDownBlazorEditorExample.git
cd MarkDownBlazorEditorExample
dotnet watch
```

After launching the application, go to **/mdcontainer**.

![Sample Markdown editor](/images/mdeditor.png)

Demo:

![Demo](/images/demo.gif)


## Markdown cheat sheet

Use the following Cheatsheet for your tests:

[Markdown Guide](https://www.markdownguide.org/basic-syntax)

## Known Bugs

- The usage of **tab** fails when in editor mode.
- The auto-focus for editor component not working.
- When copy paste a list and try to put new **tab** on some item fails.
- Some other minor issues.