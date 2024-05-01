CREATE TABLE Service (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Price DECIMAL(10,2),
    Category VARCHAR(50)
);

INSERT INTO Service (Id, Name, Price, Category) VALUES
(1, 'Barber', 100, 'hair'),
(2, 'Braids', 200, 'hair'),
(3, 'Face treatments', 300, 'face'),
(4, 'Hair removal', 100, 'hair'),
(5, 'Hair salon', 200, 'hair'),
(6, 'Makeup / lashes / brows', 300, 'face'),
(7, 'Med spa', 100, 'face'),
(8, 'Nails', 200, 'nails')

----------------------------------------------------------

CREATE TABLE Package (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Price DECIMAL(10,2)
);

INSERT INTO Package (Id, Name, Price) VALUES
(1, 'p1', 150),
(2, 'p2', 200),
(3, 'p3', 180),
(4, 'p4', 220),
(5, 'p5', 250),
(6, 'p6', 190),
(7, 'p7', 270),
(8, 'p8', 300),
(9, 'p9', 230),
(10, 'p10', 280),
(11, 'p11', 170),
(12, 'p12', 210),
(13, 'p13', 260),
(14, 'p14', 320),
(15, 'p15', 340),
(16, 'p16', 270),
(17, 'p17', 390),
(18, 'p18', 420),
(19, 'p19', 350),
(20, 'p20', 380);

---------------------------------------------------------------------

CREATE TABLE Userr (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Password VARCHAR(100),
    Email VARCHAR(100),
    BankAccount VARCHAR(100)
);

INSERT INTO Userr (Id, Name, Password, Email, BankAccount) VALUES
(1, 'User1', 'password1', 'user1@example.com', '1234567890'),
(2, 'User2', 'password2', 'user2@example.com', '0987654321'),
(3, 'User3', 'password3', 'user3@example.com', '1357924680'),
(4, 'User4', 'password4', 'user4@example.com', '2468013579');

----------------------------------------------------------------------

CREATE TABLE PackageService (
    ServiceId INT,
    PackageId INT,
    FOREIGN KEY (ServiceId) REFERENCES Service(Id),
    FOREIGN KEY (PackageId) REFERENCES Package(Id),
	PRIMARY KEY (ServiceId, PackageId)
);

-- For example, let's associate Service ID 1 (Barber) with Package ID 1 (p1)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (1, 1);

-- Associate Service ID 2 (Braids) with Package ID 2 (p2)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (2, 2);

-- Associate Service ID 3 (Face treatments) with Package ID 3 (p3)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (3, 3);

-- Associate Service ID 4 (Hair removal) with Package ID 4 (p4)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (4, 4);

-- Associate Service ID 5 (Hair salon) with Package ID 5 (p5)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (5, 5);

-- Associate Service ID 6 (Makeup / lashes / brows) with Package ID 6 (p6)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (6, 6);

-- Associate Service ID 7 (Med spa) with Package ID 7 (p7)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (7, 7);

-- Associate Service ID 8 (Nails) with Package ID 8 (p8)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (8, 8);

-- Associate Service ID 9 (Barber) with Package ID 9 (p9)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (1, 9);

-- Associate Service ID 10 (Braids) with Package ID 10 (p10)
INSERT INTO PackageService (ServiceId, PackageId) VALUES (2, 10);

--------------------------------------------------------------------------------

CREATE TABLE PackageUser (
    UserId INT,
    PackageId INT,
    Date DATE,
    FOREIGN KEY (UserId) REFERENCES Userr(Id),
    FOREIGN KEY (PackageId) REFERENCES Package(Id),
	PRIMARY KEY (UserId, PackageId)
);


-- For example, let's associate User ID 1 with Package ID 1 and assign the package on today's date
INSERT INTO PackageUser (UserId, PackageId, Date) VALUES (1, 1, '2024-04-10');

-- Associate User ID 2 with Package ID 2 and assign the package on a specific date (e.g., '2024-04-30')
INSERT INTO PackageUser (UserId, PackageId, Date) VALUES (2, 2, '2024-04-30');

--------------------------------------------------------------------------------

CREATE TABLE UserServices (
    UserId INT,
    ServiceId INT,
    Date DATE,
    FOREIGN KEY (UserId) REFERENCES Userr(Id),
    FOREIGN KEY (ServiceId) REFERENCES Service(Id),
	PRIMARY KEY (UserId, ServiceId)
);


-- For example, let's associate User ID 1 with Service ID 1 and assign the service on today's date
INSERT INTO UserServices (UserId, ServiceId, Date) VALUES (1, 1,'2024-04-20');

-- Associate User ID 2 with Service ID 2 and assign the service on a specific date (e.g., '2024-04-30')
INSERT INTO UserServices (UserId, ServiceId, Date) VALUES (2, 2, '2024-04-30');

