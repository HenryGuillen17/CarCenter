CREATE PROCEDURE [dbo].[mecanicos_sp_crear](@tipo_documento VARCHAR(2),
                                            @documento INTEGER,
                                            @primer_nombre VARCHAR(30),
                                            @segundo_nombre VARCHAR(30),
                                            @primer_apellido VARCHAR(30),
                                            @segundo_apellido VARCHAR(30),
                                            @celular VARCHAR(10),
                                            @direccion VARCHAR(200),
                                            @email VARCHAR(100),
                                            @estado CHAR(1))
AS

BEGIN
    SET NOCOUNT ON;

    INSERT INTO mecanicos(tipo_documento, documento, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido,
                          celular, direccion, email, estado)
    values (@tipo_documento, @documento, @primer_nombre, @segundo_nombre, @primer_apellido, @segundo_apellido, @celular,
            @direccion, @email, @estado);


END
GO

CREATE PROCEDURE [dbo].[mecanicos_sp_actualizar](@tipo_documento VARCHAR(2),
                                                 @documento INTEGER,
                                                 @primer_nombre VARCHAR(30),
                                                 @segundo_nombre VARCHAR(30),
                                                 @primer_apellido VARCHAR(30),
                                                 @segundo_apellido VARCHAR(30),
                                                 @celular VARCHAR(10),
                                                 @direccion VARCHAR(200),
                                                 @email VARCHAR(100),
                                                 @estado CHAR(1))
AS

BEGIN
    SET NOCOUNT ON;

    UPDATE mecanicos
    SET primer_nombre    = @primer_nombre,
        segundo_nombre   = @segundo_nombre,
        primer_apellido  = @primer_apellido,
        segundo_apellido = @segundo_apellido,
        celular          = @celular,
        direccion        = @direccion,
        email            = @email,
        estado           = @estado
    WHERE tipo_documento = @tipo_documento
      AND documento = @documento;

END
GO

CREATE PROCEDURE [dbo].[mecanicos_sp_eliminar](@tipo_documento VARCHAR(2),
                                               @documento INTEGER)
AS

BEGIN
    SET NOCOUNT ON;

    DELETE
    FROM mecanicos
    WHERE tipo_documento = @tipo_documento
      AND documento = @documento;

END
GO

CREATE PROCEDURE [dbo].[mecanicos_sp_leer_todos]
AS

BEGIN
    SET NOCOUNT ON;

    select tipo_documento,
           documento,
           primer_nombre,
           segundo_nombre,
           primer_apellido,
           segundo_apellido,
           celular,
           direccion,
           email,
           estado
    from dbo.mecanicos;

END
GO

