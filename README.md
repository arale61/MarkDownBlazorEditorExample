# MarkDown Blazor Editor Example

## This is just an example
This example uses [**Markdig**](https://github.com/xoofx/markdig) as the **Markdown parser**.

Based on **Blazor Server** template, and **composed by**:
- **Pages/MDEditor.razor**: Main component. Presents rendered blocks using the MDViewer.razor component. And Presents the MDEditor for the selected block.
- **Pages/MDViewer.razor**: Child component for the MDEditor. Used to display HTML projection for Markdown.
- **Pages/MDEdit.razor**: Child component for MDEditor. Used to edit the current block, renders Markdown text.
- **Pages/MDFullViewer**: Example Component for displaying the full text Mardown.
- **Pages/MDContainer**: Example of a **Page** that uses the **MDEditor** and **MDFullViewer** to edit and store Markdown.
- **Data/MDBlock**: Simple object for holding block content and position.
- **Data/MDBlockModel**: Data Model for holding MDBlock logic. Used by the MDEditor component.


[**Markdig**](https://github.com/xoofx/markdig) is licensed with [BSD-Clause 2 license](https://github.com/xoofx/markdig/blob/master/license.txt).

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

## Tested and developed with

```
dotnet --version    # 6.0.412

Debian trixie       # https://www.debian.org/releases/testing/

vs Codium           # version: 1.77.3, release: 23102

```

## Known Bugs

- The usage of **tab** and cursor update.