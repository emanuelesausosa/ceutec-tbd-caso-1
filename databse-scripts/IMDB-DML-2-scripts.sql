
SELECT * FROM MERCADEO.AUTOR
SELECT * FROM MERCADEO.CONCEPTO

SELECT A.APELLIDOS FROM MERCADEO.AUTOR AS A

SELECT A.APELLIDOS FROM MERCADEO.AUTOR AS A
WHERE A.APELLIDOS LIKE '%R%'


SELECT A.APELLIDOS, A.FECHA_DEFUNCION FROM MERCADEO.AUTOR AS A
WHERE A.FECHA_DEFUNCION BETWEEN '19900101' AND '20181231'


INSERT INTO MERCADEO.AUTOR(NOMBRES, APELLIDOS, FECHA_DEFUNCION, FECHA_NACIMIENTO)
VALUES('JOHN', 'SENA', '19900101', GETDATE())

SELECT COUNT(*) AS [CUENTA] FROM MERCADEO.AUTOR A
WHERE A.FECHA_NACIMIENTO BETWEEN '20180101' AND '20181231'

SELECT COUNT(*) AS [CUENTA] FROM MERCADEO.AUTOR A
WHERE A.FECHA_DEFUNCION BETWEEN '20180101' AND '20181231'

SELECT 
	A.NOMBRES, A.APELLIDOS
FROM MERCADEO.CONCEPTO C, MERCADEO.AUTOR A
WHERE C.ID_AUTOR = A.ID

SELECT A.NOMBRES, 
	   A.APELLIDOS 
FROM MERCADEO.AUTOR A INNER JOIN MERCADEO.CONCEPTO C
ON A.ID = C.ID_AUTOR

SELECT 
	A.NOMBRES, 
	A.APELLIDOS, 
	COUNT(A.ID) AS [CANT_CONCEPTOS] 
FROM 
	MERCADEO.AUTOR A INNER JOIN 
	MERCADEO.CONCEPTO C
ON A.ID = C.ID_AUTOR
GROUP BY 
	A.NOMBRES, 
	A.APELLIDOS










