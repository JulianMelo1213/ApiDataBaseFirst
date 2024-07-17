create database ApiDataBaseFirts

use ApiDataBaseFirts


CREATE TABLE Clientes (
    ID_Cliente INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Direccion VARCHAR(255),
    Telefono VARCHAR(20)
);

CREATE TABLE Facturas (
    ID_Factura INT PRIMARY KEY,
    Fecha DATE,
    ID_Cliente INT,
    FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID_Cliente)
);

CREATE TABLE Proveedores (
    ID_Proveedor INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Direccion VARCHAR(255),
    Telefono VARCHAR(20)
);

CREATE TABLE Categorias (
    ID_Categoria INT PRIMARY KEY,
    Descripcion VARCHAR(100)
);

CREATE TABLE Productos (
    ID_Producto INT PRIMARY KEY,
    Descripcion VARCHAR(100),
    Precio DECIMAL(10, 2),
    ID_Categoria INT,
    ID_Proveedor INT,
    FOREIGN KEY (ID_Categoria) REFERENCES Categorias(ID_Categoria),
    FOREIGN KEY (ID_Proveedor) REFERENCES Proveedores(ID_Proveedor)
);

CREATE TABLE Ventas (
    ID_Venta INT PRIMARY KEY,
    ID_Factura INT,
    ID_Producto INT,
    Cantidad INT,
    FOREIGN KEY (ID_Factura) REFERENCES Facturas(ID_Factura),
    FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto)
);

-- Inserciones para la tabla Clientes
INSERT INTO Clientes (ID_Cliente, Nombre, Direccion, Telefono)
VALUES 
(1, 'Juan Perez', '123 Calle Falsa', '1234567890'),
(2, 'Maria Gomez', '456 Avenida Siempre Viva', '0987654321'),
(3, 'Pedro Martinez', '789 Calle Luna', '1122334455');

-- Inserciones para la tabla Proveedores
INSERT INTO Proveedores (ID_Proveedor, Nombre, Direccion, Telefono)
VALUES 
(1, 'Proveedor A', '111 Calle Sol', '1231231234'),
(2, 'Proveedor B', '222 Calle Estrella', '4564564567'),
(3, 'Proveedor C', '333 Calle Nube', '7897897890');

-- Inserciones para la tabla Categorias
INSERT INTO Categorias (ID_Categoria, Descripcion)
VALUES 
(1, 'Electrónica'),
(2, 'Ropa'),
(3, 'Alimentos');

-- Inserciones para la tabla Productos
INSERT INTO Productos (ID_Producto, Descripcion, Precio, ID_Categoria, ID_Proveedor)
VALUES 
(1, 'Televisor', 499.99, 1, 1),
(2, 'Pantalones', 29.99, 2, 2),
(3, 'Manzanas', 0.99, 3, 3);

-- Inserciones para la tabla Facturas
INSERT INTO Facturas (ID_Factura, Fecha, ID_Cliente)
VALUES 
(1, '2024-01-01', 1),
(2, '2024-02-01', 2),
(3, '2024-03-01', 3);

-- Inserciones para la tabla Ventas
INSERT INTO Ventas (ID_Venta, ID_Factura, ID_Producto, Cantidad)
VALUES 
(1, 1, 1, 2),
(2, 1, 3, 10),
(3, 2, 2, 5),
(4, 3, 1, 1),
(5, 3, 2, 3);
