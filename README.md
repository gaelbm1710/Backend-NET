# Proyecto de Backend de Gestion Empresarial
Proyecto para la gestión de Empleados y Departamentos de una empresa atraves de APIS.  Dentro del proyecto podrás encontrar los Modelos y Controladores neceesarios para las APIS

# Base de Datos: 
La base de datos que se utilizo fue SQL Server su version más reciente
Dejo los querys para los ejemplos:
- Paso 1: Crea La base de Datos
    ```SQL
      Create database EmpresaDB;
    ```
- Paso 2: Crear las tablas
    ```SQL
  CREATE TABLE Departamentos (
    DepartamentoID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
  );

    CREATE TABLE Empleados (
      EmpleadoID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    DepartamentoID INT,
    FechaContratacion DATE,
    Salario DECIMAL(10, 2),
    FOREIGN KEY (DepartamentoID) REFERENCES Departamentos(DepartamentoID)
  );
    ```
- Paso 3: Insertar Valores de Ejemplo
    ```SQL
    INSERT INTO Departamentos (DepartamentoID, Nombre, Descripcion)
  VALUES 
  (1, 'Recursos Humanos', 'Gestiona el personal de la empresa'),
  (2, 'Tecnología', 'Desarrollo y mantenimiento de sistemas'),
  (3, 'Ventas', 'Encargado de las ventas y relaciones con clientes');
    
  INSERT INTO Empleados (EmpleadoID, Nombre, Apellido, DepartamentoID, FechaContratacion, Salario)
  VALUES 
  (1, 'Juan', 'Pérez', 1, '2021-01-15', 50000.00),
  (2, 'Ana', 'Gómez', 2, '2022-02-20', 60000.00),
  (3, 'Carlos', 'Sánchez', 3, '2020-03-10', 55000.00),
  (4, 'Laura', 'Ramírez', 2, '2023-04-25', 62000.00),
  (5, 'Sofía', 'Martínez', 1, '2021-05-30', 48000.00);
    ```
# Ejemplos de Postman
- Post de Departamentos: http://localhost:5013/api/Departamento
  ```json
  {
        "Nombre": "Marketing",
        "Descripcion": "Manejo de Redes Sociales y creacion de Banners y anuncios para atraer gente"
  }
- Get de Empleados: http://localhost:5013/api/Empleado
  ```json
  [
    {
        "EmpleadoID": 1,
        "Nombre": "Juan",
        "Apellido": "Pérez",
        "DepartamentoID": 1,
        "FechaContratacion": "2023-01-15T00:00:00",
        "Salario": 55000.00
    },
    {
        "EmpleadoID": 2,
        "Nombre": "Ana",
        "Apellido": "García",
        "DepartamentoID": 2,
        "FechaContratacion": "2022-05-10T00:00:00",
        "Salario": 75000.00
    },
    {
        "EmpleadoID": 3,
        "Nombre": "Carlos",
        "Apellido": "Ramírez",
        "DepartamentoID": 2,
        "FechaContratacion": "2023-06-01T00:00:00",
        "Salario": 65000.00
    },
    {
        "EmpleadoID": 4,
        "Nombre": "María",
        "Apellido": "López",
        "DepartamentoID": 3,
        "FechaContratacion": "2021-03-20T00:00:00",
        "Salario": 60000.00
    }
  ]
  
