CREATE DATABASE SC701_PRACTICA3;
GO

USE SC701_PRACTICA3;
GO

CREATE TABLE VEHICULO(
	Id_Vehiculo UNIQUEIDENTIFIER PRIMARY KEY, --ES UN GUID
	Placa NVARCHAR(8) UNIQUE NOT NULL,
	Kilometraje INT NOT NULL,
	Color NVARCHAR(30) NOT NULL,
	Anio INT NOT NULL,
	Marca NVARCHAR(30) NOT NULL,
	Modelo NVARCHAR(30) NOT NULL,
	Cilindrada INT NULL,
	CapacidadPasajeros INT NULL
);
GO

INSERT INTO VEHICULO (Id_Vehiculo, Placa, Kilometraje, Color, Anio, Marca, Modelo, Cilindrada, CapacidadPasajeros)
VALUES ('D8E77E6F-1F39-4F4C-9F88-6D6FABE4A4C1', 'ABC123', 85420, 'Gris', 2015, 'Toyota', 'Corolla', 1800, 5);
GO

INSERT INTO VEHICULO (Id_Vehiculo, Placa, Kilometraje, Color, Anio, Marca, Modelo, Cilindrada, CapacidadPasajeros)
VALUES ('3A1B556B-8C34-4A82-B0E2-9AF95DA323E2', 'BCD456', 41200, 'Blanco', 2018, 'Hyundai', 'Tucson', 2000, 5);
GO

INSERT INTO VEHICULO (Id_Vehiculo, Placa, Kilometraje, Color, Anio, Marca, Modelo, Cilindrada, CapacidadPasajeros)
VALUES ('01F9968B-85E3-4E2E-B6D8-F380BE5F52C8', 'EFG789', 129500, 'Negro', 2012, 'Honda', 'Civic', 1800, 5);
GO
INSERT INTO VEHICULO (Id_Vehiculo, Placa, Kilometraje, Color, Anio, Marca, Modelo, Cilindrada, CapacidadPasajeros)
VALUES ('A9907EE3-070A-4B60-A35C-637D4E5B57F4', 'XYZ321', 25300, 'Rojo', 2021, 'Nissan', 'X-Trail', 2500, 7);
GO