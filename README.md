# EvaluacionInternaApi
Explicacion de la base de datos:
1. Clientes: Manejaremos la informacion esencial, generando un ID al cliente,
capturando informacion escencial como; Nombre, Apellido, DPI, Direccion, Telefono,
Email, fecha de nacimiento y la fecha de registro al banco.

2. Empleado: Se creara un ID para tener un valor unico, tomando tambien el ID de la sucursal
para diferenciar de donde viene, contendra informacion escencial como Nombre, Apellido,
DPI, Puesto, fecha de contratacion y su estado, manejando de forma booleana de activo
o inactivo.

3. sucursal: Contendra una ID para tener un valor unico, nombre, Direccion y Telefono.

4. Cuenta: Esta estara relacionada al Cliente capturando el ID del cliente, ID sucursal
tambien estara tomando 2 tablas relacionales extras de Estado cuenta y tipo de cuenta,
Contendra una ID cuenta para tener un valor unico, Saldo, tipo de moneda, cuando fue
aperturada, y el estado de la cuenta, manejando si esta Activa, desactivada o bloqueado.

5. Pago: Estara relacionada a la tabla Cuenta y Estado de pago, capturando el ID, 
Contendra un ID pago, Se manejara de la forma siguiente; contendra una cuenta de destino,
el monto, fecha y conceptado, y tipo de estado, manejando si esta completado, pendiente,
rechazado o cancelado.

*Ademas he creado 3 tablas relacionales, que manejara mejor la gestion y estados de algunas
*tablas, manejando mejor el flujo y tener mejor estructura de la BD

--- Tablas relacionadas a Cuenta---
6 Estado cuenta: Esta tabla estara relacionada a Cuenta, como se habia mencionado manejara
los estados, que contendra: Activa, inactiva o Bloqueada.

7. Tipo Cuenta: Estara relacionada a Cuenta, manejando que tipo de cuenta es, por ejemplo:
si es de Ahorro o Monetaria.

--Tabla relacionada a Pago--
8. Estado Pago:  Estara relacionada a Pago, manejando la gestion de estado de pago, 
por ejemplo: Compleatdo, pendiente, rechazado o si fue cancelada

Por ultimo manejando una tabla Bitacora.
9. Bitacora: Esta tabla contendra un registro de acciones, que contendra la informacion
siguiente del ID empleado, ID cliente, la acciones, detalle, Fecha y Hora de la Bitacora,
obviamente se manejara un ID que sera nombrada Log para tener varios logs en el sistema
y poder buscar.

