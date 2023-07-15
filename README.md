# ExclusiveCarsW&W
Blog o samochodach. Można dodawać posty, usuwać, modyfikować w zależności od roli jaką daną użytkownik posiada. Pełna lista endpointów znajduje się na swaggerze

Napisana jest również aplikacja frontendowa https://github.com/wsei-projects/ExclusiveCarsWAndW.Front

## Uruchomienie projektu
- Pobrać repozytorium,
- Utworzyć bazę danych w SQL Server Managment Studio,
- W projekcie CarsAPI w pliku appsettings.json dla "ApplicationDBContextConnection" ustawić odpowiednie dane (dane do bazy danej, którą przed chwilą stworzyliśmy),
- Przed pierwszym urochmieniem odpalić migrację wchodząc w "Nuget Package Manager" i wykonująć komendę ```Update-Database```
- Uruchomić projekt Visual Studio (F5) wybierając https od Visual Studio 2022 (ctrl + F5)

## Wbudowani użytkownicy
- Email: user@test.com | Hasło: user123! | Rola: User
- Email: admin@test.com | Hasło: admin123! | Rola: Admin

Aplikacja posiada dwie role dla użytkownika User oraz Admin

## Wykonali
- Wiktor Rogóż,
- Patryk Skwarczyński,
- Wojciech Skirło 14001
