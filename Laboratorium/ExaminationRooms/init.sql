BEGIN TRANSACTION;
GO

CREATE TABLE [Certification] (
    [Id] int NOT NULL IDENTITY,
    [GrantedAt] datetime2 NOT NULL,
    [Type] int NOT NULL,
     CONSTRAINT [PK_Certification] PRIMARY KEY ([Id])
    );
GO

CREATE TABLE [ExaminationRoom] (
    [Id] int NOT NULL IDENTITY,
    [Number] nvarchar(max) NULL,
    CONSTRAINT [PK_ExaminationRoom] PRIMARY KEY ([Id])
    );
GO

CREATE TABLE [ExaminationRoomCertification] (
    [CertificationId] int NOT NULL,
    [ExaminationRoomId] int NOT NULL,
     CONSTRAINT [PK_ExaminationRoomCertification] PRIMARY KEY ([CertificationId], [ExaminationRoomId]),
    CONSTRAINT [FK_ExaminationRoomCertification_Certification_CertificationId] FOREIGN KEY ([CertificationId]) REFERENCES [Certification] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ExaminationRoomCertification_ExaminationRoom_ExaminationRoomId] FOREIGN KEY ([ExaminationRoomId]) REFERENCES [ExaminationRoom] ([Id]) ON DELETE CASCADE
    );
GO

CREATE INDEX [IX_ExaminationRoomCertification_ExaminationRoomId] ON [ExaminationRoomCertification] ([ExaminationRoomId]);
GO



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


INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (3,2)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (4,2)
	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (5,3)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (6,3)

	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (7,4)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (8,4)
	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (9,4)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (10,4)

	  	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (7,5)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (8,5)
	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (9,5)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (10,5)

	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (5,6)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (4,6)
	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (11,6)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (12,6)


	 
	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (14,7)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (13,7)
	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (14,8)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (15,8)

	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (14,9)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (15,9)

	 
	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (16,10)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (17,11)
	  INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (16,12)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (18,13)

	 	  INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (4,14)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (6,14)

	 	  INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (19,15)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (20,16)

	   INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (19,17)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (20,18)


	 
	   INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (19,19)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (20,20)

	 	   INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (21,19)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (22,20)
	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (23,4)
	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (25,5)
	 	 	 INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (24,6)
	   INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (1,1)
     INSERT INTO ExaminationRoomCertification (CertificationId, ExaminationRoomId) VALUES (2,2)


COMMIT;
GO

