@echo off
title Import bazy danych
cd /d "%~dp0mysql-portable\bin"
echo [INFO] Importowanie bazy casino_gym.sql...
mysql -u root -pzaq1@WSX -e "CREATE DATABASE IF NOT EXISTS casino_gym;"
mysql -u root -pzaq1@WSX casino_gym < "%~dp0Database\casino_gym.sql"
echo [OK] Import zakończony pomyślnie.
pause