GEDCOM and FamilySearch

## **What is GEDCOM?**
GEDCOM (**Genealogical Data Communication**) is an **open file format** designed for **storing, exchanging, and sharing genealogical data** (family tree information). It is widely used in genealogy software and websites, making it easier to **transfer** family tree data between different platforms.

## **Who Developed GEDCOM?**
GEDCOM was created by **The Church of Jesus Christ of Latter-day Saints (LDS Church)**, which operates **FamilySearch**—a major genealogy research organization. Their goal was to simplify genealogy data management and allow better **research collaboration**.

## **How Does GEDCOM Work?**
- GEDCOM files are **plain text files** (now using **UTF-8 encoding** as of version 7.0).
- They contain **information about individuals**, such as:
  - **Names**
  - **Birth and death dates**
  - **Family relationships** (parents, children, spouses)
  - **Events** (marriage, immigration, etc.)
- These records are **linked** using metadata, ensuring proper connections between family members.

## **GEDCOM Versions & Industry Standards**
- The latest official version is **GEDCOM 7.0**, released in **2021**.
- However, **GEDCOM 5.5.1 (from 1999, finalized in 2019)** remains the **most widely used standard**.
- Because GEDCOM 5.5.1 had limitations, some genealogy software developers created **custom extensions** like **GEDCOM 5.5 EL (Extended Locations)** to improve it.

## **Adoption of GEDCOM 7.0**
- **FamilySearch** planned to support GEDCOM 7.0 by **Q3 2022**.
- **Ancestry.com** has also shown interest in adopting it but has not provided a firm implementation date.

## **Why is GEDCOM Important?**
1. **Cross-Platform Compatibility** – Allows users to move their family tree data between different genealogy websites and software.
2. **Long-Term Data Storage** – Ensures genealogical data remains accessible in a standardized format.
3. **Genealogy Collaboration** – Enables researchers and family historians to share and merge data efficiently.

## **Explanation of the GEDCOM Data Model**  

GEDCOM uses a **lineage-linked data model** to organize **family relationships** in a structured way. It is based on the **nuclear family** concept, meaning it records relationships in terms of **parents and children** rather than just individuals.  

### **Key Components of the GEDCOM Data Model**  
1. **INDI (Individual) Records**  
   - Each person in the genealogy file is stored as an **INDI** (individual) record.  
   - Every individual is assigned a **unique ID number** to ensure proper linking in the file.  

2. **FAM (Family) Records**  
   - Family records (FAM) serve as the **linking structure** between individuals.  
   - A FAM record assigns:  
     - **HUSB** (husband) – The father in the family.  
     - **WIFE** (wife) – The mother in the family.  
     - **CHIL** (child) – The children of the couple.  
   - These labels are **historical** and based on the original GEDCOM model but are still used today.  

### **Evolution of Gender Representation in GEDCOM**  
- Initially, the GEDCOM model was designed assuming a **heteronormative family structure**, where a **male (HUSB) and female (WIFE) have children (CHIL)**.  
- The **GEDCOM 7.0 specification** clarifies that these terms **do not** imply gender roles or biological parenthood.  
- The updated specification allows for:  
  - **Same-sex couples**  
  - **Adoption, fostering, and cohabitation**  
  - **More flexible family structures**  
- The terms **'partners', 'parents', or 'spouses'** are now preferred when referring to individuals in a FAM record.  

### **Why Is This Important?**  
1. **Maintains Structured Relationships** – Ensures each person is correctly linked to parents, spouses, and children.  
2. **Improves Compatibility** – Allows genealogy software to recognize and organize family data efficiently.  
3. **Increases Inclusivity** – Supports diverse family structures without assuming traditional gender roles.  

---
## **Explanation of the Structure of a GEDCOM File**

A **GEDCOM file** consists of **three main sections**: the **header**, the **records**, and the **trailer**. Each section plays a specific role in organizing genealogical data, and the structure of the file is highly organized to ensure that relationships between individuals and families are clear and standardized.

### **1. Header Section**  
- The **header section** marks the start of the GEDCOM file and includes important **metadata** about the file itself, such as its version (e.g., GEDCOM 7.0) and any special settings or configurations for the file.  
- This section is represented by the **HEAD** record.

### **2. Records Section**  
This is the main part of the GEDCOM file and consists of several different record types, each serving a specific purpose:  

- **INDI (Individual Record):** Represents an individual person in the family tree.  
- **FAM (Family Record):** Represents a family, linking a husband, wife, and children.  
- **SOUR (Source Record):** Contains information about the sources used to support the data, such as historical records.  
- **OBJE (Object Record):** Represents multimedia objects, like photos or documents, associated with individuals or families.  
- **NOTE (Note Record):** Contains additional notes or comments that can provide extra context or explanations for a record.  
- **REPO (Repository Record):** Describes a place where genealogical information is stored, like a library or archive.  
- **SUBM (Submitter Record):** Represents the person or entity submitting the GEDCOM file.

Each of these records is structured hierarchically, with different **level numbers** indicating how the data is related. For instance:  
- **Level 0** is the **top level** for the most significant records, like **HEAD, TRLR, INDI, FAM, SOUR**, etc.
- **Level 1 or higher** represents sub-level records, like events or relationships tied to a specific individual or family.

### **3. Trailer Section**  
- The **trailer section** marks the end of the GEDCOM file and contains the **TRLR** record. It signifies that the file has concluded.

### **How It Works in Practice**
- **Level Numbers:** Every line in a GEDCOM file begins with a level number (e.g., 0, 1, 2), where **0** represents top-level records, and positive integers (1, 2, etc.) represent nested or subordinate records. This system ensures that relationships and hierarchies within the family tree are properly organized.
  
  For example:  
  - **Level 0**: HEAD (Header Record), TRLR (Trailer Record), INDI (Individual Record)
  - **Level 1**: MARR (Marriage Event), BIRT (Birth Event)
  - **Level 2**: DATE (Date of the event), PLAC (Place of the event)
  
- **Handwriting a GEDCOM file** is technically possible, but it’s **not human-friendly** due to its structured nature. It’s much easier to use software designed to work with GEDCOM files, which helps organize and format data correctly.

### **Validation and Quality Control**
- Since GEDCOM files need to be well-structured for proper use and transfer, there are tools to **validate** them for errors.
  - **PhpGedView Project**: Includes a GEDCOM validator for checking the structure.
  - **The Windows GEDCOM Validator**: A standalone tool for GEDCOM validation.
  - **Gedcheck**: The older validation tool, previously used by the LDS Church.

### **Challenges with GEDCOM Compatibility**  
- In the early 2000s, the **GEDCOM TestBook Project** evaluated how well different genealogy software complied with the **GEDCOM 5.5 standard**. The results revealed several issues, such as data loss or improper reading of the **NOTE tag**, which can appear at multiple levels.
  
- **GEDCOM 7.0** aims to address some of these issues, and **validation tools** for this newer standard exist to help ensure compatibility across different platforms.

### **Why is GEDCOM Validation Important?**
- Ensures that **data is structured correctly** and that relationships between individuals, families, events, and sources are maintained properly.
- Helps avoid **data loss** when transferring files between genealogy programs.
- Makes it easier for genealogists to **share information** across different platforms.
