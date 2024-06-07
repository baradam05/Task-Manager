# Task Manager
Jedná se o ukázkový projekt. V programu lze nastavit úkoly uživatelům a poté úkol označit za splněný či ho smazat.
Aplikace je napsaná v C# .NET 8 ASP MVC a využívá prvky Blazor frameworku, na design stránky se využil Bootstrap.
## Složky
`wwwroot\js\` - JavaScript soubory\n
`Models\Context\` - třídy pro ukládání dat
`Models\DbModel` - modelové třídy pro databázi
`Models\Dto` - data transfer třídy
## Využití databáze
Výchozí nastavení ukládá data lokálně do .txt souboru, který se při spuštění vytvoří v dokumentech. Pokud chcete pracovat s vlastní databází, musíte vytvořit tabulky pomocí skriptu `TMtables.sql` a využívat mySQL.

Součástí repository je také testovací soubor `Data.txt`, kde jsou připravená data.
Přihlašovací údaje k uživatelům v testovacím souboru jsou:
1. Uživatelské jméno: *Josef1* Heslo: *Silneheslo*   
2. Uživatelské jméno: *Jan2* Heslo: *Bezpecneheslo*
