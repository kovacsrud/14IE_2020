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
Ugyanazzal a névvel több függvényt is készíthetünk. Ezt overloading-nak, más néven függvény túlterhelésnek nevezik. Az
egyes függvényeknek a neve ilyenkor megegyezik, de a paraméterlistájuk eltérő kell hogy legyen.

```C#
static void Kiir()
        {
            Console.WriteLine("Hello");
        }

static void Kiir(string szoveg)
        {            
            Console.WriteLine(szoveg);
        }

static void Kiir(string szoveg,int hanyszor)
        {
            for (int i = 0; i < hanyszor; i++)
            {
                Console.WriteLine(szoveg);
            }
        }
```

A visszatérési értékkel rendelkező függvény valamilyen értéket szolgáltat. Önmagában nem használható, csak függvényhívás vagy értékadás részeként. Itt is lehet túlterhelést alkalmazni, a paraméterlisták megegyezhetnek, de a visszatérési értéknek különböznie kell.

```C#
 static int Osszead(int a,int b)
        {
            return a + b;
        }

static double Osszead(double a,double b)
        {
            return a + b;
        }
```

