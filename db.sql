CREATE TABLE Estudiante(
	id			INT PRIMARY KEY IDENTITY(1,1),
	nombre		VARCHAR(25) NOT NULL,
	apellido	VARCHAR(25) NOT NULL,
	edad		INT NOT NULL,
	direccion	VARCHAR(50),
	telefono	VARCHAR(50)
);


INSERT INTO Estudiante VALUES ('Prueba','ApellidoPrueba',24,'Guatemala','2222-2222');

SELECT * FROM Estudiante;