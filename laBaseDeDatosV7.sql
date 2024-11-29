-- Eliminar base de datos si existe y crear una nueva
DROP DATABASE IF EXISTS tiendau4;
CREATE DATABASE tiendau4;
USE tiendau4;

-- Crear las tablas necesarias
CREATE TABLE Empleados (
    idEmpleado INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    usuario CHAR(30) NOT NULL,
    pass VARCHAR(256) NOT NULL,
    salario FLOAT(2) NOT NULL,
    foto VARCHAR(1000)
);

CREATE TABLE Clientes (
    idCliente INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    direccion VARCHAR(100) NOT NULL
);

CREATE TABLE marca (
    idMarca INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(30) NOT NULL,
    logo VARCHAR(1000)
);

CREATE TABLE Productos (
    idProducto INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(30) NOT NULL,
    codigo CHAR(12) NOT NULL,
    precio DECIMAL(3) NULL,
    descripcion VARCHAR(200) NOT NULL,
    cantidad INT NOT NULL,
    idMarca INT NOT NULL,
    imagen VARCHAR(1000),
    FOREIGN KEY (idMarca) REFERENCES marca(idMarca)
);

CREATE TABLE ventas (
    idVenta INT PRIMARY KEY AUTO_INCREMENT,
    idCliente INT NULL,
    descripcion VARCHAR(100),
    total FLOAT(2) NOT NULL,
    fecha DATETIME NOT NULL,
    idEmpleado INT NOT NULL,
    FOREIGN KEY (idEmpleado) REFERENCES empleados(idEmpleado),
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente)
);

CREATE TABLE detalles_ventas (
    idProducto INT NOT NULL,
    idVenta INT NOT NULL,
    cantidad INT NOT NULL,
    precioVenta FLOAT(2),
    FOREIGN KEY (idProducto) REFERENCES productos(idProducto),
    FOREIGN KEY (idVenta) REFERENCES ventas(idVenta)
);

-- Crear procedimientos almacenados para insertar ventas y detalles de ventas

DELIMITER $$

-- Procedimiento para insertar una venta
CREATE PROCEDURE insertar_venta(
    IN p_idCliente INT,
    IN p_descripcion VARCHAR(100),
    IN p_total FLOAT(2),
    IN p_fecha DATETIME,
    IN p_idEmpleado INT
)
BEGIN
    -- Insertar la venta en la tabla ventas
    INSERT INTO ventas (idCliente, descripcion, total, fecha, idEmpleado)
    VALUES (p_idCliente, p_descripcion, p_total, p_fecha, p_idEmpleado);
END $$

-- Procedimiento para insertar detalles de la venta
CREATE PROCEDURE insertar_detalles_venta(
    IN p_idVenta INT,
    IN p_idProducto INT,
    IN p_cantidad INT,
    IN p_precioVenta FLOAT(2)
)
BEGIN
    -- Insertar los detalles de la venta en la tabla detalles_ventas
    INSERT INTO detalles_ventas (idVenta, idProducto, cantidad, precioVenta)
    VALUES (p_idVenta, p_idProducto, p_cantidad, p_precioVenta);
END $$

DELIMITER ;

-- Insertar datos iniciales en las tablas de ejemplo

-- Insertar marcas
INSERT INTO marca (Nombre, logo) VALUES ('Coca-Cola', '');
INSERT INTO marca (Nombre, logo) VALUES ('Pepsi', '');
INSERT INTO marca (Nombre, logo) VALUES ('Nestlé', '');
INSERT INTO marca (Nombre, logo) VALUES ('Bimbo', '');
INSERT INTO marca (Nombre, logo) VALUES ('Lala', '');
INSERT INTO marca (Nombre, logo) VALUES ('Colgate', '');
INSERT INTO marca (Nombre, logo) VALUES ('Procter & Gamble', '');
INSERT INTO marca (Nombre, logo) VALUES ('Unilever', '');
INSERT INTO marca (Nombre, logo) VALUES ('Peñafiel', '');
INSERT INTO marca (Nombre, logo) VALUES ('Herdez', '');

-- Insertar productos para Coca-Cola (idMarca = 1)
INSERT INTO productos (nombre, codigo, descripcion, cantidad, idMarca, imagen, precio) 
VALUES 
('Coca-Cola 600ml', '000000000001', 'Refresco Coca-Cola 600ml', 100, 1, 'https://supermode.com.mx/cdn/shop/products/100001337_4be2fa42-a15d-4539-a584-385823b5cfce.jpg?v=1698797211', 15.00),
('Coca-Cola 2L', '000000000002', 'Refresco Coca-Cola 2L', 50, 1, 'https://www.movil.farmaciasguadalajara.com/wcsstore/FGCAS/wcs/products/302546_A_1280_AL.jpg', 30.00),
('Fanta 600ml', '000000000003', 'Refresco sabor naranja Fanta 600ml', 60, 1, '', 14.00),
('Sprite 600ml', '000000000004', 'Refresco sabor lima-limón Sprite 600ml', 80, 1, '', 15.00);

-- Insertar productos para Pepsi (idMarca = 2)
INSERT INTO productos (nombre, codigo, descripcion, cantidad, idMarca, imagen, precio) 
VALUES 
('Pepsi 600ml', '000000000005', 'Refresco Pepsi 600ml', 100, 2, '', 14.00),
('Pepsi 2L', '000000000006', 'Refresco Pepsi 2L', 50, 2, '', 28.00),
('7Up 600ml', '000000000007', 'Refresco sabor lima-limón 7Up 600ml', 70, 2, '', 14.00),
('Mirinda 600ml', '000000000008', 'Refresco sabor naranja Mirinda 600ml', 60, 2, '', 14.00);

-- Insertar empleados
INSERT INTO empleados (nombre, apellido, usuario, pass, salario, foto) 
VALUES 
("Alexander", "Lopez Mora", "root", SHA2('root', 256), 3260, "https://www.ngenespanol.com/wp-content/uploads/2024/08/cual-es-la-diferencia-entre-un-dinosaurio-y-un-reptil-prehistorico-770x431.jpg");

-- Insertar cliente
INSERT INTO clientes (nombre, apellido, direccion) 
VALUES ('Alexander', 'Lopez Mora', 'Diego Lopez #418');

DELIMITER $$

-- Función para insertar datos aleatorios de detalles de ventas
CREATE PROCEDURE insertar_detalles_ventas_aleatorios(IN numDetalles INT)
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE idVenta INT;
    DECLARE idProducto INT;
    DECLARE cantidad INT;
    DECLARE precioVenta FLOAT(2);
    
    -- Bucle para insertar 'numDetalles' registros
    WHILE i < numDetalles DO
        -- Generar ID de venta aleatorio entre 1 y el máximo de ventas
        SET idVenta = FLOOR(1 + (RAND() * (SELECT COUNT(*) FROM ventas)));

        -- Generar ID de producto aleatorio entre 1 y el máximo de productos
        SET idProducto = FLOOR(1 + (RAND() * (SELECT COUNT(*) FROM productos)));

        -- Generar cantidad aleatoria entre 1 y 10
        SET cantidad = FLOOR(1 + (RAND() * 10));

        -- Generar precio de venta aleatorio entre 10 y 100
        SET precioVenta = 10 + (RAND() * 90);

        -- Insertar el detalle de venta generado
        INSERT INTO detalles_ventas (idVenta, idProducto, cantidad, precioVenta)
        VALUES (idVenta, idProducto, cantidad, precioVenta);

        -- Incrementar el contador
        SET i = i + 1;
    END WHILE;
END $$

DELIMITER ;
-- PUNTO 3 PROCEDIMIENTOS ALMACENADOS 
-- 3. Ejecución del procedimiento almacenado para insertar ventas (se asume que ya tienes un procedimiento almacenado creado)
-- Aquí se ejecuta el stored procedure para insertar ventas, realizando pruebas con diferentes cantidades de ventas.
CALL insertar_venta(1, 'Venta de productos Coca-Cola', 90.00, '2024-11-28 14:00:00', 1);
CALL insertar_detalles_venta(1, 1, 3, 15.00);  -- 3 Coca-Colas 600ml
CALL insertar_detalles_venta(1, 2, 2, 30.00);  -- 2 Coca-Colas 2L
CALL insertar_detalles_ventas_aleatorios(2500);
-- 4. Reporte de ventas por mes: Usaremos una vista para generar el reporte de ventas por mes

CREATE VIEW reporte_ventas_mes AS
SELECT
    v.idVenta AS Folio,
    v.fecha AS FechaCompleta, -- Fecha sin formatear
    DATE_FORMAT(v.fecha, '%d/%m/%Y') AS Fecha,
    c.nombre AS Cliente,
    e.nombre AS Empleado,
    v.total AS Total,
    COUNT(d.idProducto) AS Cantidad
FROM ventas v
JOIN clientes c ON v.idCliente = c.idCliente
JOIN empleados e ON v.idEmpleado = e.idEmpleado
JOIN detalles_ventas d ON v.idVenta = d.idVenta
GROUP BY v.idVenta;



SELECT * FROM reporte_ventas_mes
WHERE MONTH(FechaCompleta) = 11 AND YEAR(FechaCompleta) = 2024;






-- Reporte de ventas por mes en noviembre 2024 (lo puedes consultar con un SELECT)
SELECT * FROM reporte_ventas_mes;

-- 5. Reporte de ventas por empleado: Usaremos una vista para generar el reporte de ventas por empleado

CREATE VIEW reporte_ventas_empleado AS
SELECT
    e.nombre AS Empleado,
    DATE_FORMAT(v.fecha, '%Y-%m') AS Periodo, -- Formatear la fecha para obtener el mes y año
    SUM(v.total) AS TotalVentas,
    COUNT(v.idVenta) AS CantidadVentas
FROM ventas v
JOIN empleados e ON v.idEmpleado = e.idEmpleado
GROUP BY e.nombre, Periodo;

SELECT * FROM reporte_ventas_empleado;
SELECT * FROM reporte_ventas_empleado
WHERE Periodo = '2024-11';


-- Reporte de ventas por empleado en noviembre 2024 (lo puedes consultar con un SELECT)
SELECT * FROM reporte_ventas_empleado;
DELIMITER //

-- Trigger de Auditoría para INSERT
CREATE TRIGGER auditoria_ventas_insert
AFTER INSERT ON ventas
FOR EACH ROW
BEGIN
    -- Insertar en la tabla de auditoría
    INSERT INTO auditoria (tabla, accion, fecha, usuario)
    VALUES ('ventas', 'INSERT', NOW(), 'usuario_ejemplo');  -- Aquí 'usuario_ejemplo' debe ser el usuario real o variable
END;
//

-- Trigger de Auditoría para UPDATE
CREATE TRIGGER auditoria_ventas_update
AFTER UPDATE ON ventas
FOR EACH ROW
BEGIN
    -- Insertar en la tabla de auditoría
    INSERT INTO auditoria (tabla, accion, fecha, usuario)
    VALUES ('ventas', 'UPDATE', NOW(), 'usuario_ejemplo');  -- Aquí 'usuario_ejemplo' debe ser el usuario real o variable
END;
//

-- Trigger de Auditoría para DELETE
CREATE TRIGGER auditoria_ventas_delete
AFTER DELETE ON ventas
FOR EACH ROW
BEGIN
    -- Insertar en la tabla de auditoría
    INSERT INTO auditoria (tabla, accion, fecha, usuario)
    VALUES ('ventas', 'DELETE', NOW(), 'usuario_ejemplo');  -- Aquí 'usuario_ejemplo' debe ser el usuario real o variable
END;
//

-- Trigger de Validación para INSERT en productos
CREATE TRIGGER validar_producto_insert
BEFORE INSERT ON productos
FOR EACH ROW
BEGIN
    -- Validar que el precio no sea negativo
    IF NEW.precio < 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El precio del producto no puede ser negativo';
    END IF;

    -- Validar que el nombre no esté vacío (no solo espacios en blanco)
    IF TRIM(NEW.nombre) = '' THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El nombre del producto no puede estar vacío';
    END IF;

    -- Validar que el código de barras tenga entre 8 y 20 caracteres
    IF NEW.codigo IS NOT NULL AND (LENGTH(NEW.codigo) < 8 OR LENGTH(NEW.codigo) > 20) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El código de barras debe tener entre 8 y 20 caracteres';
    END IF;
END;
//

-- Trigger de Validación para UPDATE en productos
CREATE TRIGGER validar_producto_update
BEFORE UPDATE ON productos
FOR EACH ROW
BEGIN
    -- Validar que el precio no sea negativo
    IF NEW.precio < 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El precio del producto no puede ser negativo';
    END IF;

    -- Validar que el nombre no esté vacío (no solo espacios en blanco)
    IF TRIM(NEW.nombre) = '' THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El nombre del producto no puede estar vacío';
    END IF;

    -- Validar que el código de barras tenga entre 8 y 20 caracteres
    IF NEW.codigo IS NOT NULL AND (LENGTH(NEW.codigo) < 8 OR LENGTH(NEW.codigo) > 20) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El código de barras debe tener entre 8 y 20 caracteres';
    END IF;
END;
//

DELIMITER ;

-- 6. Reporte comparativo de ventas por un determinado producto a lo largo de cada uno de los trimestres de un año

CREATE VIEW reporte_ventas_trimestrales AS
SELECT
    p.nombre AS Producto,
    YEAR(v.fecha) AS Año, -- Incluir la columna Año para el filtro
    SUM(CASE WHEN QUARTER(v.fecha) = 1 THEN d.cantidad ELSE 0 END) AS Trimestre1,
    SUM(CASE WHEN QUARTER(v.fecha) = 2 THEN d.cantidad ELSE 0 END) AS Trimestre2,
    SUM(CASE WHEN QUARTER(v.fecha) = 3 THEN d.cantidad ELSE 0 END) AS Trimestre3,
    SUM(CASE WHEN QUARTER(v.fecha) = 4 THEN d.cantidad ELSE 0 END) AS Trimestre4
FROM detalles_ventas d
JOIN productos p ON d.idProducto = p.idProducto
JOIN ventas v ON d.idVenta = v.idVenta
GROUP BY p.nombre, Año;


SELECT * FROM reporte_ventas_trimestrales
WHERE Año = 2024;

-- Reporte comparativo de ventas trimestrales por producto (lo puedes consultar con un SELECT)
SELECT * FROM reporte_ventas_trimestrales;