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

Screenshot
