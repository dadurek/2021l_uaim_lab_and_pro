BEGIN TRANSACTION;
GO


create table Doctors
(
    DoctorId  int identity
        constraint PK_Doctors
            primary key,
    FirstName nvarchar(max),
    LastName  nvarchar(max),
    Sex       nvarchar(max) not null check (Sex in ('male', 'female'))
)
go

create table Specializations
(
    SpecId int identity
        constraint PK_Specializations
            primary key,
    Number int not null
)
go

create table DoctorSpecialization
(
    DoctorsDoctorId       int not null
        constraint FK_DoctorSpecialization_Doctors_DoctorsDoctorId
            references Doctors
            on delete cascade,
    SpecializationsSpecId int not null
        constraint FK_DoctorSpecialization_Specializations_SpecializationsSpecId
            references Specializations
            on delete cascade,
    constraint PK_DoctorSpecialization
        primary key (DoctorsDoctorId, SpecializationsSpecId)
)
go

create index IX_DoctorSpecialization_SpecializationsSpecId
    on DoctorSpecialization (SpecializationsSpecId)
go

insert into Specializations (Number) VALUES (1)
insert into Specializations (Number) VALUES (2)
insert into Specializations (Number) VALUES (3)
insert into Specializations (Number) VALUES (4)
insert into Specializations (Number) VALUES (5)
insert into Specializations (Number) VALUES (6)
insert into Specializations (Number) VALUES (7)
insert into Specializations (Number) VALUES (8)
insert into Specializations (Number) VALUES (9)
insert into Specializations (Number) VALUES (10)
insert into Specializations (Number) VALUES (11)
insert into Specializations (Number) VALUES (12)
insert into Specializations (Number) VALUES (13)
insert into Specializations (Number) VALUES (14)
insert into Specializations (Number) VALUES (15)
insert into Specializations (Number) VALUES (16)
insert into Specializations (Number) VALUES (17)
insert into Specializations (Number) VALUES (18)
insert into Specializations (Number) VALUES (19)
insert into Specializations (Number) VALUES (20)

insert into Doctors (FirstName, LastName, Sex) values ('Marcin','Dadura','male')
insert into Doctors (FirstName, LastName, Sex) values ('Maciej','Wlodarczyk','female')
insert into Doctors (FirstName, LastName, Sex) values ('Krzosztof','Zdulski','female')
insert into Doctors (FirstName, LastName, Sex) values ('Bartosz','Walusiak','male')

insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (1,1)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (1,2)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (1,3)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (1,8)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (1,9)

insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (2,4)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (2,5)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (2,11)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (2,12)

insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (3,5)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (3,7)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (3,13)

insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (4,15)
insert into DoctorSpecialization (DoctorsDoctorId, SpecializationsSpecId) values (5,17)

COMMIT;
GO