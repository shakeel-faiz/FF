Okay, let's explore the common event types and their inheritance hierarchy, starting from the base `Event` interface. This will show you how more specific event objects build upon the foundational `Event` properties and methods.

This hierarchy is part of the Web IDL (Interface Definition Language) specifications, primarily by the W3C.

---

### The Base: `Event` Interface

Every event object ultimately inherits from `Event`. It provides the most fundamental properties and methods:

* **Properties:** `type`, `target`, `currentTarget`, `eventPhase`, `bubbles`, `cancelable`, `defaultPrevented`, `isTrusted`, `timeStamp`
* **Methods:** `preventDefault()`, `stopPropagation()`, `stopImmediatePropagation()`

---

### First Level of Inheritance: `UIEvent`

Many common user interaction events inherit directly from `Event` or (more commonly) from `UIEvent`, which itself inherits from `Event`. `UIEvent` adds properties relevant to user interface interactions.

**`UIEvent`** (inherits from `Event`)
* **Added Properties:**
    * `view`: A reference to the `window` object where the event occurred.
    * `detail`: An integer providing generic event details (e.g., click count for `MouseEvent`).

---

### Common Event Hierarchies:

Now let's trace the paths for the most frequently used event types:

#### 1. Mouse Events and Pointer Events

This is a key hierarchy for all pointer-based interactions (mouse, touch, pen).

* **`MouseEvent`** (inherits from `UIEvent`)
    * **Added Properties:** `altKey`, `ctrlKey`, `metaKey`, `shiftKey` (modifier keys), `button`, `buttons` (mouse button state), `clientX`, `clientY`, `pageX`, `pageY`, `screenX`, `screenY` (coordinates), `relatedTarget` (for `mouseover`/`mouseout`).
    * **Common Events:**
        * `click`
        * `dblclick`
        * `mousedown`
        * `mouseup`
        * `mousemove`
        * `mouseover`
        * `mouseout`
        * `mouseenter`
        * `mouseleave`
        * `contextmenu`
        * `wheel` (Note: `WheelEvent` itself inherits from `MouseEvent` and adds `deltaX`, `deltaY`, `deltaZ`, `deltaMode`).

* **`PointerEvent`** (inherits from `MouseEvent`)
    * This is a more modern API that aims to unify different input types (mouse, touch, pen) into a single event model. It extends `MouseEvent` with properties specific to any pointer.
    * **Added Properties:** `pointerId`, `width`, `height`, `pressure`, `tangentialPressure`, `tiltX`, `tiltY`, `twist`, `pointerType` (e.g., `'mouse'`, `'pen'`, `'touch'`), `isPrimary`.
    * **Common Events:**
        * `pointerdown`
        * `pointerup`
        * `pointermove`
        * `pointerover`
        * `pointerout`
        * `pointerenter`
        * `pointerleave`
        * `gotpointercapture`
        * `lostpointercapture`

#### 2. Keyboard Events

* **`KeyboardEvent`** (inherits from `UIEvent`)
    * **Added Properties:** `key` (value of the key, e.g., `'a'`, `'Enter'`), `code` (physical key code, e.g., `'KeyA'`, `'NumpadEnter'`), `location`, `altKey`, `ctrlKey`, `metaKey`, `shiftKey` (modifier keys), `repeat` (if key is being held down), `isComposing`.
    * **Common Events:**
        * `keydown`
        * `keyup`
        * `keypress` (deprecated, but still an instance of `KeyboardEvent`)

#### 3. Form Events

These events often occur on form elements or the form itself. Many of these do not inherit from `UIEvent` directly, but rather directly from `Event`.

* **`Event`** (base interface, used directly for some form events)
    * **Common Events:**
        * `submit` (on `<form>`)
        * `reset` (on `<form>`)
        * `change` (on `<input>`, `<select>`, `<textarea>`)
        * `input` (on `<input>`, `<textarea>`)
        * `focus` (on any focusable element)
        * `blur` (on any focusable element)
        * `select` (on text inputs)

* **`FocusEvent`** (inherits from `UIEvent`, provides more detail for focus changes)
    * **Added Properties:** `relatedTarget` (the element that gained/lost focus).
    * **Common Events:**
        * `focusin` (bubbles version of `focus`)
        * `focusout` (bubbles version of `blur`)

#### 4. Touch Events

Specifically for touchscreens, often used in conjunction with or as an alternative to Pointer Events.

* **`TouchEvent`** (inherits from `UIEvent`)
    * **Added Properties:** `touches` (list of `Touch` objects currently on the surface), `targetTouches`, `changedTouches`, `altKey`, `ctrlKey`, `metaKey`, `shiftKey`.
    * **Common Events:**
        * `touchstart`
        * `touchmove`
        * `touchend`
        * `touchcancel`

#### 5. Drag & Drop Events

These events are part of the HTML Drag and Drop API.

* **`DragEvent`** (inherits from `MouseEvent`)
    * **Added Properties:** `dataTransfer` (the `DataTransfer` object used for dragging data).
    * **Common Events:**
        * `dragstart`
        * `drag`
        * `dragend`
        * `dragenter`
        * `dragleave`
        * `dragover`
        * `drop`

---

### Other Notable Event Interfaces:

* **`CustomEvent`** (inherits from `Event`)
    * **Added Property:** `detail` (for passing custom data with your custom event).
    * **Use Case:** Creating and dispatching your own named events with specific data.

* **`ProgressEvent`** (inherits from `Event`)
    * **Added Properties:** `lengthComputable`, `loaded`, `total`.
    * **Use Case:** Used for events like `load`, `error`, `abort`, `loadstart`, `loadend`, `progress` often in `XMLHttpRequest` or `FileReader`.

* **`TransitionEvent`** (inherits from `Event`)
    * **Added Properties:** `propertyName`, `elapsedTime`, `pseudoElement`.
    * **Use Case:** Fired by CSS Transitions.

* **`AnimationEvent`** (inherits from `Event`)
    * **Added Properties:** `animationName`, `elapsedTime`, `pseudoElement`.
    * **Use Case:** Fired by CSS Animations.

This overview covers the most common and important event types and how they fit into the event interface hierarchy. Understanding this structure helps you predict what properties will be available on an event object and how to handle it effectively.
