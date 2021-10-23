--// ADMINISTRADOR //--
create table administrador(
id_admin varchar(20) not null,
pass varchar(20) not null,
nombre varchar(20) not null,
apellido varchar(20) not null,
primary key(id_admin))
insert into administrador(id_admin,pass,nombre,apellido)
values ('1044930444','0395Mateo','Mateo','Delgado')

--// USUARIO //--

create table usuarios(
id_user varchar(20) not null,
pass varchar(20) not null,
nombre varchar(20) not null,
apellido varchar(20) not null,
id_admin varchar(20) not null,
primary key(id_user),
foreign key (id_admin) references administrador
)
insert into usuarios(id_user,pass,nombre,apellido,id_admin)
values ('73555213','Mateo0395','Nafer','Delgado','1044930444')

--// CATEGORIAS //--

create table categorias(
id_categorias int not null,
nombre_categorias varchar (20) not null,
id_admin varchar(20) not null,
primary key (id_categorias),
foreign key (id_admin) references administrador
) 

----/// PRODUCTOS ///----

create table productos(
id_productos int not null,
id_categoria int not null,
nombre_productos varchar (20) not null,
precio_productos float not null,
primary key (id_productos),
foreign key (id_categoria) references categorias
)
----/// tabla de usuario y productos ///---
create table usuario_productos
(
id_user varchar(20) not null,
id_productos int not null,
foreign key (id_user) references usuarios,
foreign key (id_productos) references productos
)
select * from administrador
select * from usuarios
select * from categorias
select * from productos
select * from usuario_productos

insert into categorias (id_categorias,nombre_categorias,id_admin)
values (1012,'frutas','1044930444'),(1013,'carnes','1044930444'),(1011,'lacteos','1044930444')


insert into productos(id_productos, id_categoria, nombre_productos, precio_productos)
values (1101,1011,'leche',2400),(1102,1011,'suero',1200),(1103,1011,'queso',17000)
insert into productos(id_productos, id_categoria, nombre_productos, precio_productos)
values(1201,1012,'mango',5000),(1202,1012,'papaya',3500),(1203,1012,'uva',7600)
insert into productos(id_productos, id_categoria, nombre_productos, precio_productos)
values(1301,1013,'res',8500),(1302,1013,'pollo',6700),(1303,1013,'cerdo',12000)