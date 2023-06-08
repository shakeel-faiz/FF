## What is a HPP file?

The ".hpp" file format is commonly used for header files in C++ programming language. Header files typically contain declarations and definitions of functions, classes, variables and constants that are used by other source code files in C++ project.

The purpose of using header files is to provide a way to share common code across multiple source code files without duplicating code itself. When C++ source file needs to access declarations or definitions from header file, it includes the header file using preprocessor directive `#include`.

The ".hpp" file extension is often used to indicate that a file is a C++ header file. It is not a requirement to use this specific extension for header files, and you may also come across header files with ".h" or other extensions. The choice of extension is largely a matter of convention and personal preference.

When a C++ source file includes header file using `#include`, the compiler effectively combines content of header file with source file before compiling it as a unit. This allows the source file to access declarations and definitions in header file, providing the necessary information for compiler to perform type checking and code generation.

## What does HPP file contain?

Here are some common contents you may find in ".hpp" file:

- **Function declarations:** Header files often include function declarations without their actual implementations. These declarations provide information about function's name, return type and parameters, allowing other source code files to use function without needing to know implementation details.
- **Class declarations:** Header files can contain class declarations, including class name, member variables, member functions and access specifiers. By including class declaration in header file, other source code files can create objects of that class and access its members.
- **Constant declarations:** Header files can define constants, such as global variables or enum values that are meant to be shared across multiple source code files. These constants can be accessed by including header file in other source files, allowing them to use the defined constants.
- **Type definitions:** Header files may contain type definitions using "typedef" keyword or type aliases using "using" keyword. These definitions create new names for existing types, making code more readable and maintainable.
- **Inline function definitions:** In some cases, header files may contain inline function definitions. Inline functions are small functions that are expanded at call site rather than being called as separate function. Including inline function definition in header file allows compiler to replace function call with function body directly, potentially improving performance.
