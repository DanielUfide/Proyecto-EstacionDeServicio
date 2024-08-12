use EL_CRUCE;
go

-- Para que E.F no muestre error en el modelo, usando en InventarioModel
ALTER TABLE INVENTARIO
ADD NOMBRE VARCHAR(100);
