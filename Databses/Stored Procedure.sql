ALTER PROCEDURE Operations
(
@Action VARCHAR (20),
@Id int =0,
@Name VARCHAR(50) = null,      
@Gender VARCHAR (10) = null,      
@City VARCHAR (50) = null,      
@DateOfBirth DATETIME = null
)
AS

BEGIN
	IF @Action = 'spGetAllEmployees'
	BEGIN
		Select Id, Name, Gender, City, DateOfBirth  
		from tblEmployee  
	END

	IF @Action = 'spAddEmployee'
	BEGIN
		Insert into tblEmployee (Name, Gender, City, DateOfBirth)      
		Values (@Name, @Gender, @City, @DateOfBirth)
	END

	IF @Action = 'spUpdateEmployee'
	BEGIN
		Update tblEmployee Set
			 Name = @Name,
			 Gender = @Gender,
			 City = @City,
			 DateOfBirth = @DateOfBirth
			 Where Id = @Id
	END

	IF @Action = 'spDeleteEmployee'
	BEGIN
		DELETE FROM tblEmployee where Id = @Id
	END

END
