create database CRUD_EJEMPLO;
GO

USE CRUD_EJEMPLO;
GO

CREATE TABLE CLIENTE (
	CLIENTE_ID INT PRIMARY KEY,
	NOMBRE_CLIENTE VARCHAR(60) NOT NULL,
	DOMICILIO_CLIENTE VARCHAR(200) NOT NULL
);
GO

CREATE TABLE CLIENTE_CONTACTOS (
	CONTACTO_ID INT NOT NULL,
	CLIENTE_ID INT NOT NULL,
	NUMERO_CONTACTO INT NOT NULL,
	PRIMARY KEY (CONTACTO_ID),
	FOREIGN KEY (CLIENTE_ID) REFERENCES CLIENTE (CLIENTE_ID)
);
GO

