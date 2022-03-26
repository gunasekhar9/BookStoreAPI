create procedure AddUser

(
@FullName varchar(200),
@EmailId varchar(50),
@Password varchar(50),
@MobileNumber varchar(50)
)

as
begin try
     insert into UserSignup values ( @FullName, @EmailId, @Password, @MobileNumber)	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch

create procedure UserLogin

(
@EmailId varchar(50),
@Password varchar(50)
)

as
begin try
     select * from UserSignup where (EmailId = @EmailId and Password = @Password)
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch

alter procedure ForgotPassword

(
@EmailId varchar(50)
)

as
begin try
     update UserSignup set Password=null where EmailId=@EmailId
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


create procedure ResetPassword

(
@EmailId varchar(50),
@Password varchar(50)
)

as
begin try
     update UserSignup set Password=@Password where EmailId=@EmailId
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch



select * from UserSignup