USE Pacs1P

--La finalidad de este trigger es que cada que se agregue una nueva Sucursal
--esta creara un nuevo colaborador
CREATE TRIGGER NewColaborador ON Sucursales
FOR INSERT 
AS 
BEGIN
	DECLARE @idSucursal INT
	DECLARE @nombre NVARCHAR (50)
	SELECT @idSucursal = INSERTED.idSucursal,
			@nombre = INSERTED.nombre
		FROM INSERTED
		--Al momento de agregar una sucursal, y si esta sucursal tiene de activo 1
		--realizara la insersion de un nuevo colaborador para esa sucursal
	IF(SELECT activo FROM INSERTED) = 1
	BEGIN
		PRINT 'Se registro una nueva Sucursal'
		INSERT INTO Colaboradores VALUES(
			'New Colaborador'+@nombre, 'Otro Apellido', (SELECT FLOOR(RAND()*(50-18)+18)), 'San Fransisco Del Rincon', 
				(SELECT FLOOR(RAND()*(10000-1000)+1000)), 3, @idSucursal, 1)
				/*Aqui lo que hacemos es agregar un colaborador, para poder diferenciarlo de otro registro 
				al agregar su nombre le ponemos nuevo colaborador y el nombre de la sucursal creada
				Ademas, al crear un nuevo colaborador, este necesita tanto una edad y un sueldo, para no tener que cambiarlo a 
				cada rato, hacemos uso de un metodo que nos genera datos aleatorios dentro de un rango
				Luego de generar la edad y sueldo aleatorio, solo creamos el colaborador con la misma idSucursal*/
     END
     ELSE
	 BEGIN
	 /*En dado caso que al agregar una sucursal su activo sea 0, esta se considera que no existe, por ende, dada de baja y no 
	 creara el registro del nuevo colaborador*/
		ROLLBACK TRANSACTION
        PRINT 'La sucursal agregada esta dada de baja, cancelando...'
		  
	END
END
GO



/*La finalidad de este trigger es similar al anterior, al agregar una nueva Area
esta creara un nuevo Colaborador pero haciendo referencia al Area creada*/
CREATE TRIGGER NewArea ON Areas
FOR INSERT 
AS 
BEGIN
	DECLARE @idArea INT
	DECLARE @nombre NVARCHAR (50)
	SELECT @idArea = INSERTED.idArea,
			@nombre = INSERTED.nombre
		FROM INSERTED
		--Al momento de agregar una area, y si esta area tiene de activo 1
		--realizara la insersion de un nuevo colaborador para esa area
	IF(SELECT activo FROM INSERTED) = 1
	BEGIN
		PRINT 'Se registro una nueva area'
		INSERT INTO Colaboradores VALUES(
			'New Colaborador'+@nombre, 'Area', (SELECT FLOOR(RAND()*(50-1)+18)), 'Leon Guanajuato', 
				(SELECT FLOOR(RAND()*(10000-1000)+1000)), @idArea, 2, 1)
				/*Aqui lo que hacemos es agregar un colaborador, para poder diferenciarlo de otro registro 
				al agregar su nombre le ponemos nuevo colaborador y el nombre del area creada
				Ademas, al crear un nuevo colaborador, este necesita tanto una edad y un sueldo, para no tener que cambiarlo a 
				cada rato, hacemos uso de un metodo que nos genera datos aleatorios dentro de un rango
				Luego de generar la edad y sueldo aleatorio, solo creamos el colaborador con la misma idArea*/
     END
     ELSE
	 BEGIN
		ROLLBACK TRANSACTION
        PRINT 'El area agregada esta dada de baja, cancelando...'
		  /*En dado caso que al agregar una area y su activo sea 0, esta se considera que no existe, por ende, dada de baja y no 
	 creara el registro del nuevo colaborador*/
	END
END
GO


/*El siguiente trigger genera un Usuario nuevo para cada Socio agregado*/
CREATE TRIGGER NewSocio ON Socios
FOR INSERT 
AS 
BEGIN
	DECLARE @nombre NVARCHAR (50)
	SELECT	@nombre = INSERTED.nombre
		FROM INSERTED
		/*Al momento de ingresar un nuevo socio, este esta activo, creara un nuevo usuario tomando su nombre*/
	IF(SELECT activo FROM INSERTED) = 1
	BEGIN
		PRINT 'Se registro un nuevo Socio... Generando Usuario'
		INSERT INTO Usuarios VALUES(
			+@nombre, (SELECT dbo.fnCustomPass(15,'CN')), 1)
			/*Al momento de crear un nuevo usuario, este sera ingresado con el nombre que se le dio al 
			Socio, ademas que hacemos uso de una funcion que nos genera una cadena de caracteres totalmente
			aleatorios, este se hizo uso para generar contraseñas totalmente distintas y aleatorias*/
     END
     ELSE
	 BEGIN
		ROLLBACK TRANSACTION
        PRINT 'El socio no pudo ser dado de alta... restableciendo datos...'
		  /*Al agregar un nuevo Socio y este no se encuentre activo, sera cancelado y no se realizara la insersion*/
	END
END
GO





/*Creamos una vista para la generacion de caracteres aleatorios*/
CREATE VIEW vwRandom
AS
SELECT RAND() as Rnd
GO 


/*Este es la funcion que nos ayudara a crear cadenas aleatorias, puede ser tanto cadenas de puros String, Numericos y Mixtos*/
CREATE FUNCTION fnCustomPass 
(    
    @size AS INT, --Tamaño de la cadena aleatoria
    @op AS VARCHAR(2) --Opción para letras(ABC..), numeros(123...) o ambos.
)
RETURNS VARCHAR(62)
AS
BEGIN    

    DECLARE @chars AS VARCHAR(52),
            @numbers AS VARCHAR(10),
            @strChars AS VARCHAR(62),        
            @strPass AS VARCHAR(62),
            @index AS INT,
            @cont AS INT

    SET @strPass = ''
    SET @strChars = ''    
    SET @chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    SET @numbers = '0123456789'

    SET @strChars = CASE @op WHEN 'C' THEN @chars --Letras
                        WHEN 'N' THEN @numbers --Números
                        WHEN 'CN' THEN @chars + @numbers --Ambos (Letras y Números)
                        ELSE '------'
                    END

    SET @cont = 0
    WHILE @cont < @size
    BEGIN
        SET @index = ceiling( ( SELECT rnd FROM vwRandom ) * (len(@strChars)))--Uso de la vista para el Rand() y no generar error.
        SET @strPass = @strPass + substring(@strChars, @index, 1)
        SET @cont = @cont + 1
    END    
        
    RETURN @strPass

END
GO


/*Ejemplo de que esta funcionando el metodo de creacion de cadenas aleatorias*/
SELECT dbo.fnCustomPass(15,'C') AS 'Cadena aleatoria','Solo Letras' AS Contiene  --Cadena aleatoria que contiene Letras.
UNION ALL
SELECT dbo.fnCustomPass(15,'N'),'Solo Números'  --Cadena aleatoria que contiene Números.
UNION ALL
SELECT dbo.fnCustomPass(15,'CN'), 'Letras y Números'--Cadena aleatoria que contiene Letras y Números.


/*En caso de ser necesario, eliminar los trigger*/
DROP TRIGGER NewColaborador
DROP TRIGGER NewArea 
DROP TRIGGER NewSocio


/*Pruebas de insersion para comprobar funcionamiento de triggers*/
INSERT INTO Socios VALUES ('Willy', 'Cruz', 21, 'Leon Guanajuato', 2, 1)
INSERT INTO Usuarios VALUES('Prueba', (SELECT dbo.fnCustomPass(15,'CN')), 1)

SELECT * FROM Usuarios
SELECT * FROM Socios

SELECT * FROM Areas
SELECT * FROM Colaboradores

SELECT * FROM Sucursales