CREATE DATABASE ERP_Farmacia;
GO

USE ERP_Farmacia;
GO

CREATE TABLE Rol(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL
);
INSERT INTO Rol (Nombre) VALUES
('Administrador'),
('Vendedor'),
('Farmacéutico'),
('Almacén'),
('Supervisor');
CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    PasswordHash NVARCHAR(200),
    Activo BIT,
    RolId INT,
    FOREIGN KEY (RolId) REFERENCES Rol(Id)
);
INSERT INTO Usuario (Nombre, Email, PasswordHash, Activo, RolId) VALUES
('Juan Pérez', 'admin@farmacia.com', '123456', 1, 1),
('María López', 'ventas@farmacia.com', '123456', 1, 2),
('Carlos Ruiz', 'farma@farmacia.com', '123456', 1, 3),
('Ana Torres', 'almacen@farmacia.com', '123456', 1, 4),
('Luis Gómez', 'supervisor@farmacia.com', '123456', 0, 5);
CREATE TABLE Auditoria (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT,
    Accion NVARCHAR(50),
    Modulo NVARCHAR(50),
    Fecha DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
);
INSERT INTO Auditoria (UsuarioId, Accion, Modulo, Fecha) VALUES
(1, 'LOGIN', 'SEGURIDAD', GETDATE()),
(2, 'LOGIN', 'SEGURIDAD', GETDATE()),
(3, 'LOGIN', 'SEGURIDAD', GETDATE()),
(1, 'LOGOUT', 'SEGURIDAD', GETDATE()),
(4, 'LOGIN', 'SEGURIDAD', GETDATE());

SELECT *FROM USUARIO;
SELECT *FROM ROL;
SELECT *FROM AUDITORIA;