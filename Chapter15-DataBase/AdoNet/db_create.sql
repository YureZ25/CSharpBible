use [master]; -- ���������� ������� ������� MS SQL

if exists (select * from master.sys.databases where name = 'adonet-testdb') -- ������ � ��������� ��������
begin
	print '���� ������ � ��������� adonet-testdb ��� ����������' -- ����� � �������
	return -- ����� �� �������
end

create database [adonet-testdb]; -- ������� ��� �� ���������� �� ���������
go -- ����� ��������� ��������, ����� ����������� ������� ���� ��� ���������

use [adonet-testdb]; -- ������������� �� ���������, ����� �� ��������� �� �� ���� ��������

-- ������ � ��������������� (� ������ ��� ������) ��������� ��������
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'adonet-testdb' and TABLE_NAME = 'Cities')
begin
	print '������� � ���������� Cities ��� ���������� � ���� ������ adonet-testdb' 
	return
end

create table Cities
(
	CityId int identity(1,1) primary key, -- ��� ���� ���������� ������������ ����������� identity (��������� ��������, ������)
	CityName nvarchar(128) -- ������ � ������ �� 128
);

-- ��� �������������� insert ���������� ������ ��������� ���
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
on target.CityName = source.Name -- ������� ����������
when not matched 
then insert (CityName) values (source.Name); -- ���� �� ������� - ��������� ������
