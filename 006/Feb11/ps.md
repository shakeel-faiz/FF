## What is PostScript?

**PostScript (PS)** is a **page description language (PDL)** developed by **Adobe Systems** in 1982. It is primarily used in **desktop publishing, printing, and graphic design** to describe how text and images should be rendered on a page.

## Explanation of PostScript (PS)

PostScript (PS) is both a **page description language (PDL)** and a **programming language** that is **dynamically typed** and **stack-based**. Here’s what that means:

### **1. What is a Page Description Language (PDL)?**
A page description language defines how graphics and text appear on a printed page or screen. PostScript is used in **printers, publishing software, and digital typesetting** to accurately render fonts, images, and layouts.

### **2. What is a Stack-Based Programming Language?**
PostScript uses a **stack** to process commands, meaning it follows a **Last-In, First-Out (LIFO)** approach. For example, to add two numbers in PostScript, you push them onto the stack and then call an operator to process them:

```
10 20 add
```
This pushes `10` and `20` onto the stack, then the `add` command pops them off and pushes the result (`30`) back onto the stack.

### **3. Dynamically Typed**
PostScript does not require explicit type definitions. Variables can hold different types (numbers, strings, arrays, etc.) without predefined types.

### **4. Uses of PostScript**
PostScript is mainly used for **desktop publishing and electronic publishing**, meaning it helps create and print high-quality documents with precise control over fonts, layout, and graphics.

### **5. Turing Complete Language**
Being **Turing complete** means PostScript can, in theory, perform any computation given enough memory and time. This means it can be used for general programming tasks, not just printing.

### **6. History and Development**
- Developed by **Adobe Systems** between **1982 and 1984**.
- Created by **John Warnock, Charles Geschke, Doug Brotz, Ed Taft, and Bill Paxton**.
- The latest version, **PostScript 3**, was released in **1997** and added better performance, color management, and image compression.

## PostScript History  

PostScript's origins trace back to **1976**, when **John Gaffney** at **Evans & Sutherland** developed concepts for a page description language while working on a graphics database. Around the same time, **Xerox PARC** was developing **laser printers** and needed a standard for defining page images. They first created the **Press format**, later evolving into **Interpress** in 1978, developed by **John Gaffney and Martin Newell**.  

In **1982**, **John Warnock and Chuck Geschke** left Xerox PARC and co-founded **Adobe Systems**, where they, along with **Doug Brotz, Ed Taft, and Bill Paxton**, developed **PostScript** as a simpler alternative to Interpress. It was released commercially in **1984**.  

### **Apple’s Role in PostScript's Success**  
In **1983**, **Steve Jobs** saw PostScript’s potential for the **Macintosh** and licensed it from Adobe for **$1.5 million**, plus **$2.5 million for 20% of Adobe’s shares**. He also attempted, unsuccessfully, to buy Adobe. Apple and Adobe then worked together to optimize PostScript for **Apple's LaserWriter printer**—launched in **1985**—which played a crucial role in the **desktop publishing revolution**.  

Adobe’s breakthrough in **font rendering and hinting** made PostScript viable even on lower-resolution **300-dpi Canon laser printers**. Adobe did not patent this technology to keep it a trade secret.  

### **PostScript’s Decline and Legacy**  
During the **1980s and 1990s**, PostScript was widely used in **laser printers**, but its **high processing power and memory requirements** made it expensive. As **printers became cheaper** and **computers more powerful**, software-based solutions replaced hardware PostScript processing. By **2001**, most low-end printers dropped PostScript support in favor of **inkjet technology** and **software rendering**.  

However, PostScript remains dominant in **high-end professional printers**, where it **offloads rendering from the computer to the printer**, improving performance. Additionally, **PDF (Portable Document Format)**—a direct descendant of PostScript—has become the **standard for electronic document distribution**.  

## PostScript Levels 

PostScript has evolved through different levels, each improving functionality, performance, and efficiency. There are **three major levels**:  

### **1. PostScript Level 1 (1984)**

The original PostScript (Level 1, released in 1984) let users precisely control page layout with text, graphics, and images, and was used in early laser printers. However, it was limited to grayscale, processed complex graphics slowly, and produced large files due to a lack of image compression.

- The original version, released by **Adobe** in **1984**.  
- Provided **device-independent** page descriptions for text, graphics, and images.  
- Allowed precise control over typography and layout.  
- Used in the **first PostScript printers**, including the **Apple LaserWriter**.  
- **Limitations:**  
  - Lacked **color support** (only grayscale).  
  - **Slow processing** on complex graphics.  
  - **No built-in image compression**, leading to large file sizes.  

### **2. PostScript Level 2 (1991)**

PostScript Level 2 (1991) boosted performance, added color printing, compressed files, improved fonts, and sped up complex graphics processing.

- Improved **performance** and **memory efficiency**.  
- Added support for **color printing** (CMYK and spot colors).  
- Introduced **data compression** to reduce file sizes.  
- Enabled **improved font handling** (Type 1 and Type 3 fonts).  
- Introduced **Pattern, Forms, and Composite Fonts** for better text rendering.  
- **Faster processing** of complex graphics compared to Level 1.  

### **3. PostScript 3 (1997)**

PostScript 3 (1997) was a major update with faster rendering, better color, support for very high-resolution printing, improved fonts, and enhanced graphics effects. While now less common, it's still used in some high-end printing.

- **Major upgrade** with **more efficient rendering**.  
- **Enhanced color management** with ICC profiles.  
- **Improved support for high-resolution printing** (beyond 2400 dpi).  
- **Better font handling**, including support for **Multiple Master fonts**.  
- **More transparency and shading effects** (better graphics rendering).  
- **Replaced by PDF-based workflows** in modern publishing but still used in high-end printers.  
## PostScript in Printing

### Before PostScript:
- Early printers printed only **text characters**, usually in **ASCII**, with fixed glyphs (e.g., typewriter keys, metal bands, or optical plates).  
- **Dot matrix printers** introduced selectable fonts and custom glyph uploads, along with basic **raster graphics** via escape sequences, but required **specific drivers for each printer model**.  
- **Vector graphics** were handled by **plotters** (e.g., HPGL-based), but these were **slow, expensive, and limited to graphics**.  

### PostScript Printing:
- **Laser printers** combined the strengths of dot matrix printers and plotters, enabling **high-quality text and graphics on the same page**.  
- **PostScript unified printing control** with a **single, device-independent language** that worked across different printers and software.  
- Unlike traditional printer control languages, **PostScript is a full programming language**, allowing **precise document rendering**.  
- **On-the-fly rasterization**: PostScript defines everything (including text) using **straight lines and Bézier curves**, allowing smooth **scaling, rotation, and transformations**.  
- PostScript interpreters, called **Raster Image Processors (RIPs)**, convert instructions into dots needed for final output.

## PostScript Font Handling  

PostScript's font system uses basic graphic shapes to create scalable glyphs, allowing fonts to be resized without losing quality. Font hinting is used to ensure that fonts remain clear and legible even at small sizes or low resolutions. PostScript fonts are stored in various specialized "Type" formats, each offering different capabilities.

### PostScript Font System
- Uses **graphics primitives** to define **scalable** glyphs.  
- **Font hinting** ensures high-quality rendering, even at **low resolutions**.  
- Fonts were stored in specialized **Type formats** with different capabilities.  

### **PostScript Font Types**

PostScript offered various font formats. Adobe's high-quality Type 1 fonts were initially licensed, while Type 3 fonts, lacking standard hinting, were used by others. Type 2 and CFF formats reduced file sizes and paved the way for OpenType. CID-Keyed fonts supported large Asian character sets and could use either Type 1 or Type 2 structures.

- **Type 1 Font (T1):**  
  - Proprietary **compressed & encrypted** font format by Adobe.  
  - Used for **high-quality, hinted fonts**.  
  - Adobe initially licensed Type 1 technology for a fee.  

- **Type 3 Font (T3):**  
  - Allowed **full PostScript features**, but lacked **standardized hinting**.  
  - Used by those who couldn't license Type 1 technology.  

- **Type 2 Font (T2) & Compact Font Format (CFF):**  
  - Reduced **font file size** for efficiency.  
  - Became the basis for **OpenType fonts**.  

- **CID-Keyed Fonts:**  
  - Designed for **Asian (CJK) character sets** with **large encoding spaces**.  
  - Could use **Type 1 or Type 2** for different font structures.  

### **Font Format Evolution**

Apple created TrueType fonts to compete with Adobe's fonts. This made Adobe share how their fonts worked.  Later, Adobe and Microsoft joined together to make OpenType fonts, which combined the best of both and became the standard font format we use today.

- **TrueType (1991):**  
  - Developed by **Apple** as a competitor to Adobe’s system.  
  - Forced Adobe to **publish the Type 1 spec** for public use.  

- **OpenType (Late 1990s):**  
  - Jointly developed by **Adobe & Microsoft**.  
  - **Unified Type 1 and TrueType** functionality.  
  - Became the industry standard for modern fonts.  

### **End of Type 1 Support**  
- Adobe officially **ended support for Type 1 fonts in January 2023** in favor of **OpenType**.

## Portable Document Format (PDF) and PostScript

### PDF vs. PostScript

PDF and PostScript are two document formats that produce identical printed output because they use the same underlying graphics system. The key difference lies in their structure: PostScript is a full-fledged programming language, allowing for dynamic operations, while PDF is a more streamlined, static format designed for efficient viewing and navigation.  Despite these differences, it's possible to convert files between the two formats.

- **Similar Imaging Model** – Both **PDF and PostScript** use the same graphics system, ensuring **identical printed output**.  
- **What's the Difference?**   
  - **PostScript** is a **Turing-complete programming language** capable of dynamic operations.  
  - **PDF** is a **static data structure**, optimized for **efficient access and navigation**, making it better for **interactive viewing**.  
- **Mutual Convertibility** – PDFs can be **converted to PostScript**, and vice versa.  

### **The PostScript Language**

PostScript is a stack-based programming language with dynamic typing, similar to Forth but with Lisp-like data structures. It uses Reverse Polish Notation, requiring careful memory management.  PostScript uses arrays and dictionaries, handles typing at runtime, and includes garbage collection. Comments start with "%", and programs typically begin with "%!PS".

- **Turing-Complete & Stack-Based** – Similar to **Forth**, but with **dynamic typing** and **Lisp-like** data structures.  
- **Reverse Polish Notation (RPN)** – Operators act on a **stack**, requiring careful management.  
- **Memory Management** –  
  - Uses **scoped memory**.  
  - Introduced **garbage collection** in PostScript **Level 2**.  
- **Data Structures** –  
  - Uses **arrays & dictionaries**.  
  - No formal type declarations—typing is managed at runtime.  
- **Comments & Program Structure** –  
  - **%** introduces comments.  
  - Programs typically start with **"%!PS"** to indicate PostScript format.  

### **How PostScript is Used**  
- Mostly **generated by software**, not manually written.  
- Can be used as a **full-fledged programming language** for automation.  
- Interpreted by **printers (RIPs)** or **on-screen viewers**.  

## Example of a Simple PostScript File

Here’s a simple example of a **PostScript (.ps) file** that prints "Hello, World!" on a page:  

```postscript
%!PS
/Times-Roman findfont 24 scalefont setfont
100 700 moveto
(Hello, World!) show
showpage
```

### **Explanation:**
1. `%!PS` → Identifies the file as a PostScript document.  
2. `/Times-Roman findfont 24 scalefont setfont` → Selects the **Times-Roman** font at size **24**.  
3. `100 700 moveto` → Moves the cursor to coordinates **(100, 700)** on the page.  
4. `(Hello, World!) show` → Prints **"Hello, World!"** at the specified position.  
5. `showpage` → Tells the printer to **print the page**.  

You can save this as **hello.ps** and open it with a **PostScript viewer** (e.g., **GSview**, **Ghostscript**) or send it to a **PostScript printer**.

### add screenshot here

## List of Software to Render PostScript

### **PostScript Viewers & Interpreters**  
1. **Ghostscript** (Open-source) – Popular interpreter for PostScript and PDF.  
2. **GSview** – GUI frontend for Ghostscript.  
3. **MuPDF** – Lightweight viewer supporting PostScript and PDFs.  
4. **Xpdf** – Open-source PDF viewer with some PostScript support.  
5. **Evince** – GNOME document viewer that can handle PostScript files.  
6. **Okular** – KDE document viewer with PostScript support.  
7. **Apple Preview** – Built-in macOS viewer supporting PostScript & PDF.  

### **PostScript Printers & Rasterizers**  
8. **Adobe Acrobat Distiller** – Converts PostScript to high-quality PDFs.  
9. **CUPS (Common Unix Printing System)** – Handles PostScript printing on Unix/Linux.  
10. **PPR (Printer Production Release)** – PostScript spooler & renderer.  

### **Vector Graphics & DTP Software**  
11. **Adobe Illustrator** – Can open & edit PostScript files.  
12. **CorelDRAW** – Supports PostScript for vector graphics.  
13. **Scribus** – Open-source desktop publishing software with PostScript support.  
14. **Inkscape** – Can import/export PostScript (via Ghostscript).  

### **Command-Line & Conversion Tools**  
15. **ps2pdf** (part of Ghostscript) – Converts PostScript to PDF.  
16. **pstopdf** (macOS command-line tool) – Converts PostScript to PDF.  
17. **ImageMagick** – Can render PostScript files into images.  
