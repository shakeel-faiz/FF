Absolutely! Hugo doesn’t just have the **Page object**—it has several **built-in objects** that templates can work with. Understanding them helps you access content, site data, configuration, and more. Here's a detailed breakdown:

---

## 1. **Page Object (`.Page` / `.`)**

Represents a single content page (Markdown file).
Key properties:

* `.Title` – Page title
* `.Content` – Rendered HTML content
* `.Summary` – Summary of the page
* `.Params` – Front matter parameters
* `.Date` – Date of the page
* `.Type` – Page type (`post`, `page`, etc.)
* `.Section` – The section the page belongs to (`blog`, `docs`)
* `.RelPermalink` – URL of the page
* `.WordCount` – Word count

---

## 2. **Site Object (`.Site`)**

Represents the **whole site**.
Useful for site-wide info, navigation, and collections of pages.

Key properties:

* `.Site.BaseURL` – Base URL of the site
* `.Site.Title` – Site title from `config.toml`
* `.Site.Params` – Site-wide parameters
* `.Site.Pages` – All pages on the site
* `.Site.RegularPages` – Pages excluding list pages
* `.Site.Taxonomies` – Tags, categories, etc.
* `.Site.Menus` – Menu definitions

**Example:**

```go
{{ range .Site.Menus.main }}
  <a href="{{ .URL }}">{{ .Name }}</a>
{{ end }}
```

---

## 3. **Page Collections (`.Pages`)**

Represents a **list of pages**, usually in a section or taxonomy.

* `.Pages` – All pages in the current section/context
* `.RegularPages` – Only regular content pages
* `.ByDate` / `.ByTitle` – Sorted lists

**Example:**

```go
{{ range .Pages.ByDate.Reverse }}
  <h2>{{ .Title }}</h2>
{{ end }}
```

---

## 4. **Taxonomy Objects**

* `.Site.Taxonomies` – Map of taxonomy name → list of terms
* `.Site.Taxonomy` – Each term has `.Pages`

**Example:**

```go
{{ range $name, $taxonomy := .Site.Taxonomies }}
  <h3>{{ $name }}</h3>
  {{ range $taxonomy.Pages }}
    <a href="{{ .RelPermalink }}">{{ .Title }}</a>
  {{ end }}
{{ end }}
```

---

## 5. **Menu Objects**

* `.Site.Menus` – Site menus defined in config
* Each menu item has: `.Name`, `.URL`, `.Weight`, `.Identifier`

---

## 6. **Data Objects (`.Site.Data`)**

* Access **data files** (`.yaml`, `.toml`, `.json`) stored in `data/`
* Can be used for structured content like authors, settings, etc.

**Example:**

```go
{{ range .Site.Data.authors }}
  <p>{{ .name }} – {{ .email }}</p>
{{ end }}
```

---

## 7. **Scratch Object (`.Scratch`)**

* A **temporary storage object** for storing variables in templates.
* Useful inside loops or partials.

**Example:**

```go
{{ .Scratch.Set "counter" 0 }}
{{ range .Pages }}
  {{ .Scratch.Add "counter" 1 }}
{{ end }}
<p>Total pages: {{ .Scratch.Get "counter" }}</p>
```

---

## 8. **Other Objects**

* **`.Params`** – Front matter parameters (on page or site level)
* **`.Resources`** – Page resources like images or PDFs
* **`.Paginator`** – Pagination object
* **`.Output`** – Output formats (HTML, RSS, JSON, etc.)

---

### ✅ Summary

Hugo has a **hierarchy of objects**:

```
.Site          → site-wide info
.Site.Pages    → all pages
.Pages         → pages in current section/context
.Page          → current page
.Params        → front matter or site params
.Data          → data files
.Scratch       → temporary storage
.Menus         → site menus
.Taxonomies    → tags, categories
.Resources     → page resources
```

---

If you want, I can make a **visual map of Hugo objects and their hierarchy**—it’s much easier to understand at a glance than a long list. It’s super handy when building complex templates. Do you want me to make that?
