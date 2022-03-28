create table WishList(wishListId int primary key identity(1,1),id int Foreign Key References UserSignup(id),
BookId int Foreign Key References Booktable(BookId))

create procedure AddBookToWishlist
(
 @id int,
 @BookId int
)
as
begin try
	if(Exists(select * from BookTable where BookId=@BookId))
	begin
		insert into Wishlist(id,BookId) values (@id,@BookId)
	end
	else
	begin
		select 2
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


create procedure DeleteWishlist
(
 @WishlistId int
)
as
begin try
	delete from Wishlist where WishlistId=@WishlistId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create procedure GetWishlist
@id int
As
Begin
select WishList.WishListId, WishList.id, WishList.BookId, BookTable.BookName, BookTable.AuthorName,
BookTable.Description, BookTable.DiscountPrice, BookTable.OriginalPrice, BookTable.Rating, BookTable.ReviewCount,
BookTable.Image, BookTable.BookCount from WishList inner join BookTable on WishList.BookId=BookTable.BookId
where WishList.id=@id
End


select * from WishList 
select * from UserSignup
select * from BookTable

