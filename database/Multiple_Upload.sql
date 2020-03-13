use master
create database Demo_Multiple_Images
use Demo_Multiple_Images
create table Product
(
	id int identity primary key,
	name varchar(200),
	price money,
	images varchar(200),
)
create table Sub_Images
(
	id int identity primary key,
	url_images varchar(200),
	product_id int,
)
Alter table Sub_Images Add Constraint FK_Product_Sub_Images Foreign Key (product_id) References Product (id)
select * from Product
select * from Sub_Images