In this article, we will guide you on how to work with PDF files using Python. For this, we’ll utilize the pypdf library.

Using the pypdf library, we’ll demonstrate how to perform the following operations:

- Extracting text from PDFs  
- Rotating PDF pages  
- Merging multiple PDFs  
- Splitting PDFs into separate files  
- Adding watermarks to PDF pages  

## Sample Codes

You can download all sample codes used in this article from the following link. It contains codes, input files and output files.

- [Code Examples and Sample Input Files – Working with PDF Files in Python][1]

## Install pypdf

To install pypdf, simply run the following command in your terminal or command prompt:

```bash
pip install pypdf
```
**Note:** The above command is case-sensitive.

## 1. Extracting text from PDF file

https://gist.github.com/fileformat-blog-gists/e2b43a49dbad9e89745f8f9777817acb

```
from pypdf import PdfReader

# Path to the PDF file
pdf_file = "pdf-to-extract-text/input.pdf"

# Create a PDF reader object
reader = PdfReader(pdf_file)

# Loop through the pages and extract text
for page_number, page in enumerate(reader.pages, start=1):
    print(f"Page {page_number}:")
    print(page.extract_text())
    print("-" * 50)  # Separator for readability
```

### Code Explanation

```python
reader = PdfReader(pdf_file)
```
- `PdfReader(pdf_file)` loads the PDF file into a **reader object**.  
- This object allows access to the pages and their content.

**Looping Through Pages and Extracting Text**

```python
for page_number, page in enumerate(reader.pages, start=1):
```
- `reader.pages` returns a list of pages in the PDF.
- `enumerate(..., start=1)` assigns a **page number starting from 1**.

**Printing Extracted Text**
```python
    print(f"Page {page_number}:")
    print(page.extract_text())
    print("-" * 50)  # Separator for readability
```
- `page.extract_text()` extracts text content from the current page.
- The script prints the extracted text along with the **page number**.
- `"-" * 50` prints a separator line (`--------------------------------------------------`) for better readability.

- Input PDF File used in Code

**Output:**

https://gist.github.com/fileformat-blog-gists/ab6976aa3a0fc2999093f5f9320a9e20










[1]: https://github.com/fileformat-blog-gists/code/tree/main/working-with-pdf-files-in-python
