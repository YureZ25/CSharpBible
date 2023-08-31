use [master]; -- используем главную таблицу MS SQL

if exists (select * from master.sys.databases where name = 'adonet-testdb') -- запрос к системным таблицам
begin
	print 'База данных с названием adonet-testdb уже существует' -- вывод в консоль
	return -- Выход из скрипта
end

create database [adonet-testdb]; -- указать имя из переменной не получится
go -- нужно выполнить создание, чтобы последующие команды было где исполнять

use [adonet-testdb]; -- переключаемся на созданную, чтобы не указывать ее во всех запросах

-- Запрос к унифицированным (у разных баз данных) системным таблицам
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'adonet-testdb' and TABLE_NAME = 'Cities')
begin
	print 'Таблица с назнванием Cities уже существует в базе данных adonet-testdb' 
	return
end

create table Cities
(
	CityId int identity(1,1) primary key, -- для авто инкремента используется модификатор identity (начальное значение, дельта)
	CityName nvarchar(128) -- строка с длиной до 128
);

-- Для предотвращения insert одинаковых данных несколько раз
merge Cities as target
using (values
('Toronto'),
('Vancouver'),
('Montreal'),
('Ottawa'),
('Madrid'),
('Moskow'),
('Donetsk'),
('Taganrog')) as source(Name)
on target.CityName = source.Name -- условие совпадения
when not matched 
then insert (CityName) values (source.Name); -- если не совпало - вставляем данные
