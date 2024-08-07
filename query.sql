CREATE DATABASE PROCEDUR

USE PROCEDUR;
    
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(255) NOT NULL
);



CREATE TABLE CategoryRelations (
    ParentCategoryID INT,
    ChildCategoryID INT,
    PRIMARY KEY (ParentCategoryID, ChildCategoryID),
    FOREIGN KEY (ParentCategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (ChildCategoryID) REFERENCES Categories(CategoryID)
);


INSERT INTO Categories (CategoryID, CategoryName) VALUES
(1, 'Elektronik'),
(2, 'Telefonlar'),
(3, 'Kameralar'),
(4, 'Akıllı Telefonlar'),
(5, 'Lensler'),
(6, 'Cam'),
(7, 'Dizüstü Bilgisayar'),
(8, 'Kahve Makinesi'),
(9, 'Android Telefon'),
(10, 'IOS Telefon'),
(11, 'Bilgisayar Aksesuarları'),
(12, 'TV ve Eğlence Sistemleri'),
(13, 'Ev Aletleri'),
(14, 'Mutfak Gereçleri'),
(15, 'Spor ve Outdoor'),
(16, 'Kitaplar'),
(17, 'Müzik Aletleri'),
(18, 'Akıllı Ev Sistemleri'),
(19, 'Oyun Konsolları'),
(20, 'Kişisel Bakım Ürünleri'),
(21, 'Eğitim Ürünleri'),
(22, 'Sağlık Ürünleri'),
(23, 'Oto Aksesuarları'),
(24, 'Giyim ve Moda'),
(25, 'Çocuk Ürünleri'),
(26, 'Ofis Malzemeleri'),
(27, 'Hobi Ürünleri'),
(28, 'Güvenlik Sistemleri'),
(29, 'Yatak ve Yastıklar'),
(30, 'Züccaciye'),
(31, 'Lightning Şarj Kablosu'),
(32, 'TYPE-C Şarj Kablosu');






INSERT INTO CategoryRelations (ParentCategoryID, ChildCategoryID) VALUES
(1, 2),
(1, 3),
(1, 12),
(2, 4),
(2, 9),
(2, 4),
(3, 5),
(3, 6),
(4, 9),
(7, 11),
(7, 27),
(8, 14),
(9, 32),
(10,31),
(13, 14),
(18, 20),
(18, 28),
(19, 23),
(20, 16),
(20, 21),
(21, 16),
(22, 24),
(23, 24),
(24, 25),
(26, 27),
(26, 28),
(27, 17),
(28, 30),
(30, 29)



USE PROCEDUR


CREATE PROCEDURE GetCategoryHierarchyWParams1
    @CategoryID INT
AS
BEGIN
    WITH CategoryHierarchy AS
    (
        SELECT 
            c.CategoryID,
            c.CategoryName,
            cr.ParentCategoryID,
            CAST(c.CategoryName AS NVARCHAR(MAX)) AS FullPath, 
            0 AS Level                                        
        FROM Categories c
        LEFT JOIN CategoryRelations cr ON c.CategoryID = cr.ChildCategoryID
        WHERE c.CategoryID = @CategoryID                      

        UNION ALL

        SELECT 
            c.CategoryID,
            c.CategoryName,
            cr.ParentCategoryID,
            CAST(ch.FullPath + ' -> ' + c.CategoryName AS NVARCHAR(MAX)) AS FullPath, 
            ch.Level + 1                                       
        FROM Categories c
        INNER JOIN CategoryRelations cr ON c.CategoryID = cr.ChildCategoryID
        INNER JOIN CategoryHierarchy ch ON cr.ParentCategoryID = ch.CategoryID
    )
    SELECT * 
    FROM CategoryHierarchy
    ORDER BY FullPath
END;



EXEC GetCategoryHierarchyWParams1 1;
