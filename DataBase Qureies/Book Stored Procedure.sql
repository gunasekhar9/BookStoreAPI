create Procedure addBookTable 

(
@BookName varchar(50),
 @AuthorName varchar(50),
  @DiscountPrice int,
   @OriginalPrice int,
    @Description varchar(500),
	 @Rating float,
	  @Image varchar(200), 
	   @ReviewCount int, 
	    @BookCount int
)

as
begin try
     insert into BookTable values (@BookName, @AuthorName, @DiscountPrice, @OriginalPrice, @Description, @Rating, @Image, @ReviewCount, @BookCount)	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


create procedure GetAllBooks


as
begin try
select * from BookTable

end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch

create procedure GetBook


as
begin try
select * from BookTable

end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch

create procedure updateBook

(@BookId int,
@BookName varchar(50),
 @AuthorName varchar(50),
  @DiscountPrice int,
   @OriginalPrice int,
    @Description varchar(500),
	 @Rating float,
	  @Image varchar(200), 
	   @ReviewCount int, 
	    @BookCount int
)

as
begin try
     update BookTable set BookName=@BookName, AuthorName=@AuthorName, DiscountPrice=@DiscountPrice, OriginalPrice=@OriginalPrice, Description=@Description, Rating=@Rating, Image=@Image, ReviewCount=@ReviewCount,BookCount=@BookCount where BookId = @BookId
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


create procedure deleteBook
 
(
@BookId int
)

as
begin try
     delete from BookTable where  BookId=@BookId	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


select * from UserSignUp


select * from BookTable
