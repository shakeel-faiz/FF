# Git Rebase aur Branch State Sync karne ke Notes (Roman Urdu)

---

## 1. `rebase abc onto def` ka Matlab

Jab aap kehte hain **"rebase abc onto def"**, toh iska seedha matlab hai:

* **Buniyad (Base):** `def` branch ko buniyad banana hai.
* **Upar Charhne Wali Branch:** `abc` branch ke saare naye commits ko utha kar `def` ke bilkul upar (aakhir mein) lagana hai.

### Yeh Kaise Kaam Karta Hai?
1. Git pehle `def` branch par jata hai.
2. Phir `abc` ke saare commits ko ek-ek karke `def` ke upar apply karta hai.
3. Aakhir mein `abc` branch ki history ek seedhi line (linear) mein aa jati hai aur us mein `def` ka taaza code bhi shaamil ho jata hai.

---

## 2. Purane Commits Mehfooz Rakhte Hue Branch State ko Dusri Branch Jaisa Banana

Agar aapke paas aik branch `XYZ` hai aur aap chahte hain ke:
* `XYZ` ke **purane commits history mein mehfooz (preserve) rahein**.
* Lekin `XYZ` ka **final code (state) bilkul `DFG` branch jaisa** ho jaye.

Is ke liye do (2) behtareen tareeqay hain:

---

### Tareeqa 1: `git checkout` / `git rm` (100% Exact State Sync — Sab se Behtareen)

Agar `XYZ` mein kuch aisi extra files bhi hain jo `DFG` mein nahi thein, toh mukammal sync karne ke liye yeh steps chalayein:

1. **Apni target branch (`XYZ`) par jayein:**
   ```bash
   git checkout XYZ
   ```

2. **`XYZ` ki saari purani tracked files ko staging se hatayein** *(taake extra files bhi saaf ho jayein)*:
   ```bash
   git rm -rf .
   ```

3. **`DFG` branch ka saara code aur files apni branch mein le aayein:**
   ```bash
   git checkout DFG -- .
   ```
   *(Naye Git versions mein aap `git restore --source=DFG .` bhi chala sakte hain)*

4. **In changes ko commit kar dein:**
   ```bash
   git commit -m "Sync XYZ state completely with DFG"
   ```

**Fayda:** Is se `XYZ` ke purane commits mehfooz rehte hain, koi merge conflict nahi aata, aur extra files bhi hat jati hain.

---

### Tareeqa 2: Merge with `ours` Strategy (History mein Merge Link Dikhane ke Liye)

Agar aap Git history mein yeh dikhana chahte hain ke dono branches merge hui hain, lekin code sirf `DFG` ka hi rakhna chahte hain:

1. **`DFG` branch par jayein:**
   ```bash
   git checkout DFG
   ```

2. **`XYZ` ko merge karein aur sirf `DFG` (`ours`) ka code rakhein:**
   ```bash
   git merge -s ours XYZ
   ```

3. **Wapas `XYZ` par jayein aur usay `DFG` ke barabar le aayein:**
   ```bash
   git checkout XYZ
   git merge DFG
   ```

---

## 3. Tasdeeq (Verification) aur Safai ke Commands

Sync karne ke baad in commands se tasalli kar lein:

* **Code ka farq check karne ke liye:**
  ```bash
  git diff DFG
  ```
  *(Agar screen bilkul khaali aaye, toh dono branches ka code 100% ek jaisa hai).*

* **Status check karne ke liye:**
  ```bash
  git status
  ```
