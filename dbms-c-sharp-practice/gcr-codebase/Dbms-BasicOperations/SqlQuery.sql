/* DATABASE CREATION (DDL) */
CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

/* CREATE TABLE : Categories */
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50) UNIQUE NOT NULL
);
GO

/* CREATE TABLE : Members */
CREATE TABLE Members (
    MemberID INT PRIMARY KEY,
    MemberName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
GO

/* CREATE TABLE : Books */
CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(100),
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
GO

/* CREATE TABLE : BorrowRecords (COMPOSITE KEY) */
CREATE TABLE BorrowRecords (
    MemberID INT,
    BookID INT,
    BorrowDate DATE,
    ReturnDate DATE,
    PRIMARY KEY (MemberID, BookID),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
GO

/* INSERT DATA (DML)*/

INSERT INTO Categories VALUES
(1, 'Technology'),
(2, 'Science'),
(3, 'Literature');

INSERT INTO Members VALUES
(101, 'Riya', 'riya@gmail.com', 1),
(102, 'Arjun', 'arjun@gmail.com', 2),
(103, 'Meera', 'meera@gmail.com', 3);

INSERT INTO Books VALUES
(201, 'C# Basics', 'Herbert', 1),
(202, 'Physics Fundamentals', 'Halliday', 2),
(203, 'Shakespeare Works', 'William', 3);

INSERT INTO BorrowRecords VALUES
(101, 201, '2026-02-01', '2026-02-10'),
(102, 202, '2026-02-02', '2026-02-12'),
(103, 203, '2026-02-03', '2026-02-13');
GO

/* SELECT QUERIES (DQL)*/

SELECT * FROM Members;
SELECT * FROM Members WHERE CategoryID = 1;
SELECT * FROM Members ORDER BY MemberName;

SELECT CategoryID, COUNT(*) AS TotalMembers
FROM Members
GROUP BY CategoryID;
GO

/* JOINS */

SELECT m.MemberName, b.Title
FROM Members m
INNER JOIN BorrowRecords br ON m.MemberID = br.MemberID
INNER JOIN Books b ON br.BookID = b.BookID;

SELECT m.MemberName, br.BookID
FROM Members m
LEFT JOIN BorrowRecords br ON m.MemberID = br.MemberID;
GO

/* UPDATE & DELETE */

UPDATE Members
SET Email = 'riya_new@gmail.com'
WHERE MemberID = 101;

DELETE FROM BorrowRecords
WHERE MemberID = 102 AND BookID = 202;
GO

/* TCL COMMANDS */

BEGIN TRANSACTION;
INSERT INTO Members VALUES (104, 'Karan', 'karan@gmail.com', 1);
ROLLBACK;

BEGIN TRANSACTION;
INSERT INTO Members VALUES (105, 'Sneha', 'sneha@gmail.com', 2);
COMMIT;
GO

/*   NORMALIZATION*/

-- 1NF
CREATE TABLE Member_1NF (
    MemberID INT,
    MemberName VARCHAR(50),
    BookTitle VARCHAR(100)
);

-- 2NF
CREATE TABLE Member_2NF (
    MemberID INT PRIMARY KEY,
    MemberName VARCHAR(50)
);

-- 3NF
CREATE TABLE Category_3NF (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50)
);

-- BCNF
CREATE TABLE Librarian_BCNF (
    LibrarianName VARCHAR(50) PRIMARY KEY,
    RoomNo INT
);

GO