-- Удаление таблиц, если они существуют
DROP TABLE IF EXISTS cases;
DROP TABLE IF EXISTS clients;
DROP TABLE IF EXISTS contracts;
DROP TABLE IF EXISTS courthearings;
DROP TABLE IF EXISTS documents;
DROP TABLE IF EXISTS lawyers;
DROP TABLE IF EXISTS payments;
DROP TABLE IF EXISTS reviews;
DROP TABLE IF EXISTS tasks;
DROP TABLE IF EXISTS __efmigrationshistory;

-- Создание таблиц
CREATE TABLE cases (
  Id CHAR(36) NOT NULL,
  CaseName VARCHAR(30) NOT NULL,
  Description VARCHAR(100) NOT NULL,
  OpeningDate DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  ClientId CHAR(36) NOT NULL,
  LawyerId CHAR(36) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE clients (
  Id CHAR(36) NOT NULL,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Email VARCHAR(50) NOT NULL,
  Phone VARCHAR(20) NOT NULL,
  Address VARCHAR(50) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE contracts (
  Id CHAR(36) NOT NULL,
  SigningDate DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  ExpirationDate DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  ClientId CHAR(36) NOT NULL,
  LawyerId CHAR(36) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE courthearings (
  Id CHAR(36) NOT NULL,
  HearingDate DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  Place VARCHAR(50) NOT NULL,
  CaseId CHAR(36) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE documents (
  Id CHAR(36) NOT NULL,
  DocumentName VARCHAR(50) NOT NULL,
  CreationDate DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  DocumentType VARCHAR(25) NOT NULL,
  DocumentText VARCHAR(100) NOT NULL,
  CaseId CHAR(36) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE lawyers (
  Id CHAR(36) NOT NULL,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Specialization VARCHAR(25) NOT NULL,
  Phone VARCHAR(20) NOT NULL,
  Email VARCHAR(50) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE payments (
  Id CHAR(36) NOT NULL,
  PaymentDate DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  Amount DECIMAL(10,2) NOT NULL,
  PaymentMethod VARCHAR(20) NOT NULL,
  ClientId CHAR(36) NOT NULL,
  CaseId CHAR(36) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE reviews (
  Id CHAR(36) NOT NULL,
  Rating INT NOT NULL,
  Comment VARCHAR(50) NOT NULL,
  Date DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  ClientId CHAR(36) NOT NULL,
  LawyerId CHAR(36) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE tasks (
  Id CHAR(36) NOT NULL,
  TaskDescription VARCHAR(50) NOT NULL,
  DateOfCompletion DATETIME2 NOT NULL,  -- Изменено на DATETIME2
  Status VARCHAR(MAX) NOT NULL,
  CaseId CHAR(36) NOT NULL,
  LawyerId CHAR(36) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE __efmigrationshistory (
  MigrationId VARCHAR(150) NOT NULL,
  ProductVersion VARCHAR(32) NOT NULL,
  PRIMARY KEY (MigrationId)
);

-- Вставка данных
INSERT INTO cases (Id, CaseName, Description, OpeningDate, ClientId, LawyerId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e5', 'Case name 1', 'Some description', '2000-11-22 00:00:00', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e2');

INSERT INTO clients (Id, FirstName, LastName, Email, Phone, Address, LawyerId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e1', 'Slava', 'Spanish', 'Dadaya@gmail.com', '+3226232109', 'Nemecia, Frankich 22 / 1');

INSERT INTO contracts (Id, SigningDate, ExpirationDate, ClientId, LawyerId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e3', '2001-11-02 00:00:00', '2002-12-11 00:00:00', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e2');

INSERT INTO courthearings (Id, HearingDate, Place, CaseId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e4', '2001-11-02 00:00:00', 'Belovejskay pyshcha', '8b9658b8-49c1-423a-a807-71d1706710e5');

INSERT INTO documents (Id, DocumentName, CreationDate, DocumentType, DocumentText, CaseId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e6', 'Super Document', '2005-05-14 00:00:00', 'Dicloration', 'Smert', '8b9658b8-49c1-423a-a807-71d1706710e5');

INSERT INTO lawyers (Id, FirstName, LastName, Specialization, Phone, Email) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e2', 'Anna', 'Kanitta', 'Criminal', '+321333942073', 'AnnaKanitta@gmail.com');

INSERT INTO payments (Id, PaymentDate, Amount, PaymentMethod, ClientId, CaseId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e7', '2013-01-02 00:00:00', '6000.32', 'Card', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e5');

INSERT INTO reviews (Id, Rating, Comment, Date, ClientId, LawyerId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e8', 4, 'Normale', '2004-09-19 00:00:00', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e2');

INSERT INTO tasks (Id, TaskDescription, DateOfCompletion, Status, CaseId, LawyerId) 
VALUES ('8b9658b8-49c1-423a-a807-71d1706710e9', 'Need more money', '2004-09-19 00:00:00', 'In progress', '8b9658b8-49c1-423a-a807-71d1706710e5', '8b9658b8-49c1-423a-a807-71d1706710e2');

INSERT INTO __efmigrationshistory (MigrationId, ProductVersion) 
VALUES ('20241229212951_Init', '8.0.2');