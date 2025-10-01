Perfect! I’ll craft a **single, detailed prompt** that you can paste into the GitHub Copilot Chat (or the prompt box on [github.com/copilot](https://github.com/copilot)) to generate **multiple C# classes and a small ASP.NET Core setup** in one go. This will count as **1 chat request**.

---

### 💡 Big Test Prompt (Copy-Paste)

```
Generate an ASP.NET Core project setup with the following requirements:

1. Create three C# classes:

   - **Person.cs**: properties Name (string) and Age (int)
   - **Employee.cs**: inherits from Person, adds Salary (decimal) and Position (string)
   - **Department.cs**: contains a List<Employee> named Employees and a property DepartmentName (string)

2. Create a simple **DbContext class** (CompanyContext) with DbSet<Person>, DbSet<Employee>, and DbSet<Department>.

3. Create a basic **EmployeeController** with the following endpoints:
   - GET /employees → returns all employees
   - GET /employees/{id} → returns a single employee by Id
   - POST /employees → adds a new employee
   - PUT /employees/{id} → updates an employee
   - DELETE /employees/{id} → deletes an employee

4. Include proper **using directives** and namespaces for each class and controller.

5. Use **ASP.NET Core 8 conventions** (minimal APIs or controllers, your choice is fine).

6. Provide the output as if each class is in its own `.cs` file and the controller in its own file, including comments like `// File: Employee.cs` to separate them.

7. Generate clean, compilable C# code with correct indentation.
```

---

### ✅ What this prompt does

* Copilot Chat will likely generate:

  * 3 classes (`Person`, `Employee`, `Department`)
  * 1 DbContext (`CompanyContext`)
  * 1 controller (`EmployeeController`)
* It will include **file separators in comments**.
* All in **1 response**, counting as **1 chat request**.

---

If you want, I can also **make an even bigger prompt** that includes:

* **Some sample data seeding**,
* **A service layer**,
* **DTOs and mapping**,

…so you could generate a mini working ASP.NET Core app **all in one prompt**.

Do you want me to make that ultra-detailed version?
