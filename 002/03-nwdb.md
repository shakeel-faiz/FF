## What is an NWDB file?

The NWDB file format is known as the Neat Database File and is associated with **Neat 5** which is a digital document management application designed to organize scanned documents, receipts, and contacts. An NWDB file is created when user scans documents using Neat software. It contains images of these scanned documents along with metadata which helps in organizing and retrieving the files.

Even though it uses the **.nwdb extension**, an NWDB file is fundamentally a **SQL Server Compact Edition (SQLCE)** database. It means that any application capable of opening .sdf files can also access .nwdb files. 

The default name for NWDB file is **ImageDB1.nwdb**. If multiple NWDB files are created they are sequentially named (e.g., ImageDB2.nwdb, ImageDB3.nwdb, etc.).

NWDB files are generally found in the Neat Data folder that is located within the user's Documents folder. This folder normally contains at least three important files: 

- The **Neatworks NWDB** file which is the main database file
- The **Image NWDB** file which contains actual scanned images
- And the **Cabinet NWCAB** file which is used for managing the database structure.

If you come across an error when trying to open an NWDB file, it may point out that a file in your database is missing or corrupted or that the database is locked by another program. To avoid these issues, make sure all necessary files are present in the **Neat Data** folder.


