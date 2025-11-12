@echo off
title Stop MySQL Portable
cd /d "%~dp0mysql-portable\bin"
echo [INFO] Zatrzymywanie serwera MySQL...
mysqladmin -u root -pzaq1@WSX shutdown
echo [OK] Serwer MySQL zatrzymany.
pause