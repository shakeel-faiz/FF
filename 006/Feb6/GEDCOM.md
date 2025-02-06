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

Would you like an example of how GEDCOM records look in text format?
