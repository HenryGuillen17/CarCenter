

    CREATE TABLE facturas
    (
        codigo             VARCHAR(20) NOT NULL,
        cli_documento      INTEGER     NOT NULL,
        cli_tipo_documento VARCHAR(2)  NOT NULL,
        fecha_factura      DATETIME    NOT NULL
    );
    ALTER TABLE facturas
        ADD CONSTRAINT facturas_pk PRIMARY KEY (codigo);

    CREATE TABLE facturas_detalles
    (
        fac_codigo   VARCHAR(20)    NOT NULL,
        man_codigo   INTEGER        NOT NULL,
        subtotal     NUMERIC(18, 0) NOT NULL,
        descuento    NUMERIC(3, 2)  NOT NULL,
        iva_aniadido NUMERIC(18, 0) NOT NULL,
        total        NUMERIC(18, 0) NOT NULL
    );
    ALTER TABLE facturas_detalles
        ADD CONSTRAINT facturas_detalles_pk PRIMARY KEY (fac_codigo, man_codigo);

    ALTER TABLE facturas_detalles
        ADD CONSTRAINT facturas_detalles_facturas_fk FOREIGN KEY (fac_codigo) REFERENCES facturas (codigo);

    ALTER TABLE facturas_detalles
        ADD CONSTRAINT facturas_detalles_mantenimientos_fk FOREIGN KEY (man_codigo) REFERENCES mantenimientos (codigo);

    ALTER TABLE mantenimientos
        ADD presupuesto_limite NUMERIC(18, 0) NULL;

    ALTER TABLE servicios_x_mantenimientos
        ADD precio_final NUMERIC(18, 0) NULL;
	
	GO

    UPDATE t
    SET t.precio_final = s.precio
    FROM servicios_x_mantenimientos t
             JOIN servicios s on t.cod_servicio = s.codigo;

    ALTER TABLE servicios_x_mantenimientos
        ALTER COLUMN precio_final NUMERIC(18, 0) NOT NULL;
    
	ALTER TABLE servicios
        ADD precio_minimo NUMERIC(18, 0) NULL;
    ALTER TABLE servicios
        ADD precio_maximo NUMERIC(18, 0) NULL;
	
	GO

    UPDATE servicios
    SET precio_minimo = precio,
        precio_maximo = precio;

    ALTER TABLE servicios
        ALTER COLUMN precio_minimo NUMERIC(18, 0) NOT NULL;
    ALTER TABLE servicios
        ALTER COLUMN precio_maximo NUMERIC(18, 0) NOT NULL;

