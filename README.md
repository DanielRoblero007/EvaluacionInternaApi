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

# Explicacion del proyecto 

Lo he trabajado por 3 capas
1. Models: que define la estructura de los datos que contendra.
2. Services: esta la maneje como la logica de negocio y acceso a los datos, ya que se Esta
utilizando listas en memoria.
3. Controllers: Esta va exponer los endpoints que vamos a consumir.

*CAPA Models
En los modelos he considerado poner los campos mas importantes, como en cliente capturando la
informacion de nombre, DPI, direccion, Tel, correo, fecha de nacimiento e ingreso, en formato DATETIme
para obtener la fecha del dia.

En el modelo de pago generando un pago ID, cuenta origen y cuenta destino, el monto, fecha y 
el tipo de pago, osea motivo.

*Capa Services
En esta capa se maneja la logica del negocio.

1. Cliente:
se esta utilizando un private static readonly List<Cliente>, para simular la tabla de Clientes,
en los metodos tenemos 2, InsertarCliente añadiendo un cliente, pero antes de insertar vamos a verificar
si el cliente con el DPI existe, de lo contrario no se podra crear. 

En el metodo de ObtenerCliente, buscara por DPI y si no encuentra retornara a null.

2. Pago:
En el pago lo mismo que cliente, se utilizara una private static readonly List<Pago>, para simular una
tabla, COntendra 2 pagos iguales, uno de InsetarPago que va asignar un ID autoincremental y fecha actual.
El de ObtenerPago devolvera una lista completa de todos los pagos hechos.

3. Bitacora
En esta parte se esta utilizando de todos los registros hechos en el sistema, tanto en la creacion
de Apis y consultas, como estamos trabajando por listas vamos a usar private readonly List<string>,
para guardar los registro.

El metodo de Registrar vamos a realizar un formateo a un mensaje de log con la fecha y hora actual.
Y el metodo de ObtenerRegistro devolvera todos los registros de la bitacora.

* CAPA Controllers

1. Cliente controller
Aqui vamos a realizar unas inyecciones de dependencias de ClienteService y BitacoraService
en los endponts de Get se busca el cliente por DPI, y registrando en la Bitacora, igualmente
en el POST, creando un cuerpo de datos JSON, manejando la validacion de DPI duplicado, de lo contrario no Se
podra crear, y registrando todo en la bitacroa, como la creacion exitosa o el error.

2. Pago controller
De igual manera se realiza inyecciones de dependencias PagoService y BitacoraService,
El GET devolviendo una lista completa de todos los pagos y la bitacora registrando la accion.

El Post de igual manera creando el pago, manejando una bitacora de error y exito para poder registrarlo.

En la configuracion del Program.cs se ha modificado, ya que estamos manejando inyeccion de dependencias estamos
usando los 3 servicios que es el ClienteService, PagoService y BitacoraService, que se esta usando el metodo
add Singleton.

¿Por que usamos el Singleton?
Ya que estamos manejando memoria en lista, esto ayudara a que funcione bien la simulacion, porque en cada llamda API, se Esta
guardando, para poder Insertar o Consultar, asi que mientras la App esta en ejecucion guardara todo lo que vamos haciendo.

