create database db_onlineshop collate utf8mb4_general_ci;

use db_onlineshop;
create table articles(
	article_id int unsigned not null auto_increment,
	firstname varchar(200) not null,
    lastname varchar(200) not null,
    articlename varchar(200) not null,
    reason varchar(200),
    
    constraint articleid_PK primary key(article_id)

)engine=InnoDb;
select * from articles;
drop table articles;
insert into articles values(null,"Haze Laptop",599.90,"Guade Wiesn","2019-12-20",1)

