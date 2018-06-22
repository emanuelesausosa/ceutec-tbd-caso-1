
-- obtener la lista de todos los empleaddos con su respectivo puesto de trabajo
SELECT  P.FirstName, 
		P.LastName, E.JobTitle 
FROM 
	HumanResources.Employee E
	INNER JOIN Person.Person P ON 
	E.BusinessEntityID = P.BusinessEntityID

-- Obtener los depatamentos con su respectivo cant empleados
SELECT 
	D.Name, COUNT(E.BusinessEntityID) AS [#EMPLEADOS]
FROM 
	HumanResources.Department D 
	INNER JOIN HumanResources.EmployeeDepartmentHistory ED
	ON D.DepartmentID = ED.DepartmentID
	INNER JOIN HumanResources.Employee E 
	ON ED.BusinessEntityID = E.BusinessEntityID
GROUP BY
	D.Name


-- NOMBRE Y APELLIDO DE LOS QUE ESTAN CASADOS
SELECT 
	P.FirstName, 
	P.LastName, 
	CASE E.MaritalStatus 
		WHEN 'M' THEN 'CASADO'
		WHEN 'S' THEN 'SOLTERO'	
	END  [Estado Civil]
FROM 
	HumanResources.Employee E INNER JOIN Person.Person P
	ON E.BusinessEntityID = P.BusinessEntityID
ORDER BY P.FirstName ASC --DESC


