## What is a HPP file?

The ".hpp" file format is commonly used for header files in C++ programming language. Header files typically contain declarations and definitions of functions, classes, variables and constants that are used by other source code files in C++ project.

The purpose of using header files is to provide a way to share common code across multiple source code files without duplicating code itself. When C++ source file needs to access declarations or definitions from header file, it includes the header file using preprocessor directive `#include`.

The ".hpp" file extension is often used to indicate that a file is a C++ header file. It is not a requirement to use this specific extension for header files, and you may also come across header files with ".h" or other extensions. The choice of extension is largely a matter of convention and personal preference.

When a C++ source file includes header file using `#include`, the compiler effectively combines content of header file with source file before compiling it as a unit. This allows the source file to access declarations and definitions in header file, providing the necessary information for compiler to perform type checking and code generation.

