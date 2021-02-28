select * from eav.ObjectEntityType
select * from eav.AttributeName
select * from eav.DataType

--

select * from eav.ObjectEntity
select * from eav.ObjectValue
------------------------------------

insert into eav.ObjectEntityType (Name, Author, StartDate) values ('Test', NewId(), getdate())