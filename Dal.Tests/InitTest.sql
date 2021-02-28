select * from eav.ObjectEntityType
select * from eav.AttributeName
select * from eav.DataType

--

select * from eav.ObjectEntity
select * from eav.ObjectValue
------------------------------------

--create tet table
insert into eav.ObjectEntityType (Name, Author) values ('Test', NewId())
insert into eav.AttributeName (Name, DataTypeId, ObjectTypeId, Author) values ('Id', 8, 1, NewId())
insert into eav.AttributeName (Name, DataTypeId, ObjectTypeId, Author) values ('Name', 13, 1, NewId())

--insert one row
insert into eav.ObjectEntity (ObjectTypeId, Author) values (1, NewId())
insert into eav.ObjectValue (ObjectEntityId, AttributeNameId, Value, Author) values (1, 1, '100500', NewId())
insert into eav.ObjectValue (ObjectEntityId, AttributeNameId, Value, Author) values (1, 2, 'Тестовая строка с id=100500', NewId())

/*drop table eav.ObjectValue
drop table eav.ObjectEntity
drop table eav.AttributeName
drop table eav.ObjectEntityType
drop table eav.DataType
drop table boo.BigObject
drop table dbo.__EFMigrationsHistory
*/