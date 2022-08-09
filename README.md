# WrapLikePagesExample

before building, delete connection string in App.config, also create data base and connect it's through ADO.NET to project.

sql code to create data base:
```sql
CREATE TABLE Phone (
	Id INT PRIMARY KEY IDENTITY,
	PhoneName NVARCHAR(255) NOT NULL,
	PhoneModel NVARCHAR(10) NOT NULL
);

INSERT Phone VALUES
	(N'Iphone', N'1'),
	(N'Iphone', N'2'),
	(N'Iphone', N'3'),
	(N'Iphone', N'4'),
	(N'Iphone', N'5'),
	(N'Iphone', N'6'),
	(N'Iphone', N'7'),
	(N'Iphone', N'8'),
	(N'Iphone', N'9'),
	(N'Iphone', N'10'),
	(N'Iphone', N'11'),
	(N'Iphone', N'12');

SELECT * FROM Phone;
```
