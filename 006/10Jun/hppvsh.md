# **.h vs .hpp: What's the Difference and Which Should You Use?**

When writing C++ programs, especially in large projects, organizing your code into multiple files is essential for readability and maintenance. This usually involves using **header files**, which come with the extensions `.h` or `.hpp`. But what's the difference between these two, and which one should you use?

In this article, we’ll break down the differences between `.h` and `.hpp` files, explore their history, and offer guidance on best practices.

## Understanding Header Files in C++

Header files contain **declarations** for functions, classes, constants, and macros that you can include in multiple source files. These files are then included in `.cpp` (C++ source) files using the `#include` directive.

### Common Contents of Header Files

* Class definitions
* Function declarations
* Constant definitions
* Macros
* Templates (in some cases)

## .h Files

### What is a .h File?

`.h` files are traditional **header files** and were first widely used in the C programming language. They are still used in both C and C++ projects to declare interfaces.

### Usage Example:

```cpp
// mathutils.h
#ifndef MATHUTILS_H
#define MATHUTILS_H

int add(int a, int b);
int subtract(int a, int b);

#endif
```

### Pros:

* Universally recognized (used in both C and C++).
* Suitable for projects involving both C and C++ code.

### Cons:

* Can cause ambiguity in C++ projects about whether the file is C-style or C++-style.

## .hpp Files

### What is a .hpp File?

`.hpp` files are C++-specific header files. They function the same as `.h` files but are used to **explicitly indicate** that the header is meant for C++ code.

### Usage Example:

```cpp
// vectorutils.hpp
#ifndef VECTORUTILS_HPP
#define VECTORUTILS_HPP

#include <vector>

std::vector<int> filter_even(const std::vector<int>& input);

#endif
```

### Pros:

* Clearly indicates the file is meant for C++ code.
* Avoids confusion when mixing C and C++.
* Helpful in mixed-language projects or teams following strict naming conventions.

### Cons:

* Slightly less common in older codebases.
* Not recognized by some legacy systems that expect `.h`.

## .h vs .hpp: Key Differences

| Feature               | `.h` File                           | `.hpp` File                   |
| --------------------- | ----------------------------------- | ----------------------------- |
| Language Association  | C and C++                           | C++ only                      |
| Convention or Rule?   | Convention                          | Convention                    |
| Usage in C++ Projects | Common                              | Preferred by some for clarity |
| Template Support      | Yes                                 | Yes                           |
| Code Ambiguity        | Possible in mixed-language projects | Less likely                   |

## Best Practices for Choosing Between .h and .hpp

Here are some general guidelines to help you choose:

### Use `.h` if:

* You’re writing code that must be compatible with both C and C++.
* You’re maintaining or extending legacy code that already uses `.h`.

### Use `.hpp` if:

* You want to make it clear the file is C++-specific.
* You’re working in a C++-only project or using C++-specific features like classes, templates, and namespaces.

## Common Project Structures

### Example with `.h`:

```
project/
├── main.cpp
├── mathutils.h
└── mathutils.cpp
```

### Example with `.hpp`:

```
project/
├── main.cpp
├── vectorutils.hpp
└── vectorutils.cpp
```

Both structures are valid; the difference is primarily in clarity and team preferences.

## Conclusion

The choice between `.h` and `.hpp` is largely a matter of **convention**, not functionality. Both serve the same purpose: to declare interfaces and shared code across multiple C++ source files.

However, for C++-specific code, using `.hpp` can make your intentions clearer and help avoid confusion in larger codebases—especially those involving multiple languages. For mixed-language or legacy projects, `.h` might still be the way to go.

### Key Takeaway:

> Use `.hpp` when you want to signal "this is C++ code only" — stick with `.h` if you're working in environments that blend C and C++.

