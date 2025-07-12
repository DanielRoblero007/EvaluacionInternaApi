Drop Database ApiBanco;

CREATE DATABASE ApiBanco;
USE ApiBanco;

-- 1. Cliente
CREATE TABLE Cliente (
    Cliente_ID INT PRIMARY KEY IDENTITY(1,1),
    Cliente_Nombre NVARCHAR(25) NOT NULL,
    Cliente_Apellido NVARCHAR(25) NOT NULL,
    Cliente_DPI VARCHAR(13) UNIQUE NOT NULL,
    Cliente_Direccion NVARCHAR(100) NOT NULL,
    Cliente_Telefono NVARCHAR(20) NOT NULL,
    Cliente_Email NVARCHAR(50) UNIQUE NOT NULL,
    Cliente_FechaNacimiento DATE NOT NULL,
    Cliente_FechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 2. Tipo de cuenta
-- En este tipo cuenta vamos a nombrar que cuenta es tipo: Ahorro o Monetaria
CREATE TABLE TipoCuenta (
    TipoCuenta_ID INT PRIMARY KEY IDENTITY(1,1),
    TipoCuenta_Nombre NVARCHAR(25) UNIQUE NOT NULL,
    TipoCuenta_Descripcion TEXT
);

--3. Estado de cuenta
-- En estado de cuenta vamos a manejar varios estados como: Activa, Inactiva, Bloqueada.
CREATE TABLE EstadoCuenta (
    EstadoCuenta_ID INT PRIMARY KEY IDENTITY(1,1),
    EstadoCuenta_Nombre NVARCHAR(25) UNIQUE NOT NULL
);
---4. Sucursal -
CREATE TABLE Sucursal (
    Sucursal_ID INT PRIMARY KEY IDENTITY(1,1),
    Sucursal_Nombre NVARCHAR(50) NOT NULL,
    Sucursal_Direccion NVARCHAR(100) NOT NULL,
    Sucursal_Telefono NVARCHAR(25)
);

--5. Cuenta
CREATE TABLE Cuenta (
    Cuenta_ID INT PRIMARY KEY IDENTITY(1,1),
    Cliente_ID INT NOT NULL,
    TipoCuenta_ID INT NOT NULL,
    Cuenta_Saldo DECIMAL(15, 2) NOT NULL DEFAULT 0.00,
    Cuenta_Moneda NVARCHAR(3) NOT NULL DEFAULT 'GTQ',
    Cuenta_FechaApertura DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    EstadoCuenta_ID INT NOT NULL,
    Sucursal_ID INT,
    FOREIGN KEY (Cliente_ID) REFERENCES Cliente(Cliente_ID),
    FOREIGN KEY (TipoCuenta_ID) REFERENCES TipoCuenta(TipoCuenta_ID),
    FOREIGN KEY (EstadoCuenta_ID) REFERENCES EstadoCuenta(EstadoCuenta_ID),
    FOREIGN KEY (Sucursal_ID) REFERENCES Sucursal(Sucursal_ID)
);

--6. Estado del pago
--  En estados de pago manejaremos por ejemplo: Compleatdo, pendiente, rechazado o si fue cancelada.
CREATE TABLE EstadoPago (
    EstadoPago_ID INT PRIMARY KEY IDENTITY(1,1),
    EstadoPago_Nombre NVARCHAR(25) UNIQUE NOT NULL -- Ej: 'Completado', 'Pendiente', 'Fallido'
);

--- 7. pago
CREATE TABLE Pago (
    Pago_ID INT PRIMARY KEY IDENTITY(1,1),
    Cuenta_ID_Origen INT NOT NULL,
    Pago_CuentaDestino VARCHAR(20) NOT NULL, -- Puede ser una CLABE, número de tarjeta, etc.
    Pago_Monto DECIMAL(10, 2) NOT NULL,
    Pago_Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Pago_Concepto VARCHAR(100),
    EstadoPago_ID INT NOT NULL,
    FOREIGN KEY (Cuenta_ID_Origen) REFERENCES Cuenta(Cuenta_ID),
    FOREIGN KEY (EstadoPago_ID) REFERENCES EstadoPago(EstadoPago_ID)
);

--- 8 Empleado.
CREATE TABLE Empleado (
    Empleado_ID INT PRIMARY KEY IDENTITY(1,1),
    Sucursal_ID INT,
    Empleado_Nombre NVARCHAR(25) NOT NULL,
    Empleado_Apellido NVARCHAR(25) NOT NULL,
    Empleado_DPI NVARCHAR(13) UNIQUE NOT NULL,
    Empleado_Puesto NVARCHAR(50) NOT NULL,
    Empleado_FechaContratacion DATE NOT NULL,
    Empleado_Estado BIT DEFAULT 1,
    FOREIGN KEY (Sucursal_ID) REFERENCES Sucursal(Sucursal_ID)
);


---9. Bitacora
CREATE TABLE Bitacora (
    id_log INT PRIMARY KEY IDENTITY(1,1),
    Empleado_ID INT,
    Cliente_ID INT,
    Bitacora_Accion VARCHAR(100) NOT NULL,
    Bitacora_Detalles TEXT,
    Bitacora_FechaHora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (Empleado_ID) REFERENCES Empleado(Empleado_ID),
    FOREIGN KEY (Cliente_ID) REFERENCES Cliente(Cliente_ID)
);



