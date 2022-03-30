create table Feedback(FeedbackId int identity (1,1) primary key, id int foreign key (id) references UserSignup(id), BookId int foreign key (BookId) references BookTable(BookId), Comments varchar(900) not null, OverallRating int null)

create procedure AddFeedback
(
 @id int,
 @BookId int,
 @Comments varchar(900),
 @OverallRating int
)
as
	declare @AverageRating int
begin try
	if(Exists(select * from Feedback where BookId=@BookId and id=@id))
	begin
		select 1
	end
	else
	begin
		if(Exists(select * from BookTable where BookId=@BookId))
		begin
			begin try
				begin transaction
					insert into Feedback (id,BookId,Comments,OverallRating) values (@id,@BookId,@Comments,@OverallRating)
					select @AverageRating=avg(@OverallRating) from Feedback where BookId=@BookId
					update BookTable set Rating=@AverageRating,ReviewCount=ReviewCount+1 where BookId=@BookId
				commit transaction
			end try
			begin catch
				rollback transaction
			end catch
		end
		else
		begin
			select 2
		end
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

create procedure GetFeedback
(
 @BookId int
)
as
begin try
	select Feedback.FeedbackId,Feedback.id,Feedback.BookId,Feedback.Comments,Feedback.OverallRating,UserSignup.FullName,UserSignup.EmailId from UserSignup inner join Feedback on Feedback.id = UserSignup.id where BookId=@BookId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

Select * from Feedback
select * from BookTable
select * from Orders
select * from CartTable
select * from Address
select * from UserSignup