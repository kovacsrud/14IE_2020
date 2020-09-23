# Objektum-orientált programozás (OOP)

A számítógépek teljesítményének növekedésével, és a programok bonyolultabbá válásával a szoftver ipar
és a programozás eljutott arra a pontra, amikor a felmerülő problémák már nem voltak megoldhatóak a hagyományos eszközökkel. 
Az OOP jelentett kiutat ebből a szoftver krízisnek nevezett állapotból.

Alapegysége az objektum.

Az objektumnak vannak adatai (változók).
Az objektumnak vannak metódusai (függvények, melyeket kérésre az objektum végrehajt)

Állat
*************************
* fajta                 *
* szín                  *
*************************
*eszik()                *
*                       *
*mozog()                *
*                       *
*alszik()               *
*                       *
*                       *
*                       *      
*                       * 
*                       *
*                       *  
*************************

Az objektum deklarációja az osztály (class). Az osztályból a program futtatásakor példányt készítünk, a programban a példányt használjuk.

Az osztály működésének alapelve, hogy az osztály a külvilág elől elrejti a "belügyeit". Ez az ún. bezártság elve.
A bezártság elve azt jelenti, hogy az osztály adatait nem lehet közvetlenül elérni, hanem csakis metódusokon keresztül. Másképpen fogalmazva az osztályt csak az interfészén keresztül lehet elérni.
