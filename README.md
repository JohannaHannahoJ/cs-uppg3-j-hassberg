# Gästbok – Uppgift 3

Detta projekt är en enkel konsolapplikation i **C#** som fungerar som en gästbok. Användaren kan skriva inlägg, visa tidigare inlägg och ta bort inlägg.
Inläggen sparas i en JSON-fil så att de finns kvar när programmet startas igen.

---

## Förutsättningar

Innan du kör igång behöver du ha följande installerat på datorn:

1. **.NET SDK**
2. En editor, exempelvis **Visual Studio Code** eller **Visual Studio**

---

## Kom igång

### 1. Klona repot och navigera in i mappen

```bash
git clone <URL-TILL-DITT-REPO>
cd <PROJEKT-MAPP>
```

### 2. Kör programmet

Kör följande kommando i terminalen:

```bash
dotnet run
```

---

## Så fungerar programmet

När programmet startar visas en meny där användaren kan välja mellan olika alternativ.

### Skriva ett inlägg

Användaren får ange:

* Namn
* Inlägg

Båda fälten måste innehålla något. Tomma fält godkänns inte.

### Ta bort ett inlägg

Varje inlägg visas med ett indexnummer, exempelvis:

```text
[0] Johanna skrev: Hej!
[1] Kalle skrev: Trevligt att vara här!
```

Användaren kan ange indexnumret för det inlägg som ska tas bort.

### Spara inlägg

Inläggen sparas i filen:

```text
guestbook.json
```

När programmet startas läses tidigare sparade inlägg från filen. När ett inlägg läggs till eller tas bort sparas listan på nytt.

---

## Projektets klasser

Projektet innehåller bland annat två klasser:

### `GuestbookEntry`

Representerar ett enskilt inlägg och innehåller:

* `UserName`
* `Entry`

### `Guestbook`

Ansvarar för att hantera gästbokens inlägg, bland annat genom att:

* Ladda in sparade inlägg
* Lägga till inlägg
* Ta bort inlägg
* Hämta alla inlägg
* Spara inlägg till JSON-filen

`Program` hanterar själva konsolmenyn och kommunikationen med användaren.

---
