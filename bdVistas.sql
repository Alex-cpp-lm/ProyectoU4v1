


--  4 ------------------------------------

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

-- 5 -------------------------

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







-- 6 reporte


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

-- consultas
--  4
SELECT * FROM reporte_ventas_mes
WHERE MONTH(FechaCompleta) = 11 AND YEAR(FechaCompleta) = 2024;

-- 5
SELECT * FROM reporte_ventas_empleado
WHERE Periodo = '2024-11';

-- 6
SELECT * FROM reporte_ventas_trimestrales
WHERE Año = 2024;

