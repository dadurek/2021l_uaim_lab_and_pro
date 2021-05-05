BEGIN TRANSACTION;
GO

create table Certification
(
    Id        int identity
        constraint PK_Certification
            primary key,
    GrantedAt datetime2 not null,
    Type      int       not null
)
go



create table ExaminationRoom
(
    Id     int identity
        constraint PK_ExaminationRoom
            primary key,
    Number nvarchar(max)
)
go



create table CertificationExaminationRoom
(
    CertificationsId   int not null
        constraint FK_CertificationExaminationRoom_Certification_CertificationsId
            references Certification
            on delete cascade,
    ExaminationRoomsId int not null
        constraint FK_CertificationExaminationRoom_ExaminationRoom_ExaminationRoomsId
            references ExaminationRoom
            on delete cascade,
    constraint PK_CertificationExaminationRoom
        primary key (CertificationsId, ExaminationRoomsId)
)
go

create index IX_CertificationExaminationRoom_ExaminationRoomsId
    on CertificationExaminationRoom (ExaminationRoomsId)
go





INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 1)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 2)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 3)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 4)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 5)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 6)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 7)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 8)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 9)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 10)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 12)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 14)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 15)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 16)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 17)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 18)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 19)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 20)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 23)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 24)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 17)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 31)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 33)
   INSERT INTO Certification (GrantedAt, Type) VALUES (GETDATE(), 34)


   INSERT INTO ExaminationRoom (Number) VALUES ('01')
   INSERT INTO ExaminationRoom (Number) VALUES ('02')
   INSERT INTO ExaminationRoom (Number) VALUES ('03')
   INSERT INTO ExaminationRoom (Number) VALUES ('101')
   INSERT INTO ExaminationRoom (Number) VALUES ('102')
   INSERT INTO ExaminationRoom (Number) VALUES ('103')
   INSERT INTO ExaminationRoom (Number) VALUES ('104')
   INSERT INTO ExaminationRoom (Number) VALUES ('105a')
   INSERT INTO ExaminationRoom (Number) VALUES ('105b')
   INSERT INTO ExaminationRoom (Number) VALUES ('201')
   INSERT INTO ExaminationRoom (Number) VALUES ('202')
   INSERT INTO ExaminationRoom (Number) VALUES ('203')
   INSERT INTO ExaminationRoom (Number) VALUES ('204a')
   INSERT INTO ExaminationRoom (Number) VALUES ('204b')
   INSERT INTO ExaminationRoom (Number) VALUES ('301')
   INSERT INTO ExaminationRoom (Number) VALUES ('302')
   INSERT INTO ExaminationRoom (Number) VALUES ('303')
   INSERT INTO ExaminationRoom (Number) VALUES ('401')
   INSERT INTO ExaminationRoom (Number) VALUES ('402')
   INSERT INTO ExaminationRoom (Number) VALUES ('403')


INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (3,2)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (4,2)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (5,3)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (6,3)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (7,4)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (8,4)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (9,4)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (10,4)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (7,5)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (8,5)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (9,5)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (10,5)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (5,6)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (4,6)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (11,6)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (12,6)



INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (14,7)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (13,7)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (14,8)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (15,8)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (14,9)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (15,9)


INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (16,10)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (17,11)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (16,12)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (18,13)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (4,14)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (6,14)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (19,15)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (20,16)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (19,17)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (20,18)



INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (19,19)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (20,20)

INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (21,19)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (22,20)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (23,4)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (25,5)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (24,6)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (1,1)
INSERT INTO CertificationExaminationRoom (CertificationsId, ExaminationRoomsId) VALUES (2,2)



COMMIT;
GO

