Creating a detailed prompt to instruct an LLM (like GPT-4 with a code generator or Claude) to recreate a specific web page is a great way to generate clean, semantic code quickly. Here is a highly detailed prompt you can use.

---

### How to use this prompt:

Paste the entire text below into an LLM (such as GPT-4, GPT-3.5, Claude 3, etc.) with a prompt like: **"Please generate the complete, single-file HTML and CSS code for the webpage described in the following detailed prompt. Ensure the code is semantic, responsive, and closely matches the visual style described."**

---

### Detailed Design Specification for LLM Recreation

**Core Objective:** Create a high-fidelity, single-page responsive web layout that precisely matches the visual hierarchy, text, color scheme, and typography of the `image_0.png`.

**1. Design & Color Palette:**

* **Overall Theme:** Clean, corporate, metric-driven interface.
* **Header (Upper Section):** Solid Blue gradient background.
* Start Color: Solid Medium-Light Blue (`#2A73E8`)
* End Color (or top layer): A lighter, more translucent blue overlay, or a slight gradient shift, to match the multi-toned background of the original.


* **Middle Section:** Solid White (`#FFFFFF`).
* **Footer (Upper/Newsletter):** Solid Medium-Dark Blue (`#0069C1`).
* **Footer (Lower):** Dark Charcoal/Black (`#1A1D20`).
* **Typography:** A clean, modern sans-serif font family (e.g., Montserrat, Roboto, Open Sans). Font colors are White (`#FFFFFF`) for text on blue and dark backgrounds, and Black (`#000000`) for text on white backgrounds, with lighter gray for accents. Links are in a lighter, contrasting blue.

**2. Layout Structure & Elements (from top to bottom):**

* **A. Global Navigation Header (Top Blue Area):**
* **Content:** A dark, semi-translucent overlay bar.
* **Components:**
* **Left:** Aspose Logo (SVG or placeholder text with a specific color swirl to match `image_0.png`) and the text "ASPOSE".
* **Center:** Main menu links: `Products`, `Purchase`, `Support`, `Websites`, `About`.
* **Right:** Search and User profile icons.


* **Styling:** Links are light-colored. Clean spacing.


* **B. Key Performance Indicator (KPI) Banner (Primary Blue Section):**
* **Components:**
* **Top Left (Breadcrumb):** Small text `Metrics / Agents`.
* **Center Text:** Large, bold headline: `Aspose Agents Have Completed`.
* **KPI Number:** **Very large, bold text**: `164,614`.
* **Description Text:** Text below the number: `Autonomous Tasks!`.


* **Styling:** All text is white. Center-aligned.


* **C. Categorical Metrics Section (White Section):**
* **Components:**
* **Header:** Main bold text: `Explore Agents Metrics by Category`.
* **Grid Layout (2 columns):**
* **Column 1, Top:**
* Label: `Agent Metrics By`
* Category Title: `Website Sections`
* Description: `View Agents metrics by Website Sections.`
* Call-to-Action Link: `Automation by Website Sections` (style as an underlined blue text link).


* **Column 2, Top:**
* Label: `Agent Metrics By`
* Category Title: `Programming Languages`
* Description: `View Agents metrics by programming language.`
* Call-to-Action Link: `Automation by Programming Language` (style as an underlined blue text link).




* **Grid Layout (Single column or offset):**
* **Below Column 1:**
* Label: `Agent Metrics By`
* Category Title: `Product Family`
* Description: `View Agents metrics by product family.`
* Call-to-Action Link: `Automation by Product Family` (style as an underlined blue text link).






* **Styling:** The grid should maintain its unique offset (Product Family below Website Sections). Category titles are a prominent font size. The section has clean top and bottom separation lines.


* **D. Newsletter Subscription Footer (Blue Section):**
* **Components:**
* **Text (Left):**
* Bold text: `Subscribe to Aspose Product Updates`
* Smaller text: `Get monthly newsletters & offers directly delivered to you mailbox.`


* **Form (Right):**
* Email Input Field (text `Enter email address` as placeholder).
* Submit Button (solid red color, text `Submit`).




* **Styling:** White text for all text. The layout should be flexible (e.g., flexbox) to place text on the left and the form on the right.


* **E. Social and Navigation Footer (Dark Charcoal Section):**
* **Components:**
* **Social Icons (Top):** Clean, white icons for Facebook, X (formerly Twitter), LinkedIn, other platforms.
* **Main Navigation (Middle):** A long, clean horizontal list of links separated by pipes (`|`): `Home | Products | New Releases | Pricing | Docs | Live Demos | Free Support | Paid Support | Paid Consulting | Blog | Websites | About`.
* **Legal/Copyright (Bottom):** Small text: `© Aspose Pty Ltd 2001-202X All Rights Reserved | Privacy Policy | Terms of Use | Contact`. (Use a modern placeholder for the year).


* **Styling:** White or light-gray text. The layout is center-aligned. Icons have good spacing.



**3. Responsive Considerations:**

* Ensure that on smaller screens (tablets and mobiles), the grid in section C stacks vertically.
* The footer links should wrap nicely.
* The header elements should adapt (perhaps using a hamburger menu for the main navigation).

**4. Additional Instructions for Code:**

* Provide a single, complete HTML file with all CSS embedded in the `<style>` tag.
* Do not include any JavaScript for this visual recreation.
* All images can be represented by semantic text placeholders within styled `<div>` elements or standard `<img>` tags with appropriate `alt` text.
* Ensure proper use of semantic HTML tags (`<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<footer>`, etc.).

**Final Goal:** The resulting HTML/CSS should render a page that is a high-fidelity visual matching of the provided screenshot, including spacing, colors, and relative element sizing.

# End

---

# Start

To learn this prompt "by heart," focus on these  **5 core components**. They represent the structural and visual DNA of the webpage you are trying to build.

1. The Color Palette (Hex Codes)

These define the brand identity. Memorize these specific shades:

-   **#2A73E8:**  Medium-Light Blue (Header/Hero)
-   **#FFFFFF:**  Solid White (Main Content)
-   **#0069C1:**  Medium-Dark Blue (Newsletter)
-   **#1A1D20:**  Dark Charcoal (Bottom Footer)
-   **#000000:**  Black (Text on white backgrounds)

2. The Visual Hierarchy (Sections)

Think of the page as a stack of 5 distinct horizontal blocks:

-   **Global Navigation:**  The dark, semi-translucent bar with the logo and menu.
-   **KPI Banner:**  The big blue "Hero" section showing the massive number (**164,614**).
-   **Categorical Metrics:**  The white grid section with the 2-column layout.
-   **Newsletter Footer:**  The blue bar with the red "Submit" button.
-   **Social/Legal Footer:**  The final dark bar with icons and the copyright.

3. Key Layout Nouns (UI Elements)

These are the specific "objects" you need to place:

-   **Breadcrumb:**  The small "Metrics / Agents" text.
-   **KPI Number:**  The large, bold focal point.
-   **Grid Offset:**  The specific layout where "Product Family" sits below "Website Sections."
-   **Call-to-Action (CTA):**  The underlined blue links (e.g., "Automation by...").
-   **Semantic Tags:**  The HTML "containers" like  `<header>`,  `<nav>`,  `<section>`, and  `<footer>`.

4. Typography & Assets

-   **Fonts:**  Modern sans-serif (Montserrat, Roboto, or Open Sans).
-   **Icons:**  SVG placeholders for the Aspose logo and Social Media (Facebook, X, LinkedIn).
-   **Input Field:**  The email subscription box with a red button.

5. Technical Constraints

-   **Single-file:**  Everything (HTML and CSS) must be in one document.
-   **Responsive:**  The layout must stack vertically on mobile (using  **Flexbox**  or  **Grid**).
-   **No JavaScript:**  The recreation is purely visual using CSS.




