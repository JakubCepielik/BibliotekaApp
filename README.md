# System zarządzania biblioteką
System Zarządzania Biblioteką to aplikacja, która umożliwia efektywne zarządzanie zasobami bibliotecznymi, ułatwiając bibliotekarzom i użytkownikom korzystanie z różnorodnych funkcji.
## Technologie
- MVC
- MSSql
- Entity Framework
- Bootstrap
## Schemat projektu
Projekt składa się z następujących tabel:
- Książki
- Autor
- Wydawnictwo
- Czytelnik
- Adres
## Relacje
- Książka - Czytelnik -> wiele do wielu
- Autor - Książka -> 1 do wielu
- Wydawnictwo - Książka -> 1 do 1
- Adres - Czytelnik -> 1 do 1

### Uruchomienie projektu
1. Projekt należy pobrać i rozpakować.
2. Uruchomić plik BibliotekaApp.sln
3. W Solution Explorer uruchomić appsettings.json i w ConnectionStrings wprowadzić nazwę serwera
4. Przejść do Tools -> NuGet Package Menager -> Package Menager Conosole
5. Wykonać migrację przy pomocy Add-Migration "NazwaMigracji" a następnie Update-Database
6. Uruchomić program

