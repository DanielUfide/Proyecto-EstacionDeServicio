use EL_CRUCE;
go

ALTER TABLE PROYECTO 
ADD FECHA DATETIME;

-- Para que E.F no muestre error en el modelo, usando en InventarioModel
ALTER TABLE INVENTARIO
ADD NOMBRE VARCHAR(100);
