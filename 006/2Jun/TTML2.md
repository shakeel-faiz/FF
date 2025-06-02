## What is TTML2?

**Timed Text Markup Language 2 (TTML2)** is an XML-based language designed for the representation of timed text media, such as subtitles and captions. It [serves as a standardized format][2] for the interchange, authoring, and distribution of timed text content across various platforms and systems.

TTML2 is [intended for][3]:

* **Interchange**: Facilitating the exchange of timed text information among different authoring systems.
* **Transcoding**: Converting timed text content into various legacy distribution formats used in subtitling and captioning.
* **Distribution**: Serving as a distribution format itself, for example, by referencing TTML content from a `<track>` element in an HTML5 document or a `<text>` or `<textstream>` media element in a SMIL 3.0 document.

## System Model

TTML2 [operates within a system model][2] that includes authoring, transcoding, distribution, and presentation processes. It defines two classes of processors:

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
  * `<body>`: Contains the timed text content, referencing styles and layouts.([The Library of Congress][2], [W3C][4])

### Example:

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

## Changes from TTML1

TTML2 introduces [several enhancements][2] over TTML1, including:

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

## Reference

For an in-depth understanding and technical details, you can refer to the full TTML2 specification:

* [**W3C Recommendation (08 November 2018)**][oooooo]

---

If you have any specific questions or need further information on certain aspects of TTML2, feel free to ask!

[1]: https://www.w3.org/TR/2018/REC-ttml2-20181108/?utm_source=chatgpt.com "Timed Text Markup Language 2 (TTML2) - World Wide Web Consortium (W3C)"
[2]: https://www.loc.gov/preservation/digital/formats//fdd/fdd000588.shtml?utm_source=chatgpt.com "Timed Text Markup Language Version 2 (TTML2) - Library of Congress"
[3]: https://www.w3.org/news/2018/ttml1-3rd-ttml2-ttml-imsc1-are-w3c-recommendations/?utm_source=chatgpt.com "TTML1 3rd, TTML2, TTML-IMSC1 are W3C Recommendations"
[4]: https://www.w3.org/TR/ttml/all/?utm_source=chatgpt.com "Cover page | ttml | W3C standards and drafts | W3C"
[oooooo]: https://www.w3.org/TR/2018/REC-ttml2-20181108/](https://www.w3.org/TR/2018/REC-ttml2-20181108/
