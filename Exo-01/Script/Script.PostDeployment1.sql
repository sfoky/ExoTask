USE [Exo-01]

ALTER TABLE Task DROP CONSTRAINT FK_Task_Category;
ALTER TABLE Task DROP CONSTRAINT FK_Task_Person;
TRUNCATE TABLE Task;
TRUNCATE TABLE Category;
TRUNCATE TABLE Person;
ALTER TABLE Task ADD CONSTRAINT FK_Task_Category FOREIGN KEY (IdCategory) REFERENCES Category(Id);
ALTER TABLE Task ADD CONSTRAINT FK_Task_Person FOREIGN KEY (IdPerson) REFERENCES Person(Id);


SET IDENTITY_INSERT Category ON;

INSERT INTO [Category] ([Id] ,[Name]) VALUES 
(1, 'Jardinier'),
(2, 'Bricolage'),
(3, 'Ménage'),
(4, 'Livrer'),
(5, 'Autre');

SET IDENTITY_INSERT Category OFF;

SET IDENTITY_INSERT Person ON;

INSERT INTO [Person] ([Id],[LastName],[FirstName]) VALUES 
(1, 'Georges', 'Lucas'),
(2, 'Clint', 'Eastwood'),
(3, 'Sean', 'Connery'),
(4, 'Robert', 'De Niro'),
(5, 'Kevin', 'Bacon');

SET IDENTITY_INSERT Person OFF;

SET IDENTITY_INSERT Task ON;

INSERT INTO [Task] ([Id],[Name],[IdCategory],[IdPerson],[Descr],[CreationDate],[EndingDateMax],[EndingDate]) VALUES
(1, 'Arroser',1 ,1 ,'Arroser les plantes', '2022-06-27 09:00:00','2022-06-27 10:30:00','2022-06-27 10:45:00'),
(2, 'Ménage',3 ,4 ,'Nettoyer salle de réception', '2022-06-22 06:30:00','2022-06-22 15:30:00','2022-06-22 17:05:13'),
(3, 'Plomberie',2 ,2 ,'Réparer evier sdb', '2022-06-26 09:00:00','2022-06-26 10:00:00', '2022-06-26 10:58:25'),
(4, 'Livrer Pizza',4 ,3 ,'Livrer Pizza rue des chevalier n°5', '2022-06-27 15:00:00','2022-06-27 15:13:00',NULL),
(5, 'Tondre',1 ,5 ,'Tondre le jardin rue des moines n°6', '2022-06-25 13:00:00','2022-06-25 16:25:00','2022-06-25 16:45:25'),
(6, 'Faire un bouquet de rose',5 ,3 ,'Preparer le bouquet pour monsieur Jean De Latour', '2022-06-30 13:00:00','2022-07-02 16:25:00',NULL),
(7, 'Passer l''aspirateur',3 ,1 ,'Passer l''aspirateur salle de formation', '2022-07-03 13:00:00','2022-07-03 13:30:00',NULL);
--(8, 'Tondre',1 ,5 ,'Tondre le jardin rue des moines n°6', '2022-06-25 13:00:00','2022-06-25 16:25:00','2022-06-25 16:45:25'),
--(9, 'Tondre',1 ,5 ,'Tondre le jardin rue des moines n°6', '2022-06-25 13:00:00','2022-06-25 16:25:00','2022-06-25 16:45:25'),
--(10, 'Tondre',1 ,5 ,'Tondre le jardin rue des moines n°6', '2022-06-25 13:00:00','2022-06-25 16:25:00','2022-06-25 16:45:25');


SET IDENTITY_INSERT Task OFF;