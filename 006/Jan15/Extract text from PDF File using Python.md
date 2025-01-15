## Extract Text from PDF File Using Python

In this article, we will let you know how to extract text from PDF file using Python. 

PDF stands for **Portable Document Format** is a popular digital document format. This format is designed to allow documents to be viewed or shared easily and reliably, regardless of software, hardware or operating system.  PDF files have the extension **.pdf**.

To extract text from a PDF file using Python, these libraries are commonly used. We will show you how to extract text from a PDF using both of them.

1. [**pypdf**][3]
1. [**PyMuPDF**][4]

## How to Extract Text from a PDF File Using pypdf in Python

Here are the steps.

1. Install pypdf
2. Run the code given in this article
3. See the output

### Install pypdf

You can install **pypdf** using the following command

```
pip install pypdf
```

### Sample Code to Extract Text from PDF using pypdf

**sample.pdf** - [Download Link][1] (This sample PDF will be used in the code, but you can certainly use your own PDF.)

**screenshot of sample.pdf**

![Sample Input PDF Screenshot][2]

### Code

Here is a sample code snippet for extracting text from PDF using pypdf.

```
from pypdf import PdfReader

# Specify the PDF file path
pdf_file_path = "sample.pdf"

# Create a PDF reader object
reader = PdfReader(pdf_file_path)

# Initialize a variable to store the extracted text
extracted_text = ""

# Iterate through the pages and extract text
for page in reader.pages:
    extracted_text += page.extract_text()

# Print the extracted text
print("Extracted Text:")
print(extracted_text)
```

### Output

Here is the output of the sample code provided above.

```
Extracted Text:
This is a sample pdf. Page 1

Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type
and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with
the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop
publishing software like Aldus PageMaker including versions of Lorem Ipsum.
  This is sample pdf. Page 2
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type
and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the
release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing
software like Aldus PageMaker including versions of Lorem Ipsum.
  This is sample pdf. Page 3
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type
and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the
release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing
software like Aldus PageMaker including versions of Lorem Ipsum.
```

## How to Extract Text from a PDF File Using PyMuPDF in Python

Here are the steps.

1. Install PyMuPDF
2. Run the code given in this article
3. See the output

### Install PyMuPDF

Install **PyMuPDF**, also known as **fitz**, using the following command.

```
pip install pymupdf
```

### Sample Code to Extract Text from PDF using PyMuPDF

We used the same pdf as used before

**sample.pdf** - [Download Link][1] (This sample PDF will be used in the code, but you can certainly use your own PDF.)

### Code

Here is a sample code snippet for extracting text from PDF using PyMuPDF.

```
import fitz  # PyMuPDF library

# Specify the PDF file path
pdf_file_path = "sample.pdf"

# Open the PDF file
pdf_document = fitz.open(pdf_file_path)

# Initialize a variable to store the extracted text
extracted_text = ""

# Iterate through all the pages and extract text
for page_number in range(len(pdf_document)):
    page = pdf_document[page_number]  # Get the page
    extracted_text += page.get_text()  # Extract text from the page

# Close the PDF file
pdf_document.close()

# Print the extracted text
print("Extracted Text using PyMuPDF:")
print(extracted_text)
```

### Output

Here is the output of the sample code provided above.

```
Extracted Text using PyMuPDF:
This is a sample pdf. Page 1 

Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been 
the
industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type
and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with
the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop  
publishing software like Aldus PageMaker including versions of Lorem Ipsum.


This is sample pdf. Page 2
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been 
the
industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type
and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the
release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing
software like Aldus PageMaker including versions of Lorem Ipsum.


This is sample pdf. Page 3
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been 
the
industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type
and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the
release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing
software like Aldus PageMaker including versions of Lorem Ipsum.

```

## See Also

- [Python PDF to Image Conversion: Step-by-Step Guide][5]
- [Batch change file encoding to UTF-8][6]


[1]: https://github.com/shakeel-faiz/InputOutputDocs/raw/master/python-convert-pdf-to-image/sample.pdf
[2]: https://raw.githubusercontent.com/shakeel-faiz/InputOutputDocs/master/python-convert-pdf-to-image/sample-input-pdf-screenshot.png
[3]: https://pypi.org/project/pypdf/
[4]: https://pypi.org/project/PyMuPDF/
[5]: https://blog.fileformat.com/programming/how-to-convert-pdf-to-image-in-python/
[6]: https://blog.fileformat.com/programming/batch-change-file-encoding-to-utf8/
