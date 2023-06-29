CREATE PROCEDURE [dbo].[CreateContact]
	@ln VARCHAR(50),
	@fn VARCHAR(50),
	@email VARCHAR(50)
AS
	INSERT INTO Contact (Firstname, Lastname, email)
	VALUES (@fn, @ln, @email)

