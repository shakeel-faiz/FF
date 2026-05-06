```
#Requires AutoHotkey v2.0

*f4:: {
    static isShiftDown := false
    
    if !isShiftDown {
        Send("{Shift Down}")
        isShiftDown := true
        ToolTip("SHIFT ON", 10, 10, 1) ; Tooltip #1 at top left
    } else {
        Send("{Shift Up}")
        isShiftDown := false
        ToolTip("", , , 1) ; Clears Tooltip #1
    }
}

*f7:: {
    static isCtrlDown := false
    
    if !isCtrlDown {
        Send("{Ctrl Down}")
        isCtrlDown := true
        ToolTip("CTRL ON", 10, 40, 2) ; Tooltip #2 slightly below the first
    } else {
        Send("{Ctrl Up}")
        isCtrlDown := false
        ToolTip("", , , 2) ; Clears Tooltip #2
    }
}

; Optional: Keep your F9 Suspend from before
#SuspendExempt
~f9:: {
    Send("{Shift Up}{Ctrl Up}")
    ToolTip("", , , 1)
    ToolTip("", , , 2)
    
    Suspend(-1) ; Toggles suspend
    
    if A_IsSuspended {
        ToolTip("SCRIPT SUSPENDED", 10, 70, 3)
    } else {
        ToolTip("SCRIPT ACTIVE", 10, 70, 3)
        SetTimer () => ToolTip(,,,3), -2000 ; Auto-hide "Active" notice after 2 seconds
    }
}
#SuspendExempt False

```

## For Drag and Drop
using ctrl+insert and ctrl+delete

```
#Requires AutoHotkey v2.0

; Press Insert to lock the left mouse click down (Drag)
^Insert::Click "Down"

; Press Delete to release the left mouse click (Drop)
^Delete::Click "Up"
```
