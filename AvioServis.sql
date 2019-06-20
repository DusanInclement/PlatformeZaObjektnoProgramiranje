CREATE DATABASE AvioServis
USE AvioServis

CREATE TABLE Korisnik
(
	KorisnikId INT IDENTITY(1,1) PRIMARY KEY,
	Ime NVARCHAR(50) not null,
	Prezime NVARCHAR(50) not null,
	Email NVARCHAR(50),
	Adresa NVARCHAR(100),
	Pol NVARCHAR(20),
	KorisnickoIme NVARCHAR(50),
	Lozinka NVARCHAR(50),
	TipKorisnika NVARCHAR(20) not null,
	Deleted SMALLINT NOT NULL DEFAULT 0 
	
)

CREATE TABLE Aerodrom
(
	AerodromId INT IDENTITY(1,1) PRIMARY KEY,
	Sifra NVARCHAR(50) not null,
	Naziv NVARCHAR(50) not null,
	Grad NVARCHAR(50) not null,
	Deleted SMALLINT NOT NULL DEFAULT 0 
)

CREATE TABLE AvioKompanija
(
	AvioKompanijaId INT IDENTITY(1,1) PRIMARY KEY,
	Naziv NVARCHAR(50) not null,
	Deleted SMALLINT NOT NULL DEFAULT 0 
)

CREATE TABLE Avion
(
	AvionId INT IDENTITY(1,1) PRIMARY KEY,
	
	BrojRedovaEkonomskeKlase INT not null,
	BrojSedistaUReduEkonomskeKlase INT not null,
	BrojRedovaBiznisKlase INT not null,
	BrojSedistaUReduBiznisKlase INT not null,
	AvioKompanijaId int not null Foreign key references AvioKompanija(AvioKompanijaId),
	Naziv NVARCHAR(50) not null,
	Deleted SMALLINT NOT NULL DEFAULT 0 
)
 CREATE TABLE Let
 (
	LetId INT IDENTITY(1,1) PRIMARY KEY,
	Sifra NVARCHAR(50) not null,
	Pilot NVARCHAR(50) not null,
	VremePolaska SMALLDATETIME not null,
	VremeDolaska SMALLDATETIME not null,
	PolazniAerodrom int not null FOREIGN KEY REFERENCES Aerodrom(AerodromId),
	DolazniAerodrom int not null FOREIGN KEY REFERENCES Aerodrom(AerodromId),
	AvionId int not null FOREIGN KEY REFERENCES Avion(AvionId),
	Cena DECIMAL not null,
	Deleted SMALLINT NOT NULL DEFAULT 0 
 )

 CREATE TABLE Karta
 (
	KartaId INT IDENTITY(1,1) PRIMARY KEY,
	LetId INT not null FOREIGN KEY REFERENCES Let(LetId),
	BrojReda INT not null,
	BrojSedista INT not null,
	KorisnikId INT not null FOREIGN KEY REFERENCES Korisnik(KorisnikId),
	Klasa NVARCHAR(50) not null,
	Kapija NVARCHAR(50) not null,
	Cena DECIMAL not null,
	Deleted SMALLINT NOT NULL DEFAULT 0 
 )

SELECT * FROM Korisnik
SELECT * FROM AvioKompanija
SELECT * FROM Aerodrom
SELECT * FROM Avion
SELECT * FROM Let
SELECT * FROM Karta

  
Select a.Sifra , a.VremePolaska, a.VremeDolaska,a.PolazniAerodrom,a.DolazniAerodrom,c.Naziv,a.Cena 
FROM Let AS a INNER JOIN Aerodrom AS b ON a.PolazniAerodrom = b.AerodromId
INNER JOIN
Avion AS c ON a.AvionId = c.AvionId;

Select b.Naziv , a.Naziv  FROM Avion a INNER JOIN AvioKompanija b ON a.AvioKompanijaId = b.AvioKompanijaId ORDER BY b.Naziv ASC

SET DATEFORMAT dmy

INSERT INTO Korisnik VALUES('Dusan','Vukovic','inclement@gmail.com','Novi Karlovci','Muski','dusan','123','Admin',0)
INSERT INTO Korisnik VALUES('Mina','Vukovic','mina@gmail.com','Novi Karlovci','Zenski','mina','123','Admin',0)
INSERT INTO Korisnik VALUES('Mika','Mikic','mika@gmail.com','Beograd','Muski','mika','123','User',0)
INSERT INTO Korisnik VALUES('Pera','Peric','','','','','','Unregistred',0)


 INSERT INTO AvioKompanija VALUES ('Srbija', 0)
 INSERT INTO AvioKompanija VALUES ('Turska', 0)
 INSERT INTO AvioKompanija VALUES ('Madjarska', 0)

 INSERT INTO Aerodrom VALUES ('BEG', 'Nikola Tesla', 'Beograd', 0)
 INSERT INTO Aerodrom VALUES ('LON', 'London Airport', 'London', 0)
 INSERT INTO Aerodrom VALUES ('ROM', 'Rome Airport', 'Rome', 0)

 INSERT INTO Avion VALUES (4, 5, 2, 3, 1, 'Boing SRB', 0)
 INSERT INTO Avion VALUES (4, 5, 2, 3, 2, 'Boeg TUR', 0)
 INSERT INTO Avion VALUES (4, 5, 2, 3, 3, 'AIR HUN', 0)
 INSERT INTO Avion VALUES (6, 3, 3, 2, 1, 'Falcon SRB', 0)

INSERT INTO Let VALUES('123','Pilot1','20.02.2019','21.02.2019',1,3,1,200,0)
INSERT INTO Let VALUES('124','Pilot2','25.02.2019','26.02.2019',2,1,2,300,0)
INSERT INTO Let VALUES('125','Pilot3','01.03.2019','02.03.2019',3,2,3,100,0)
INSERT INTO Let VALUES('126','Pilot4','10.03.2019','11.03.2019',2,1,4,500,0)

INSERT INTO Karta VALUES (1,1,2,1,'Biznis','Kapija1',400,0)






