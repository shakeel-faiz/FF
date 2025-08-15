Perfect! If you’ve practiced `.html()`, `.before()`, and `.after()`, there are several **other related jQuery DOM manipulation methods** that you should know — they’re all about **inserting, removing, or replacing elements**.

---

### **1️⃣ `.prepend()`**

* Inserts content **inside the element, at the beginning**.

```javascript
$('#container').prepend('<p>First paragraph</p>');
```

* Example:

```html
<div id="container">
  <p>Existing</p>
</div>
```

After `.prepend()`:

```html
<div id="container">
  <p>First paragraph</p>
  <p>Existing</p>
</div>
```

---

### **2️⃣ `.append()`**

* Inserts content **inside the element, at the end**.

```javascript
$('#container').append('<p>Last paragraph</p>');
```

After `.append()`:

```html
<div id="container">
  <p>Existing</p>
  <p>Last paragraph</p>
</div>
```

---

### **3️⃣ `.replaceWith()`**

* Replaces the **selected element itself** with new content.

```javascript
$('#old').replaceWith('<div id="new">New content</div>');
```

---

### **4️⃣ `.remove()`**

* Removes the element **from the DOM** completely.

```javascript
$('.ad-banner').remove();
```

---

### **5️⃣ `.empty()`**

* Removes **all child elements and text** inside the selected element.

```javascript
$('#container').empty();
```

---

### **6️⃣ `.clone()`**

* Creates a **copy of an element** (can include child elements and event handlers if needed).

```javascript
var copy = $('#item').clone();
$('#another-container').append(copy);
```

---

### **7️⃣ `.wrap()` / `.wrapAll()`**

* Wraps the element(s) in a new HTML structure.

```javascript
$('p').wrap('<div class="wrapper"></div>');
```

---

### **8️⃣ `.unwrap()`**

* Removes the parent wrapper, keeping the inner element.

```javascript
$('p').unwrap();
```

---

### **Quick reference table**

| Method           | Where it acts    | Description                                |
| ---------------- | ---------------- | ------------------------------------------ |
| `.before()`      | outside, before  | Insert before element                      |
| `.after()`       | outside, after   | Insert after element                       |
| `.prepend()`     | inside, at start | Insert at beginning of element             |
| `.append()`      | inside, at end   | Insert at end of element                   |
| `.replaceWith()` | replaces element | Replace element itself                     |
| `.remove()`      | element itself   | Remove element                             |
| `.empty()`       | children         | Remove all children                        |
| `.clone()`       | element itself   | Copy element (can include children/events) |
| `.wrap()`        | element itself   | Wrap element in new HTML                   |
| `.unwrap()`      | parent wrapper   | Remove parent wrapper                      |

---

💡 **Tip:**

* Think of it as **“where you want to insert/remove content”** — inside vs outside, before vs after, element itself vs children.

---

If you want, I can make a **visual diagram showing `.before()`, `.after()`, `.prepend()`, `.append()` on a single element** — it really helps to remember the difference quickly. Do you want me to do that?
