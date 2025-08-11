create table departments (
id int identity(1,1) primary key,
[name] nvarchar(50) not null
)

create table employee(
id int identity(1,1) primary key,
[name] nvarchar(50) not null,
deptId int not null
foreign key (deptId) references departments(id)
)


insert into departments values ('HR'),('Admin'),('Staff')

insert into employee values ('Mohan',1), ('Rahul',2) , ('Rekha',3)

insert into departments values ('Finance')
select * from employee

select * from departments

select employee.id, employee.name, departments.name from employee 
inner join departments on employee.deptId=departments.id