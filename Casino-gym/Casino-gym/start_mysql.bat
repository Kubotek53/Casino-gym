@echo off
title Start MySQL Portable
echo [INFO] Uruchamianie przenośnego serwera MySQL...

:: Przejdź do katalogu z plikami binarnymi MySQL
cd /d "%~dp0mysql-portable\bin"

:: Uruchom serwer MySQL w tle z określonym plikiem konfiguracyjnym
start "" "%~dp0mysql-portable\bin\mysql.exe" --defaults-file="%~dp0mysql-portable\my.ini" --console

:: Odczekaj kilka sekund, aby MySQL zdążył się uruchomić
timeout /t 5 /nobreak >nul

:: Sprawdź, czy proces mysqld działa
tasklist /fi "imagename eq mysql.exe" | find /i "mysql.exe" >nul
if errorlevel 1 (
    echo [BŁĄD] Nie udało się uruchomić serwera MySQL!
) else (
    echo [OK] Serwer MySQL został uruchomiony pomyślnie.
)

pause
exit
