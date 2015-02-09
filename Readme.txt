Запуск сервиса:
<<<<<<< HEAD:Readme.txt
- Создать БД с именем Beepak
- Выполнить скрипт в MS Sql Management Studio 2012 из скрипта, находящегося в src\Beepak.Data\BeepakModel.edmx.sql;
=======
- Создать БД с именем 'Beepak'
- Развернуть БД (выполнив скрипт в MS Sql Management Studio 2012) из скрипта, находящегося в src\Beepak.Data\BeepakModel.edmx.sql;
>>>>>>> 84e5895c6d1af555e081005a1e3119181c21277f:Readme.txt
-- Параметры БД:
--- Имя сервера: localhost\mssqlserver_12
- Запустить приложение-сервис с правами администратора из lib\Service\Beepak.ServiceHost.exe.

Функции сервиса:
- Register:
-- http://localhost:8000/Register?login=l&password=p&passwordRpt=p&mail=m&city=c

- Logon:
-- http://localhost:8000/Logon?login=l&password=p
