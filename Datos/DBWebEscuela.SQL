Use master
go
if exists (select * from Sys.sysdatabases where name = 'DBWebEscuela')
drop database DBWebEscuela
go
create database DBWebEscuela
go
use DBWebEscuela

--CREACION DE TABLA ROLES
create table Roles(
Rol varchar(20) primary key
)
go
--HARDCODING ROLES
INSERT INTO Roles (Rol)
VALUES ('ADMINISTRADOR'),
       ('DIRECTOR DE ESTUDIOS'),
       ('PROFESOR'),
       ('PRECEPTOR'),
       ('ALUMNO'),
       ('INSCRIPTO'),
       ('EXCLUIDO');
go
--CREACION TABLA USUARIO
create table Usuarios (
ID int identity(1,1) primary key,
Nombre varchar(30) not null,
Dni int unique not null,
Direccion varchar (50) not null,
FechaNac smalldatetime not null,
Mail varchar(40) unique not null,
Telefono varchar(15) not null,
Password varchar(40) not null
)
go

CREATE PROCEDURE Usuarios_Insert
    @Nombre VARCHAR(30),
    @Dni INT,
    @Direccion VARCHAR(50),
    @FechaNac SMALLDATETIME,
    @Mail VARCHAR(40),
    @Telefono VARCHAR(15),
    @Password VARCHAR(40)
AS
BEGIN
    INSERT Usuarios
    VALUES (@Nombre, @Dni, @Direccion, @FechaNac, @Mail, @Telefono, @Password)
	Select @@IDENTITY
END;
go

CREATE PROCEDURE Usuarios_Update
(
    @ID INT,
    @Nombre VARCHAR(30),
    @Dni INT,
    @Direccion VARCHAR(50),
    @FechaNac SMALLDATETIME,
    @Mail VARCHAR(40),
    @Telefono VARCHAR(15),
    @Password VARCHAR(40)
) AS
if @Password<> ''begin
Update Usuarios
		SET Nombre = @Nombre,
        Dni = @Dni,
		Mail = @Mail,
        Direccion = @Direccion,
		FechaNac = @FechaNac,
		Telefono = @Telefono,
		Password=@Password    
		WHERE ID = @ID;
		end
ELSE BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre,
        Dni = @Dni,
        Direccion = @Direccion,
		Mail = @Mail,
        FechaNac = @FechaNac,
		Telefono = @Telefono
        WHERE ID = @ID;
END;
go

create procedure Usuarios_Delete(@ID int)
as
delete Usuarios where ID=@ID
go
create procedure Usuarios_Find (@ID int)
as
select * from Usuarios where ID=@ID
go

--PROCEDURES DE USUARIOS ESPECIALES DE EXISTENCIA
create procedure Usuarios_MailExists(@ID int, @Mail varchar(40))
as
select count(*) from Usuarios where
ID<>@ID and Mail=@Mail
go

create procedure Usuarios_DniExists(@ID int, @Dni int)
as
select count(*) from Usuarios where
ID<>@ID and Dni=@Dni
go

--****************PROCEDURES ESPECIALES DE BUSQUEDA*****************

create procedure Usuarios_FindByMail(@Mail varchar (40))
as
select * from Usuarios where Mail=@Mail 
go

create procedure Usuarios_FindByDni(@Dni int)
as
select * from Usuarios where Dni=@Dni
go

create procedure Usuarios_FindByMailAndDni(@Mail varchar(40), @Dni int)
as
select * from Usuarios where Mail=@Mail and Dni=@Dni
go

create procedure Usuarios_Login(@Mail varchar (40), @Password varchar(40))
as
select * from Usuarios where Mail=@Mail and Password=@Password
go

--**************PROCEDURES DE LISTADO
create procedure Usuarios_List
as select * from Usuarios
go


--********TABLE USUARIOS

create Table UsuariosRoles (
ID int identity(1,1) Primary key,
IDUsuario int foreign key References Usuarios(ID) on delete cascade not null,
Rol varchar(20) foreign Key References Roles(Rol) not null,
constraint UKUR unique(IDUsuario, Rol)
);

go

--*******************STORES PROCEDURES DE USUARIOS ROLES
create procedure UsuariosRoles_Insert(@IDUsuario int, @Rol varchar(20))
as
begin
insert into UsuariosRoles (IDUsuario, Rol) values (@IDUsuario, @Rol)
select @@IDENTITY
end;

go

create procedure UsuariosRoles_Update (@ID int, @IDUsuario int, @Rol varchar(20))
as
update UsuariosRoles set IDUsuario = @IDUsuario, Rol = @Rol where ID = @ID
go


create procedure UsuariosRoles_Delete (@IDUsuario int, @Rol varchar(20))
as
	delete UsuariosRoles where IDUsuario=@IDUsuario and Rol=@Rol
go

create procedure UsuariosRoles_Find( @ID int)
as
	select * from UsuariosRoles where ID=@ID
go

--*********Procedures de listados
create procedure UsuariosRoles_ListByUsuario(@IDUsuario int)
as
	select Rol from UsuariosRoles where IDUsuario=@IDUsuario
go

--HARDcODING USUARIO ADMINISTRADOR
--NOMBRE='admin',
--Dni=1,
--Direccion='dir admin'
--FechaNac='01-01-1990'
--Mail='admin@mail.com'
--Telefono='0000000000'
--El passoword se obtine una dispersion de 'admin'
--Password=''

insert usuarios values(
'admin',
1,
'dir admin',
'01-01-1990',
'admin@mail.com',
'000000000000',
'D033E22AE348AEB5660FC2140AEC35850C4DA997')
--PASSWORD='amin'(con dispersion Sha1)
--hardcoding usuarios eoles
insert UsuariosRoles
values(1,'ADMINISTRADOR')
INSERT UsuariosRoles values(1,'DIRECTOR DE ESTUDIOS')

