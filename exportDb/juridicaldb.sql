-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Янв 01 2025 г., 22:58
-- Версия сервера: 5.7.24
-- Версия PHP: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `juridicaldb`
--

-- --------------------------------------------------------

--
-- Структура таблицы `cases`
--

CREATE TABLE `cases` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `CaseName` varchar(30) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `OpeningDate` datetime(6) NOT NULL,
  `ClientId` char(36) CHARACTER SET ascii NOT NULL,
  `LawyerId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `cases`
--

INSERT INTO `cases` (`Id`, `CaseName`, `Description`, `OpeningDate`, `ClientId`, `LawyerId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e5', 'Case name 1', 'Some description', '2000-11-22 00:00:00.000000', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e2');

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  `Address` varchar(50) NOT NULL,
  `LawyerId` char(36) CHARACTER SET ascii DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`Id`, `FirstName`, `LastName`, `Email`, `Phone`, `Address`, `LawyerId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e1', 'Slava', 'Spanish', 'Dadaya@gmail.com', '+3226232109', 'Nemecia, Frankich 22 / 1', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `contracts`
--

CREATE TABLE `contracts` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `SigningDate` datetime(6) NOT NULL,
  `ExpirationDate` datetime(6) NOT NULL,
  `ClientId` char(36) CHARACTER SET ascii NOT NULL,
  `LawyerId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `contracts`
--

INSERT INTO `contracts` (`Id`, `SigningDate`, `ExpirationDate`, `ClientId`, `LawyerId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e3', '2001-11-02 00:00:00.000000', '2001-12-11 00:00:00.000000', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e2');

-- --------------------------------------------------------

--
-- Структура таблицы `courthearings`
--

CREATE TABLE `courthearings` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `HearingDate` datetime(6) NOT NULL,
  `Place` varchar(50) NOT NULL,
  `CaseId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `courthearings`
--

INSERT INTO `courthearings` (`Id`, `HearingDate`, `Place`, `CaseId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e4', '2001-11-02 00:00:00.000000', 'Belovejskay pyshcha', '8b9658b8-49c1-423a-a807-71d1706710e5');

-- --------------------------------------------------------

--
-- Структура таблицы `documents`
--

CREATE TABLE `documents` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `DocumentName` varchar(50) NOT NULL,
  `CreationDate` datetime(6) NOT NULL,
  `DocumentType` varchar(25) NOT NULL,
  `DocumentText` varchar(100) NOT NULL,
  `CaseId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `documents`
--

INSERT INTO `documents` (`Id`, `DocumentName`, `CreationDate`, `DocumentType`, `DocumentText`, `CaseId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e6', 'Super Document', '2005-05-14 00:00:00.000000', 'Dicloration', '', '8b9658b8-49c1-423a-a807-71d1706710e5');

-- --------------------------------------------------------

--
-- Структура таблицы `lawyers`
--

CREATE TABLE `lawyers` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Specialization` varchar(25) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  `Email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `lawyers`
--

INSERT INTO `lawyers` (`Id`, `FirstName`, `LastName`, `Specialization`, `Phone`, `Email`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e2', 'Anna', 'Kanitta', 'Criminal', '+321333942073', 'AnnaKanitta@gmail.com');

-- --------------------------------------------------------

--
-- Структура таблицы `payments`
--

CREATE TABLE `payments` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `PaymentDate` datetime(6) NOT NULL,
  `Amount` decimal(10,2) NOT NULL,
  `PaymentMethod` varchar(20) NOT NULL,
  `ClientId` char(36) CHARACTER SET ascii NOT NULL,
  `CaseId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `payments`
--

INSERT INTO `payments` (`Id`, `PaymentDate`, `Amount`, `PaymentMethod`, `ClientId`, `CaseId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e7', '2013-01-02 00:00:00.000000', '6000.32', 'Card', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e5');

-- --------------------------------------------------------

--
-- Структура таблицы `reviews`
--

CREATE TABLE `reviews` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Rating` int(11) NOT NULL,
  `Comment` varchar(50) NOT NULL,
  `Date` datetime(6) NOT NULL,
  `ClientId` char(36) CHARACTER SET ascii NOT NULL,
  `LawyerId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `reviews`
--

INSERT INTO `reviews` (`Id`, `Rating`, `Comment`, `Date`, `ClientId`, `LawyerId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e8', 4, 'Normale', '2004-09-19 00:00:00.000000', '8b9658b8-49c1-423a-a807-71d1706710e1', '8b9658b8-49c1-423a-a807-71d1706710e2');

-- --------------------------------------------------------

--
-- Структура таблицы `tasks`
--

CREATE TABLE `tasks` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `TaskDescription` varchar(50) NOT NULL,
  `DateOfCompletion` datetime(6) NOT NULL,
  `Status` longtext NOT NULL,
  `CaseId` char(36) CHARACTER SET ascii NOT NULL,
  `LawyerId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `tasks`
--

INSERT INTO `tasks` (`Id`, `TaskDescription`, `DateOfCompletion`, `Status`, `CaseId`, `LawyerId`) VALUES
('8b9658b8-49c1-423a-a807-71d1706710e9', 'Need more money', '2004-09-19 00:00:00.000000', 'In progress', '8b9658b8-49c1-423a-a807-71d1706710e5', '8b9658b8-49c1-423a-a807-71d1706710e2');

-- --------------------------------------------------------

--
-- Структура таблицы `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241229212951_Init', '8.0.2');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `cases`
--
ALTER TABLE `cases`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Cases_ClientId` (`ClientId`),
  ADD UNIQUE KEY `IX_Cases_LawyerId` (`LawyerId`);

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Clients_LawyerId` (`LawyerId`);

--
-- Индексы таблицы `contracts`
--
ALTER TABLE `contracts`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Contracts_ClientId` (`ClientId`),
  ADD UNIQUE KEY `IX_Contracts_LawyerId` (`LawyerId`);

--
-- Индексы таблицы `courthearings`
--
ALTER TABLE `courthearings`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_CourtHearings_CaseId` (`CaseId`);

--
-- Индексы таблицы `documents`
--
ALTER TABLE `documents`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Documents_CaseId` (`CaseId`);

--
-- Индексы таблицы `lawyers`
--
ALTER TABLE `lawyers`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Payments_CaseId` (`CaseId`),
  ADD UNIQUE KEY `IX_Payments_ClientId` (`ClientId`);

--
-- Индексы таблицы `reviews`
--
ALTER TABLE `reviews`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Reviews_ClientId` (`ClientId`),
  ADD UNIQUE KEY `IX_Reviews_LawyerId` (`LawyerId`);

--
-- Индексы таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Tasks_CaseId` (`CaseId`),
  ADD UNIQUE KEY `IX_Tasks_LawyerId` (`LawyerId`);

--
-- Индексы таблицы `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `cases`
--
ALTER TABLE `cases`
  ADD CONSTRAINT `FK_Cases_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Cases_Lawyers_LawyerId` FOREIGN KEY (`LawyerId`) REFERENCES `lawyers` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `clients`
--
ALTER TABLE `clients`
  ADD CONSTRAINT `FK_Clients_Lawyers_LawyerId` FOREIGN KEY (`LawyerId`) REFERENCES `lawyers` (`Id`);

--
-- Ограничения внешнего ключа таблицы `contracts`
--
ALTER TABLE `contracts`
  ADD CONSTRAINT `FK_Contracts_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Contracts_Lawyers_LawyerId` FOREIGN KEY (`LawyerId`) REFERENCES `lawyers` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `courthearings`
--
ALTER TABLE `courthearings`
  ADD CONSTRAINT `FK_CourtHearings_Cases_CaseId` FOREIGN KEY (`CaseId`) REFERENCES `cases` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `documents`
--
ALTER TABLE `documents`
  ADD CONSTRAINT `FK_Documents_Cases_CaseId` FOREIGN KEY (`CaseId`) REFERENCES `cases` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `FK_Payments_Cases_CaseId` FOREIGN KEY (`CaseId`) REFERENCES `cases` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Payments_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `reviews`
--
ALTER TABLE `reviews`
  ADD CONSTRAINT `FK_Reviews_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Reviews_Lawyers_LawyerId` FOREIGN KEY (`LawyerId`) REFERENCES `lawyers` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD CONSTRAINT `FK_Tasks_Cases_CaseId` FOREIGN KEY (`CaseId`) REFERENCES `cases` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Tasks_Lawyers_LawyerId` FOREIGN KEY (`LawyerId`) REFERENCES `lawyers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
