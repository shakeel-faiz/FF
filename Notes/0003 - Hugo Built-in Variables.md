Excellent — this is a very good question 👍
Let’s go deep and clear on **Hugo built-in variables**, since understanding them is key to writing powerful templates.

---

## 🧠 What are Hugo Built-in Variables?

In Hugo, when rendering a page or a layout, Hugo automatically provides certain **contextual variables** (called *built-in variables*) to the template.
They hold data about:

* The site
* The current page
* The section
* The taxonomies
* Output formats
* Menus
  …and more.

These are the variables that start with a **dot (`.`)** — like `.Site`, `.Title`, `.Params`, `.Content`, `.Permalink`, etc.
You **don’t define** them — Hugo injects them automatically.

---

## 🏗️ Major Categories of Built-in Variables

Let’s group them logically 👇

---

### 1. 🌐 **Site-wide Variables**

| Variable             | Description                                                         |
| -------------------- | ------------------------------------------------------------------- |
| `.Site`              | The global site object. Gives access to all site data and settings. |
| `.Site.Title`        | Title of the site from `config.yml`.                                |
| `.Site.Params`       | All parameters under `params:` in your config file.                 |
| `.Site.BaseURL`      | Your site’s base URL.                                               |
| `.Site.Menus`        | All menus defined in config.                                        |
| `.Site.Taxonomies`   | All taxonomies (tags, categories, etc.).                            |
| `.Site.Sections`     | All content sections.                                               |
| `.Site.RegularPages` | All regular content pages (excluding list pages).                   |
| `.Site.Pages`        | All pages including list pages.                                     |
| `.Site.Home`         | The homepage page object.                                           |

---

### 2. 📄 **Page-specific Variables**

| Variable                           | Description                                              |
| ---------------------------------- | -------------------------------------------------------- |
| `.Title`                           | Page title from front matter.                            |
| `.Content`                         | The rendered HTML content of the page.                   |
| `.Plain`                           | Content without HTML tags.                               |
| `.Summary`                         | Auto-generated or manual summary.                        |
| `.Permalink`                       | Absolute URL to the page.                                |
| `.RelPermalink`                    | Relative URL to the page.                                |
| `.Date`                            | Date defined in front matter or file metadata.           |
| `.PublishDate`, `.Lastmod`         | Publish and last modified dates.                         |
| `.Type`                            | Content type (usually folder name under `content/`).     |
| `.Kind`                            | Page kind (`page`, `home`, `section`, `taxonomy`, etc.). |
| `.Params`                          | Custom front matter parameters.                          |
| `.Section`                         | The section name of the page.                            |
| `.Weight`                          | Used for ordering pages.                                 |
| `.PrevInSection`, `.NextInSection` | Previous and next pages in same section.                 |
| `.WordCount`, `.ReadingTime`       | Word count and estimated reading time.                   |

---

### 3. 🧩 **Output Format Variables**

| Variable                    | Description                                                 |
| --------------------------- | ----------------------------------------------------------- |
| `.OutputFormats`            | All output formats (HTML, RSS, JSON, etc.) for the page.    |
| `.CurrentOutputFormat`      | The format currently being rendered.                        |
| `.AlternativeOutputFormats` | All *other* formats for the page (besides the current one). |
| `.OutputFormat`             | Alias for `.CurrentOutputFormat`.                           |

Example:

```go
{{ range .AlternativeOutputFormats }}
  <link rel="{{ .Rel }}" type="{{ .MediaType.Type }}" href="{{ .Permalink }}">
{{ end }}
```

---

### 4. 🧭 **List Page Variables (Sections, Taxonomies)**

| Variable      | Description                                  |
| ------------- | -------------------------------------------- |
| `.Pages`      | Pages contained in a section or taxonomy.    |
| `.Paginator`  | Object for paginated lists.                  |
| `.Data.Pages` | Access pages within data-driven list pages.  |
| `.Data.Terms` | Terms (tags, categories) for taxonomy lists. |

---

### 5. 🪣 **File and Resource Variables**

| Variable                        | Description                                               |
| ------------------------------- | --------------------------------------------------------- |
| `.File`                         | Access metadata about the source file (path, name, etc.). |
| `.Resources`                    | Page bundle resources (images, files, etc.).              |
| `.Resources.ByType "image"`     | Filters images from resources.                            |
| `.Resources.Get "filename.jpg"` | Gets a specific file.                                     |
| `.ResourceType`                 | Type of resource (image, page, etc.).                     |

---

### 6. 🧮 **Site Data Variables**

| Variable                                      | Description                                                                      |
| --------------------------------------------- | -------------------------------------------------------------------------------- |
| `.Data`                                       | Accesses non-page data files from `/data/` folder. Example: `site.Data.products` |
| `.Scratch`                                    | Temporary storage for variables during template rendering.                       |
| `.IsHome`, `.IsPage`, `.IsSection`, `.IsNode` | Boolean helpers to check page kind.                                              |

---

### 7. ⚙️ **Context & Miscellaneous**

| Variable                         | Description                                  |
| -------------------------------- | -------------------------------------------- |
| `.Now`                           | Current date/time at build.                  |
| `.Lang`                          | Current language (for multilingual sites).   |
| `.AlternativeOutputFormats`      | Already discussed — other formats available. |
| `.IsTranslated`, `.Translations` | For multilingual content.                    |

---

## 🧭 Example of Typical Usage in `head.html`

```go
<title>{{ .Title }} | {{ .Site.Title }}</title>

{{ range .AlternativeOutputFormats }}
<link rel="{{ .Rel }}" type="{{ .MediaType.Type }}" href="{{ .Permalink }}">
{{ end }}

<link rel="icon" href="{{ .Site.Params.assets.favicon | absURL }}">
```

---

### ✅ Summary

* **Built-in variables** are *context-aware*, meaning they change depending on whether you’re in a single page, list page, taxonomy, or home page.
* They **start with `.`** (dot) because they refer to the current context object (like `this` in programming).
* You can inspect available variables by running:

  ```bash
  hugo --templateMetrics --verbose
  ```

  or by temporarily printing them in a template using:

  ```go
  {{ printf "%#v" . }}
  ```

---

Would you like me to give you a **cheat sheet (table)** of the *most important Hugo built-in variables* — formatted for quick reference (for example, one you can keep in your notes while editing templates)?
