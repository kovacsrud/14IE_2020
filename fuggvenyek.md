# Függvények (alprogramok)

A legegyszerűbb függvény:
```C#
static void Kiir()
        {
            Console.WriteLine("Hello");
        }
```        
A függvényt nem elég létrehozni, a főprogramban meg is kell hívni, ha végre akarjuk hajtani a függvényben lévő utasításokat.
```C#
Kiir();
```
Paraméteres függvény: a függvénynek adható egy érték, amit a függvény tevékenységei majd felhasználnak.

```C#
static void MasikKiir(string szoveg)
        {            
            Console.WriteLine(szoveg);
        }
```

Hívása:

```C#
MasikKiir("Valami");
```
