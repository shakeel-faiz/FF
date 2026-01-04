## PRACTICE STEP 1 — Coder Agent

### Prompt

```
{
  "task": "Create function",
  "language": "Python",
  "function_name": "add_numbers",
  "parameters": ["a", "b"],
  "return_type": "int",
  "requirements": ["function should return the sum of two numbers"],
  "instructions": "Return output only in JSON with keys: code and notes."
}
```

### Output

```
{
  "code": "def add_numbers(a: int, b: int) -> int:\n    return a + b",
  "notes": "This function takes two integers 'a' and 'b' as input and returns their sum."
}
```

## PRACTICE STEP 2 — Reviewer Agent

### Prompt

```
{
  "code": "def add_numbers(a: int, b: int) -> int:\n    return a + b",
  "checklist": [
    "Does the function handle numbers?",
    "Is the return type correct?",
    "Are there any errors?",
    "Should it handle non-numeric inputs?"
  ],
  "instructions": "Return output only in JSON with keys: issues and suggestions."
}
```

### Output

```
{
  "issues": [
    "The function does not handle non-numeric inputs, which could raise a TypeError if called with them."
  ],
  "suggestions": [
    "Consider adding input validation or type checking to handle non-numeric inputs gracefully.",
    "Optionally, add a docstring explaining the function's purpose and expected input types."
  ]
}
```

# PRACTICE STEP 3 — Coder Fixes Code

```
{
  "task": "Fix function based on review",
  "original_code": "def add_numbers(a, b):\n    return a + b",
  "issues": [
    "The function does not handle non-numeric inputs, which could raise a TypeError if called with them."
  ],
  "suggestions": [
    "Consider adding input validation or type checking to handle non-numeric inputs gracefully.",
    "Optionally, add a docstring explaining the function's purpose and expected input types."
  ],
  "instructions": "Return output only in JSON with keys: code and notes."
}
```

### Output

```
{
  "code": "def add_numbers(a, b):\n    \"\"\"Add two numbers.\n\n    Parameters:\n    a (int or float): The first number.\n    b (int or float): The second number.\n\n    Returns:\n    int or float: The sum of a and b.\n\n    Raises:\n    TypeError: If either a or b is not a number.\n    \"\"\"\n    if not isinstance(a, (int, float)) or not isinstance(b, (int, float)):\n        raise TypeError('Both inputs must be numbers.')\n    return a + b",
  "notes": "Added type checking to ensure both inputs are numeric, raising a TypeError if not. Also added a docstring to explain the function's purpose and expected input types."
}
```

## PRACTICE STEP 4 — Reviewer Final Check

Send fixed code to Reviewer again:

```
{
  "code": "def add_numbers(a, b):\n    \"\"\"Add two numbers.\n\n    Parameters:\n    a (int or float): The first number.\n    b (int or float): The second number.\n\n    Returns:\n    int or float: The sum of a and b.\n\n    Raises:\n    TypeError: If either a or b is not a number.\n    \"\"\"\n    if not isinstance(a, (int, float)) or not isinstance(b, (int, float)):\n        raise TypeError('Both inputs must be numbers.')\n    return a + b",
  "checklist": [
    "Does the function handle numbers?",
    "Is the return type correct?",
    "Are there any errors?",
    "Should it handle non-numeric inputs?"
  ],
  "instructions": "Return output only in JSON with keys: issues and suggestions."
}
```

## Output
```
{
  "issues": [],
  "suggestions": [
    "The function is correct and handles numeric inputs properly.",
    "You could consider supporting additional numeric types like `decimal.Decimal` or `fractions.Fraction` if needed.",
    "Optional: Add handling for inputs that can be converted to numbers (e.g., numeric strings) if desired."
  ]
}
```
