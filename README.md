# Button with Font Icon in WinForms application
This repository contains a sample project to demonstrate using an icon font to render icons over a button control in a WinForms (Windows Forms) desktop application.

## How to run the project
- Checkout this project to a location on your disk.
- Open the solution file using Visual Studio.
- Build and Run the project.

## How to add and draw icon fonts
1) Add WF Fabric.ttf to the project → Build Action: Embedded Resource.  
2) Read the font stream via GetManifestResourceStream (correct resource name).  
3) Load with PrivateFontCollection.AddMemoryFont.  
4) Create Font from pfc.Families[0].  
5) Convert code point using ConvertFromUtf32 → DrawString with a SolidBrush.

---

Icon fonts contain symbols instead of numbers and letters. Because they are vector graphics, they scale up and down without losing quality and are small and easy to load. A single icon draws in one color, which is typically sufficient for UI symbols.

In WinForms, icon fonts work well for DPI scaling—simply adjust the font size instead of maintaining multiple bitmap assets. To use them, embed a TTF (here, “WF Fabric”) and register it at runtime. The PrivateFontCollection stores the font in memory, making the family available like any system font. Map friendly names to Unicode values (e.g., 0xe700) and convert them to strings for rendering.

A simple demo draws navigation icons (first, last, previous, next) on a custom button control. Icons and text can be combined, aligned, and recolored via brushes. Since glyphs are text, layout is straightforward with MeasureString/DrawString.

## Key functions
- Assembly.GetManifestResourceStream: Read embedded WF Fabric.ttf.
- PrivateFontCollection.AddMemoryFont: Load font into process memory.
- char.ConvertFromUtf32: Convert code point (e.g., 0xe700) to string.
- Graphics.DrawString: Render the icon glyph with color and size.

## Advantages of using icon fonts
- Improved rendering quality in all font sizes.
- Reuse a single icon font for different themes by changing color.
- Reduced application size without maintaining multiple DPI-specific images.
- Combine icon fonts with letters, numbers, and symbols as needed.

## Troubleshooting
- Null stream: check resource name and Build Action (Embedded Resource).
- Wrong glyph: verify code point matches your font’s mapping.
- Jagged edges: use ClearType/AntiAlias and enable double buffering.
- Resource name hint: inspect Assembly.GetManifestResourceNames().

Note: Only include and redistribute fonts you have rights to use. Review the license for WF Fabric.ttf (or your custom font) before distribution.