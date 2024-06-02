IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DBRadar')
BEGIN
  CREATE DATABASE DBRadar;
END;
GO

use DBRadar; 

if exists (SELECT * FROM dbo.SYSOBJECTS WHERE XTYPE = 'U' AND NAME = 'Radar')
	drop table Radar;
GO

CREATE TABLE Radar(

    concessionaria VARCHAR(255), 
    ano_do_pnv_snv INT,
    tipo_de_radar VARCHAR(255),
    rodovia VARCHAR(255),
    uf VARCHAR(255),
    km_m VARCHAR(255),
    municipio VARCHAR(255),
    tipo_pista VARCHAR(255),
    sentido VARCHAR(255),
    situacao VARCHAR(255),
    data_da_inativacao DATE,
    latitude REAL,
    longitude REAL,
    velocidade_leve INT
);

SELECT * FROM Radar;
