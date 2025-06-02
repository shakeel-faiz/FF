## What is TTML2?

**Timed Text Markup Language 2 (TTML2)** is an XML-based language designed for the representation of timed text media, such as subtitles and captions. It [serves as a standardized format][1] for the interchange, authoring, and distribution of timed text content across various platforms and systems.

TTML2 is [intended for][2]:

* **Interchange**: Facilitating the exchange of timed text information among different authoring systems.
* **Transcoding**: Converting timed text content into various legacy distribution formats used in subtitling and captioning.
* **Distribution**: Serving as a distribution format itself, for example, by referencing TTML content from a `<track>` element in an HTML5 document or a `<text>` or `<textstream>` media element in a SMIL 3.0 document.

## System Model

TTML2 [operates within a system model][1] that includes authoring, transcoding, distribution, and presentation processes. It defines two classes of processors:

1. **Transformation Processors**: Used in authoring systems and validation processors.
2. **Presentation Processors**: Used in transcoding systems and rendering processors.

These processors can implement mappings to TTML Intermediate Documents, enabling integration with various media formats and technologies .

## Document Structure

A typical TTML2 document consists of:

* `<tt>`: The root element.

  * `<head>`: Contains metadata, styling, and layout information.

    * `<metadata>`: Includes document-level metadata such as title and copyright.
    * `<styling>`: Defines style specifications.
    * `<layout>`: Specifies layout regions.
  * `<body>`: Contains the timed text content, referencing styles and layouts.

e.g.

```xml
<tt xml:lang="" xmlns="http://www.w3.org/ns/ttml">
  <head>
    <metadata/>
    <styling/>
    <layout/>
  </head>
  <body/>
</tt>
```

### Example:

Here's a simple example of a **TTML2** file:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<tt xmlns="http://www.w3.org/ns/ttml"
    xmlns:tts="http://www.w3.org/ns/ttml#styling"
    xml:lang="en">
  <head>
    <styling>
      <style xml:id="s1" tts:fontSize="16px" tts:color="white" tts:backgroundColor="black"/>
    </styling>
    <layout>
      <region xml:id="bottom" tts:origin="10% 80%" tts:extent="80% 10%"/>
    </layout>
  </head>
  <body region="bottom">
    <div>
      <p begin="00:00:01.000" end="00:00:04.000" style="s1">
        Hello, this is an example of TTML2 subtitles.
      </p>
      <p begin="00:00:05.000" end="00:00:08.000" style="s1">
        These captions are timed and styled.
      </p>
    </div>
  </body>
</tt>
```

* `<p begin="..." end="...">`: Shows the subtitle text with timing.
* `<style>` and `<region>`: Define how and where the text appears.
* `<tt>`: Root element of the TTML2 document.

## Changes from TTML1

TTML2 introduces [several enhancements][1] over TTML1, including:

* **Extended Features**: Support for East Asian languages, stereoscopic 3D, and detailed mapping to HTML and CSS.
* **Improved Modularity**: Better organization and separation of concerns within the specification.
* **Updated Syntax**: Refinements to the language syntax for clarity and consistency.

A detailed summary of changes from TTML1 to TTML2 is available in the TTML2 Change Summary .

## Adoption and Industry Support

TTML2 has been adopted and supported by various organizations and standards bodies, including:

* **Netflix**
* **Microsoft**
* **BBC**
* **Apple**
* **MovieLabs**
* **European Broadcasting Union (EBU)**

These contributors have played significant roles in the development and implementation of TTML2 .

## How to open TTML2 file?

You can open and view a TTML2 file using different tools, depending on whether you want to read the text, edit the content, or display it as subtitles. TTML2 files are **XML-based**, so they can be opened in any text or XML editor, but to **play or test** them as subtitles, you need compatible tools.

### To View or Edit

Use any **text editor**:

* **Windows**: Notepad or Notepad++
* **Mac/Linux**: TextEdit or VS Code

Just **right-click the file** → **Open with** → choose your editor.

### To Play as Subtitles (with video)

TTML2 is not supported by most media players directly.
You need to **convert it to [SRT][4]** or **WebVTT** using tools like:

* **Subtitle Edit** (free app for Windows)

### To Use on a Website

Use it in a `<video>` tag like this:

```html
<track src="captions.ttml" kind="subtitles" label="English" srclang="en">
```

> Note: Most browsers don’t support TTML directly. Convert to **WebVTT** for better compatibility.

## Reference

For an in-depth understanding and technical details, you can refer to the full TTML2 specification:

* [W3C Recommendation (08 November 2018)][3]

[1]: https://www.loc.gov/preservation/digital/formats/fdd/fdd000588.shtml
[2]: https://www.w3.org/news/2018/ttml1-3rd-ttml2-ttml-imsc1-are-w3c-recommendations/
[3]: https://www.w3.org/TR/2018/REC-ttml2-20181108/
[4]: https://docs.fileformat.com/video/srt/
