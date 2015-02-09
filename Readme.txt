Запуск сервиса:
- Создать БД с именем Beepak
- Выполнить скрипт в MS Sql Management Studio 2012 из скрипта, находящегося в src\Beepak.Data\BeepakModel.edmx.sql;
-- Параметры БД:
--- Имя сервера: localhost\mssqlserver_12
--- Имя БД: Beepak
- Запустить приложение-сервис с правами администратора из lib\Service\Beepak.ServiceHost.exe.

Проверка сервиса:
- Добавить пользователя через браузер.
Пример:
http://localhost:8000/Register?login=l&password=p&passwordRpt=p&mail=m&city=c
В результате в браузере должна отобразится страница с параметрами добавленного пользователя.