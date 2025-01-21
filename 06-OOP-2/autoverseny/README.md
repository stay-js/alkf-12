# Autóverseny

Ez a dokumentáció a `Autóverseny` nevű programhoz készült, amely egy autóverseny szimulációját valósítja meg. A program lehetővé teszi a versenyzők különböző stratégiáinak és a verseny dinamikájának szimulációját. A következőkben részletesen bemutatom a program működését, felépítését, és a szimuláció szabályait.

## **Program Funkcionalitása**

- A program szövegfájl alapján betölti a verseny adatokat: körök száma, versenyzők száma, versenyzők neve és kategóriája.
- A szimuláció során minden körben:
  - Frissül a versenyzők sorrendje.
  - A versenyzők benzinszintje csökken a megtett körök és előzési kísérletek miatt.
  - Ha egy versenyző benzinszintje alacsony, tankolni áll ki, amiért időbe telik, emiatt versenypozíciót veszít.
  - Előzési kísérletek során balesetek történhetnek, amelyek versenyzők kiesését eredményezik.
- A verseny végén a program kiírja a versenyzők sorrendjét, az első három helyezettet, valamint a kiesett versenyzők nevét.

## **A szimuláció szabályai**

### **Versenyzők kategóriái**

A versenyzők vezetési stílusuk alapján négy kategóriába tartozhatnak:

1. **Agresszív**

   - Minden második körben előzni próbál.
   - Csak minden harmadik előzése sikeres.
   - Tankolni hajt ki, ha a benzinszintje 10 alá esik.

2. **Lendületes**

   - Minden ötödik körben előzni próbál.
   - Csak minden második előzése sikeres.
   - Tankolni hajt ki, ha a benzinszintje 20 alá esik.

3. **Veszélyes**

   - Minden negyedik körben előzni próbál.
   - Csak minden negyedik előzése sikeres.
   - Tankolni hajt ki, ha a benzinszintje 5 alá esik.
   - Előzései során kétszer akkora az esélye balesetek előidézésére.

4. **Óvatos**
   - Nem próbál előzni.
   - Tankolni hajt ki, ha a benzinszintje 20 alá esik.

### **Előzés és balesetek**

- Egy előzési kísérlet üzemanyagköltsége 4 egység.
- Előzési balesetek esélyei (normál versenyző):
  - 4%: a támadó kiesik.
  - 4%: mindkét versenyző kiesik.
  - 2%: tömegkarambol (négy versenyző esik ki).
- **Veszélyes versenyzők** esetén a baleseti esélyek kétszeresére nőnek.

### **Tankolás**

- Ha egy versenyző tankolni hajt ki:
  - Üzemanyagszintje visszaáll 100-ra.
  - 5 helyezéssel hátrébb kerül a sorrendben.

## **Bemeneti Fájl Formátuma**

A program egy szövegfájlból olvassa be a verseny adatait. A fájl formátuma a következő:

1. Első sor: `körök száma versenyzők száma` (pl. `10;5`).
2. További sorok: `név;kategória` (pl. `Kiss Péter;1`).

### Példa bemeneti fájl

```txt
10;4
Kiss Péter;1
Nagy Anna;2
Tóth Gábor;3
Horváth Eszter;4
```

## **Kimenet**

### Körönkénti kimenet:

- Körben történt események (tankolás, előzés, baleset).
- Aktuális sorrend.
- Kiesett versenyzők listája.

### Verseny végi kimenet:

- A teljes verseny végeredménye (végső sorrend).
- A kiesett versenyzők nevei.
- Az első három helyezett.

## **Program Főbb Osztályai**

### Race osztály

- Tárolja a verseny adatait (körök száma, versenyzők, sorrend).
- Kezeli a versenyzők mozgását és a körök állapotát.
- Naplózza az eseményeket.

### Driver osztály

- Egy adott versenyző adatait és viselkedését reprezentálja.
- Tartalmazza a tankolás, előzés és balesetek kezelését.
- Négy kategóriában (agresszív, lendületes, veszélyes, óvatos) eltérő logika szerint működik.

### DriverType enum

- A versenyzők kategóriáinak típusait definiálja.

### InvalidDriverTypeException osztály

- Hibakezelés, ha egy érvénytelen versenyzőtípust tartalmaz a bemeneti fájl.

## **Használat**

- Készítsen egy szövegfájlt a fent megadott formátumban a verseny adataival.
- Futtassa a programot, és adja meg a fájl nevét, amikor a program kéri.
- Nyomjon egy billentyűt minden kör végén, hogy megjelenjen a következő kör eredménye.
- A verseny végén a program megjeleníti a végeredményt.

### Fordítás és Futtatás

A program .NET környezetben készült, fordításhoz és futtatáshoz használja a dotnet run parancsot.

```txt
dotnet run
```
