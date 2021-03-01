select * from eav.ObjectEntityType
select * from eav.AttributeName
select * from eav.DataType

--

select * from eav.ObjectEntity
select * from eav.ObjectValue
------------------------------------

--create tet table
/*
insert into eav.ObjectEntityType (Name, Author) values ('Test', NewId())
insert into eav.AttributeName (Name, DataTypeId, ObjectTypeId, Author) values ('Id', 8, 1, NewId())
insert into eav.AttributeName (Name, DataTypeId, ObjectTypeId, Author) values ('Name', 13, 1, NewId())

--insert one row
insert into eav.ObjectEntity (ObjectTypeId, Author) values (1, NewId())
insert into eav.ObjectValue (ObjectEntityId, AttributeNameId, Value, Author) values (1, 1, '100500', NewId())
insert into eav.ObjectValue (ObjectEntityId, AttributeNameId, Value, Author) values (1, 2, 'Тестовая строка с id=100500', NewId())
*/

/*drop table eav.ObjectValue
drop table eav.ObjectEntity
drop table eav.AttributeName
drop table eav.ObjectEntityType
drop table eav.DataType
drop table boo.BigObject
drop table dbo.__EFMigrationsHistory
*/

-------------------------------
declare @tableName nvarchar(256) = 'Test';
declare @ondate nvarchar(128) = getdate();

declare @objectType int = (select id from eav.ObjectEntityType where name = @tableName and StartDate <= @ondate and IsDeleted = 0);
select id, name, 
(select Kind from eav.DataType where id = DataTypeId ) as datakind,
(select name from eav.DataType where id = DataTypeId ) as typename
from eav.AttributeName where objectTypeId = @objectType and StartDate <= @ondate and IsDeleted = 0;

select oe.id, oe.Guid, oe.ObjectTypeId from eav.ObjectEntity oe
where oe.ObjectTypeId = @objectType and oe.StartDate <= @ondate and oe.IsDeleted = 0

select oe.id, ov.Id as objectValueId, ov.AttributeNameId, ov.Value
from eav.ObjectEntity oe
inner join eav.ObjectValue ov on ov.ObjectEntityId = oe.Id
where oe.ObjectTypeId = @objectType and oe.StartDate <= @ondate and oe.IsDeleted = 0
---------------------------------------

select * from eav.ObjectEntity
select * from eav.ObjectValue