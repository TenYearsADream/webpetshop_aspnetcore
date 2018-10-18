
/****************************************************************
 * Projeto:.....: Projeto WebPetshop                           	*
 * Titulo:......: Script Criar esquema WebPetshop              	*
 * Autor........: Ronaldo Torre                                 *
 * Referencia...: Release 1.0.0                                 *
 *--------------------------------------------------------------*
 ***************************************************************/

print 'Script Create Schema WebPetshop';
print '=============================================';

Use master;

-- check existing database
IF EXISTS(select * from sys.databases where name='WebPetshop')
begin
	drop database WebPetshop;
	print 'Database existing and delete!';
end;


Create database WebPetshop;
print 'Create new database WebPetshop';
go

use WebPetshop;
print 'Access WebPetshop';
print 'Create tables';


-- Animal

Create table Animal
(
	IdAnimal					integer      	not null identity,
    TypeId						integer         not null,  
	Specie						varchar(35)		not null, 
    Description					text  			null,
    Birthdate 					date			null,
	Amount						integer			null default 1,
    Price 						decimal(12,2)   null,
	AddDate						datetime        not null,
    AddUser						varchar(25)     not null,
    UpdateDate					datetime        null,
    UpdateUser					varchar(25)     null,
    Constraint Pk_Animal primary key(IdAnimal)
);


-- Endereço

Create table Address
(
    IdAddress                   integer         not null identity,
    TypeId                      integer         not null,
    Name                        varchar(100)    not null,
    Number                      varchar(10)     not null,
    Complement                  varchar(100)    null,
    ZipCode                     varchar(10)     not null,
    District                    varchar(100)    not null,
    City                        varchar(50)     not null,
    State                       varchar(5)      not null,
    AddDate                     datetime        not null,
    AddUser                     varchar(25)     not null,
    UpdateDate                  datetime        null,
    UpdateUser                  varchar(25)     null,
    Constraint Pk_Address primary key(IdAddress)
);


-- contato 

Create table Contact
(
    IdContact                   integer         not null identity,
    PersonId                    integer         null,
    TypeId                      integer         not null,
    Description                 varchar(100)    not null,
    AddDate                     datetime        not null,
    AddUser                     varchar(25)     not null,
    UpdateDate                  datetime        null,
    UpdateUser                  varchar(25)     null,
    Constraint Pk_Contact primary key(IdContact)
);


-- Pessoa

Create table Person
(
    IdPerson					integer         not null identity,
	TypePerson			     	integer      	not null,
	Name					 	varchar(100)  	not null,
	SocialName		     		varchar(150) 	null,
	Gender					 	integer      	null,
	BirthDate 				 	date         	null,
	Document1				 	varchar(25)  	not null,
	Document2				 	varchar(25)  	null,
	Document3				 	varchar(25)  	null,
    AddressId 					integer 		not null,
	MotherName               	varchar(50)  	null,
	FatherName               	varchar(50)  	null,
	AddDate                  	datetime     	not null,
	AddUser					 	varchar(25)  	not null,
	UpdateDate				 	datetime     	null,
	UpdateUser				 	varchar(25)  	null,
    Constraint Pk_Person primary key(IdPerson),
    Constraint Fk_Address_Person foreign key(AddressId) references Address(IdAddress)
);

Alter table Contact add Constraint Fk_Person_Contact foreign key(PersonId) references Person(IdPerson);



-- Pedido

Create table Orders
(
	IdOrder						integer			not null identity,
	Type						integer			not null,
	PersonId					integer			not null,
	Total						decimal(12,2)   not null,
	Situation					varchar(1)		not null,
	AddDate                  	datetime     	not null,
	AddUser					 	varchar(25)  	not null,
	UpdateDate				 	datetime     	null,
	UpdateUser				 	varchar(25)  	null,
	Constraint Pk_Order primary key(IdOrder)
);


-- Item Pedido

Create table OrdersItem
(
	IdOrderItem					integer			not null identity,
	OrderId						integer			not null,
	AnimalType					integer			null,
	AnimalId					integer			null,
	ProductId					integer			null,
	Price						decimal(12,2)   not null,
	Amount						integer			not null default 1,
	PriceUnit					decimal(12,2)   not null,
	Constraint Pk_OrderItem primary key(IdOrderItem),
	Constraint Fk_Order_OrderItem foreign key(OrderId) references Orders(IdOrder)
);



-- Perfil de usuário

Create table UserProfile
(
	IdUserProfile               integer         not null identity,
	Name						varchar(35)		not null,
	Initials					varchar(5)		not null,
	Description					text			null,
	AddDate                     datetime        not null,
	UpdateDate                  datetime        null,
	Constraint Pk_UserProfile primary key(IdUserProfile)
);


-- Usuário

Create table UserSys
(
	IdUserSys					integer         not null identity,
	Login						varchar(25)		not null,
	Name						varchar(35)		not null,
	Password					varchar(100)	not null,
	Mail						varchar(100)	null,
	Reminder					varchar(100)	null,
	PerfilId					integer			not null,
	AddDate                     datetime        not null,
	UpdateDate                  datetime        null,
	Constraint Pk_UserSys primary key(IdUserSys),
	Constraint Fk_Perfil_UserSys foreign key(PerfilId) references UserProfile(IdUserProfile)
);




-- Registros
-- -------------------------------------------------------------------------------
 -- Perfil
 Insert into UserProfile(Name,Initials,Description,AddDate)values('Administrador','ADM','Perfil de administrador do Sistema',convert(datetime,'16/10/2018 16:15',103));
 
 -- Usuário
 Insert into UserSys(Login,Name,Password,Mail,Reminder,PerfilId,AddDate)values('Uadmin','Administrador Sistema','adm123',null,null,1,convert(datetime,'16/10/2018 16:30',103));

 -- Animal no petshop
 Insert into Animal(TypeId,Specie,Description,Birthdate,Amount,Price,AddDate,AddUser)values(1,'Labrador',null,null,10,0,convert(datetime,'16/10/2018 16:35',103),'Uadmin');


 -- Pessoa
 Insert into Address(TypeId,Name,Number,Complement,ZipCode,District,City,State,AddDate,AddUser)values(1,'Rua Gil Vicente','223',null,'09110-120','Silveira','Santo André','SP',convert(datetime,'17/10/2018 09:35',103),'Uadmin');
 Insert into Person(TypePerson,Name,Gender,BirthDate,Document1,Document2,AddressId,MotherName,FatherName,AddDate,AddUser)values(0,'Nina Elaine Hadassa Pereira',0,convert(datetime,'04/05/1988',103),'390.578.778-48','25.753.504-4',1,'Silvana Rebeca','Márcio Calebe Lucas Pereira',convert(datetime,'17/10/2018 09:35',103),'Uadmin');
 Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(1,0,'(11)3675-1452',convert(datetime,'17/10/2018 09:35',103),'Uadmin');
 Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(1,1,'(11)99684-9617',convert(datetime,'17/10/2018 09:35',103),'Uadmin');
 Insert into Contact(PersonId,TypeId,Description,AddDate,AddUser)values(1,1,'ninaelainehadassapereira-93@adiretoria.com.br',convert(datetime,'17/10/2018 09:35',103),'Uadmin');


print 'completed*';