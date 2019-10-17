
CREATE TABLE clientes (
    tipo_documento     VARCHAR(2) NOT NULL,
    documento          INTEGER NOT NULL,
    primer_nombre      VARCHAR(30) NOT NULL,
    segundo_nombre     VARCHAR(30),
    primer_apellido    VARCHAR(30) NOT NULL,
    segundo_apellido   VARCHAR(30),
    celular            VARCHAR(10) NOT NULL,
    direccion          VARCHAR(200) NOT NULL,
    email              VARCHAR(100) NOT NULL
);


ALTER TABLE clientes ADD CONSTRAINT clientes_pk PRIMARY KEY ( documento,
                                                              tipo_documento );

CREATE TABLE fotos (
    codigo              INTEGER NOT NULL,
    ruta                VARCHAR(200),
    cod_mantenimiento   INTEGER NOT NULL
);

ALTER TABLE fotos ADD CONSTRAINT fotos_pk PRIMARY KEY ( codigo );

CREATE TABLE mantenimientos (
    codigo               INTEGER NOT NULL,
    estado               INTEGER,
    cod_placa            VARCHAR(6) NOT NULL,
    fecha                DATE NOT NULL,
    mec_documento        INTEGER NOT NULL,
    mec_tipo_documento   VARCHAR(2) NOT NULL
);


ALTER TABLE mantenimientos ADD CONSTRAINT mtos_pk PRIMARY KEY ( codigo );

CREATE TABLE marcas (
    codigo         INTEGER NOT NULL,
    nombre_marca   VARCHAR(30) NOT NULL
);

ALTER TABLE marcas ADD CONSTRAINT marcas_pk PRIMARY KEY ( codigo );

CREATE TABLE mecanicos (
    tipo_documento     VARCHAR(2) NOT NULL,
    documento          INTEGER NOT NULL,
    primer_nombre      VARCHAR(30) NOT NULL,
    segundo_nombre     VARCHAR(30),
    primer_apellido    VARCHAR(30) NOT NULL,
    segundo_apellido   VARCHAR(30),
    celular            VARCHAR(10) NOT NULL,
    direccion          VARCHAR(200) NOT NULL,
    email              VARCHAR(100) NOT NULL,
    estado             CHAR(1) NOT NULL
);


ALTER TABLE mecanicos ADD CONSTRAINT mecanicos_pk PRIMARY KEY ( documento,
                                                                tipo_documento );

CREATE TABLE repuestos (
    codigo                INTEGER NOT NULL,
    nombre_repuesto       VARCHAR(100) NOT NULL,
    precio_unitario       numeric(18,0) NOT NULL,
    unidades_inventario   INTEGER NOT NULL,
    proveedor             VARCHAR(300) NOT NULL
);

ALTER TABLE repuestos ADD CONSTRAINT repuestos_pk PRIMARY KEY ( codigo );

CREATE TABLE repuestos_x_mantenimientos (
    codigo              INTEGER NOT NULL,
    unidades            INTEGER NOT NULL,
    tiempo_estimado     INTEGER NOT NULL,
    cod_mantenimiento   INTEGER NOT NULL,
    cod_repuesto        INTEGER NOT NULL
);



ALTER TABLE repuestos_x_mantenimientos ADD CONSTRAINT rep_x_mtos_pk PRIMARY KEY ( codigo );

CREATE TABLE servicios (
    codigo            INTEGER NOT NULL,
    nombre_servicio   VARCHAR(100) NOT NULL,
    precio            numeric(18,0) NOT NULL
);

ALTER TABLE servicios ADD CONSTRAINT servicios_pk PRIMARY KEY ( codigo );

CREATE TABLE servicios_x_mantenimientos (
    codigo              INTEGER NOT NULL,
    tiempo_estimado     INTEGER NOT NULL,
    cod_servicio        INTEGER NOT NULL,
    cod_mantenimiento   INTEGER NOT NULL
);



ALTER TABLE servicios_x_mantenimientos ADD CONSTRAINT servicios_x_mto_pk PRIMARY KEY ( codigo );

CREATE TABLE vehiculos (
    placa                VARCHAR(6) NOT NULL,
    color                VARCHAR(30) NOT NULL,
    cod_marca            INTEGER NOT NULL,
    cli_documento        INTEGER NOT NULL,
    cli_tipo_documento   VARCHAR(2) NOT NULL
);

ALTER TABLE vehiculos ADD CONSTRAINT vehiculos_pk PRIMARY KEY ( placa );

ALTER TABLE fotos
    ADD CONSTRAINT fotos_man_fk FOREIGN KEY ( cod_mantenimiento )
        REFERENCES mantenimientos ( codigo );

ALTER TABLE mantenimientos
    ADD CONSTRAINT man_vehiculos_fk FOREIGN KEY ( cod_placa )
        REFERENCES vehiculos ( placa );

ALTER TABLE mantenimientos
    ADD CONSTRAINT mantenimientos_mecanicos_fk FOREIGN KEY ( mec_documento,
                                                             mec_tipo_documento )
        REFERENCES mecanicos ( documento,
                               tipo_documento );

ALTER TABLE repuestos_x_mantenimientos
    ADD CONSTRAINT rep_x_man_rep_fk FOREIGN KEY ( cod_repuesto )
        REFERENCES repuestos ( codigo );

ALTER TABLE repuestos_x_mantenimientos
    ADD CONSTRAINT rep_x_mtos_man_fk FOREIGN KEY ( cod_mantenimiento )
        REFERENCES mantenimientos ( codigo );

ALTER TABLE servicios_x_mantenimientos
    ADD CONSTRAINT ser_x_man_man_fk FOREIGN KEY ( cod_mantenimiento )
        REFERENCES mantenimientos ( codigo );

ALTER TABLE servicios_x_mantenimientos
    ADD CONSTRAINT ser_x_man_ser_fk FOREIGN KEY ( cod_servicio )
        REFERENCES servicios ( codigo );

ALTER TABLE vehiculos
    ADD CONSTRAINT vehiculos_clientes_fk FOREIGN KEY ( cli_documento,
                                                       cli_tipo_documento )
        REFERENCES clientes ( documento,
                              tipo_documento );

ALTER TABLE vehiculos
    ADD CONSTRAINT vehiculos_marcas_fk FOREIGN KEY ( cod_marca )
        REFERENCES marcas ( codigo );

