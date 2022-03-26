create table BookTable (BookId int identity (1,1) primary key, BookName varchar(50) not null, AuthorName varchar(50) not null, DiscountPrice int not null, OriginalPrice int not null, Description varchar(500), Rating float, Image varchar(200), ReviewCount int not null, BookCount int not null)


select * from BookTable