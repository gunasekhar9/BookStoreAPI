create database BookStore;
use BookStore

create table UserSignup(id int not null identity(1,1) primary key,
  FullName varchar(50), EmailId varchar(50),
  Password varchar(50), MobileNumber varchar(50))

Select * from UserSignup;