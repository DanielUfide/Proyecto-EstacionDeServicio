USE MASTER;
DROP DATABASE EL_CRUCE; 

CREATE DATABASE EL_CRUCE;
GO
USE EL_CRUCE;

CREATE TABLE ROLE_USUARIO(
	ID_ROLE INT NOT NULL IDENTITY CONSTRAINT PK_ROLE_USUARIO PRIMARY KEY,
	ROLE	VARCHAR(255) NOT NULL
)

CREATE TABLE USUARIO(
	ID_USUARIO			INT NOT NULL IDENTITY CONSTRAINT PK_USUARIO PRIMARY KEY, 
	ID_ROLE				INT NOT NULL, 
	NOMBRE				VARCHAR(100) NOT NULL, 
	CORREO				VARCHAR(100) NOT NULL, 
	CONTRASEŅA			VARCHAR(20) NOT NULL, 
	TELEFONO			VARCHAR(20) NOT NULL,
	ESTADO_CONTRASEŅA	BIT DEFAULT 1,
	CONSTRAINT FK_USUARIO_ROLE FOREIGN KEY (ID_ROLE) REFERENCES ROLE_USUARIO(ID_ROLE)
)

CREATE TABLE VEHICULO(
	PLACA		VARCHAR(10) NOT NULL CONSTRAINT PK_VEHICULO PRIMARY KEY, 
	MARCA		VARCHAR(10),
	MODELO		VARCHAR(10),
	CHASIS		VARCHAR(100),
	ESTADO      BIT NOT NULL,
	ID_USUARIO	INT NOT NULL, 
	CONSTRAINT FK_VEHICULO_USUARIO FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO (ID_USUARIO)  
)

CREATE TABLE ESTADO_SERVICIO(
	ID_ESTADO	INT NOT NULL IDENTITY CONSTRAINT PK_ESTADO_SERVICIO PRIMARY KEY, 
	ESTADO		VARCHAR(10) NOT NULL
)

CREATE TABLE SERVICIO (
	ID_SERVICIO	INT NOT NULL IDENTITY CONSTRAINT PK_SERVICIO PRIMARY KEY,
	SERVICIO	VARCHAR(50) NOT NULL, 
	DESCRIPCION	VARCHAR(100) NOT NULL, 		
	PRECIO		FLOAT NOT NULL, 
	ID_ESTADO	INT NOT NULL, 
	CONSTRAINT FK_SERVICIO_ESTADO FOREIGN KEY (ID_ESTADO) REFERENCES ESTADO_SERVICIO(ID_ESTADO)
)

CREATE TABLE ESTADO_PROYECTO(
	ID_ESTADO	INT NOT NULL IDENTITY CONSTRAINT PK_ESTADO_PROYECTO PRIMARY KEY,
	ESTADO		VARCHAR(100) NOT NULL
)
 

CREATE TABLE PROYECTO (
	ID_PROYECTO			INT NOT NULL IDENTITY CONSTRAINT PK_PROYECTO PRIMARY KEY, 
	ID_VEHICULO			VARCHAR(10) NOT NULL, 
	ID_ESTADO_PROYECTO	INT NOT NULL,
	ID_MECANICO			INT NOT NULL,
	FECHA				DATETIME NOT NULL,
	ESTADO_FACTURA		INT NOT NULL DEFAULT 0, --0,1 Pendiente,2 Aprobado
	CONSTRAINT FK_PROYECTO_VEHICULO FOREIGN KEY (ID_VEHICULO) REFERENCES VEHICULO(PLACA),
	CONSTRAINT FK_ESTADO_PROYECTO FOREIGN KEY (ID_ESTADO_PROYECTO) REFERENCES ESTADO_PROYECTO(ID_ESTADO),	
	CONSTRAINT FK_MECANICO_PROYECTO FOREIGN KEY (ID_MECANICO) REFERENCES USUARIO(ID_USUARIO)
)

CREATE TABLE PROVEEDOR (
	ID_PROVEEDOR	INT NOT NULL IDENTITY CONSTRAINT PK_PROVEEDOR PRIMARY KEY,
	NOMBRE			VARCHAR(50),
	DIRECCION		VARCHAR(255),
	CORREO			VARCHAR(50),
	NUMERO			VARCHAR(50)
)

CREATE TABLE CATEGORIA (
	ID_CATEGORIA	INT NOT NULL IDENTITY CONSTRAINT PK_CATEGORIA PRIMARY KEY, 
	ID_PROVEEDOR	INT NOT NULL, 
	CATEGORIA		VARCHAR(100),
	DESCRIPCION		VARCHAR(255)
	CONSTRAINT FK_PROVEEDOR_CATEGORIA FOREIGN KEY (ID_PROVEEDOR) REFERENCES PROVEEDOR (ID_PROVEEDOR) 
)

CREATE TABLE INVENTARIO (
	ID_INVENTARIO	INT NOT NULL IDENTITY CONSTRAINT PK_INVENTARIO PRIMARY KEY, 
	ID_CATEGORIA	INT NOT NULL, 
	CANTIDAD		INT NOT NULL, 
	PRECIO_COMPRA	FLOAT,
	PRECIO_VENTA	FLOAT
	CONSTRAINT FK_CATEGORIA_INVENTARIO FOREIGN KEY (ID_CATEGORIA) REFERENCES CATEGORIA (ID_CATEGORIA)
)

CREATE TABLE TIPO_COSTO(
	ID_TIPO_COSTO INT NOT NULL IDENTITY CONSTRAINT PK_TIPO_COSTO PRIMARY KEY, 
	DESCRIPCION	VARCHAR(10) NOT NULL
)

CREATE TABLE ESTADO_COSTO (
	ID_ESTADO_COSTO	INT NOT NULL IDENTITY CONSTRAINT PK_ESTADO_COSTO PRIMARY KEY, 
	DESCRIPCION	VARCHAR(10)
)

CREATE TABLE COSTO (
	ID_COSTO		INT NOT NULL IDENTITY CONSTRAINT PK_COSTO PRIMARY KEY, 
	ID_TIPO_COSTO	INT NOT NULL,
	ID_ESTADO_COSTO	INT NOT NULL, 
	MONTO_TOTAL		FLOAT NOT NULL
	CONSTRAINT FK_TIPO_COSTO FOREIGN KEY (ID_TIPO_COSTO) REFERENCES TIPO_COSTO(ID_TIPO_COSTO),
	CONSTRAINT FK_ESTADO_COSTO FOREIGN KEY (ID_ESTADO_COSTO) REFERENCES ESTADO_COSTO(ID_ESTADO_COSTO)
)

CREATE TABLE PROYECTO_PIEZAS (
	ID_SOLICITUD	INT NOT NULL IDENTITY CONSTRAINT PK_PROYECTO_PIEZAS PRIMARY KEY, 
	ID_PROYECTO		INT NOT NULL, 
	ID_INVENTARIO	INT NOT NULL, 
	ID_COSTO		INT NOT NULL,
	CANTIDAD		INT NOT NULL, 
	CONSTRAINT FK_PROYECTO_PIEZAS FOREIGN KEY (ID_PROYECTO) REFERENCES PROYECTO(ID_PROYECTO),
	CONSTRAINT FK_INVENTARIO_PIEZAS FOREIGN KEY (ID_INVENTARIO) REFERENCES INVENTARIO (ID_INVENTARIO),
	CONSTRAINT FK_COSTO_PIEZAS FOREIGN KEY (ID_COSTO) REFERENCES COSTO(ID_COSTO)
)

CREATE TABLE COMENTARIOS_PROYECTO(
	ID_COMENTARIO	INT NOT NULL IDENTITY CONSTRAINT PK_COMENTARIO_PROYECTO PRIMARY KEY, 
	ID_USUARIO		INT NOT NULL, 
	ID_PROYECTO		INT NOT NULL, 
	COMENTARIO		VARCHAR(255) NOT NULL, 
	FECHA			DATETIME,
	CONSTRAINT FK_USUARIO_COMENTARIOS FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO),
	CONSTRAINT FK_PROYECTO_COMENTARIOS	FOREIGN KEY (ID_PROYECTO) REFERENCES PROYECTO(ID_PROYECTO)
)

CREATE TABLE HISTORIAL_ESTADOS(
	ID_HISTORIAL_ESTADO	INT NOT NULL IDENTITY CONSTRAINT PK_HISTORIAL_ESTADO PRIMARY KEY, 
	ID_PROYECTO			INT NOT NULL, 
	ID_ESTADO			INT NOT NULL, 
	FECHA				DATETIME,
	CONSTRAINT FK_PROYECTO_HISTORIAL_ESTADO FOREIGN KEY (ID_PROYECTO) REFERENCES PROYECTO(ID_PROYECTO), 
	CONSTRAINT FK_ESTADO_HISTORIAL_ESTADO FOREIGN KEY (ID_ESTADO) REFERENCES ESTADO_PROYECTO(ID_ESTADO)
)

CREATE TABLE SERVICIO_PROYECTO(
	ID_SERVICIO_PROYECTO		INT NOT NULL IDENTITY CONSTRAINT PK_SERVICIO_PROYECTO PRIMARY KEY, 
	ID_SERVICIO			INT NULL, 
	ID_PROYECTO		INT NOT NULL, 
	FECHA				DATETIME,
	CONSTRAINT FK_SERVICIO_PROYECTO_ID_SERVICIO FOREIGN KEY (ID_SERVICIO) REFERENCES SERVICIO(ID_SERVICIO),
	CONSTRAINT FK_SERVICIO_PROYECTO_ID_PROYECTO FOREIGN KEY (ID_PROYECTO) REFERENCES PROYECTO(ID_PROYECTO),
)

CREATE TABLE FACTURA_CABECERA(
	ID_FACTURA_CABECERA		INT NOT NULL IDENTITY CONSTRAINT ID_FACTURA_CABECERA PRIMARY KEY, 
	NOMBRE	  VARCHAR(100) NULL, 
	DIRECCION VARCHAR(100) NOT NULL, 
	NUMERO VARCHAR(100) NOT NULL, 
	FECHA	  DATETIME,
	ID_CLIENTE INT,
	NOMBRE_CLIENTE	VARCHAR(100),
	NOMBRE_MECANICO VARCHAR(100),	
	TOTAL DECIMAL,
	ID_PROYECTO INT,
	APROBADO BIT NOT NULL DEFAULT 0,
	CONSTRAINT FK_FACTURA_CABECERA_ID_PROYECTO FOREIGN KEY (ID_PROYECTO) REFERENCES PROYECTO(ID_PROYECTO),

)


CREATE TABLE FACTURA_DETALLE(
	ID_FACTURA_DETALLE		INT NOT NULL IDENTITY CONSTRAINT ID_FACTURA_DETALLE PRIMARY KEY, 
	TIPO	  VARCHAR(1000) NULL, 
	DESCRIPCION VARCHAR(1000) NOT NULL,
	CANTIDAD INT NOT NULL,
	PRECIO DECIMAL NOT NULL,

	ID_FACTURA_CABECERA INT,
	CONSTRAINT FK_FACTURA_DETALLE_ID_FACTURA_CABECERA FOREIGN KEY (ID_FACTURA_CABECERA) REFERENCES FACTURA_CABECERA(ID_FACTURA_CABECERA),
)

CREATE TABLE PRODUCTO_PROYECTO(
	ID_PRODUCTO_PROYECTO		INT NOT NULL IDENTITY CONSTRAINT PK_PRODUCTO_PROYECTO PRIMARY KEY, 
	ID_INVENTARIO			INT NULL, 
	ID_PROYECTO		INT NOT NULL, 
	CANTIDAD				INT,
	FECHA				DATETIME,
	CONSTRAINT FK_SERVICIO_PROYECTO_ID_INVENTARIO FOREIGN KEY (ID_INVENTARIO) REFERENCES INVENTARIO(ID_INVENTARIO),
	CONSTRAINT FK_PRODUCTO_PROYECTO_ID_PROYECTO FOREIGN KEY (ID_PROYECTO) REFERENCES PROYECTO(ID_PROYECTO),
)


--INSERT INTO CATEGORIA (ID_CATEGORIA, ID_PROVEEDOR, CATEGORIA, DESCRIPCION) VALUES (1, 1 ,'Lubricantes','Lubricantes');
--GO

--INSERT INTO PROVEEDOR(ID_PROVEEDOR, NOMBRE, DIRECCION, CORREO, NUMERO)VALUES (2, 'Rodrigo Solis' ,'Heredia','rodrigos@gmail.com', 85475263);
--GO

