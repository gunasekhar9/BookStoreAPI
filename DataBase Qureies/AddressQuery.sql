create table AddressType(TypeId int not null Identity(1,1) primary key, Type varchar(50));

insert into AddressType (Type) Values ('Home')
insert into AddressType (Type) Values ('Work')
insert into AddressType (Type) Values ('Other')

Select * From AddressType

create Table Address(AddressId int not null Identity(1,1) Primary key, id int not null FOREIGN KEY (id) REFERENCES UserSignup(id), Address varchar(900), City varchar(90), State varchar(90), TypeId int FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId));

Select * From Address
Select * From UserSignup
Select * From BookTable

create procedure AddAddress
(
  @id int,
  @Address varchar(900),
  @City varchar(90),
  @State varchar(90),
  @TypeId int
)
 as
begin try
	if(Exists(select * from UserSignup where id=@id))
	begin
		insert into Address(id,Address,City,State,TypeId) values (@id,@Address,@City,@State,@TypeId)
	end
	else
	begin
		select 1
	end
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create procedure UpdateAddress
( 
  @AddressId int,
  @Address varchar(900),
  @City varchar(90),
  @State varchar(90),
  @TypeId int
)
as
begin try
	if(Exists(select * from Address where AddressId=@AddressId))
	begin
		update Address set Address=@Address,City=@City,State=@State,TypeId=@TypeId where AddressId=@AddressId
	end
	else
	begin
		select 1
	end
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create procedure GetAddressById
(
 @id int
)
as
begin try
	if(Exists(select * from Address where id=@id))
	begin
		select * from Address where id=@id
	end
	else
	begin
		select 1
	end
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create procedure GetAllAddress
as
begin try
	select * from Address
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create procedure DeleteAddress
(
 @AddressId int
)
as
begin try
	delete from Address where AddressId=@AddressId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch