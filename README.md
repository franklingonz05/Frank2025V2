# Reporte de Estado de Cuenta

Este proyecto tiene como objetivo generar un reporte de estado de cuenta en formato PDF, que incluye información detallada sobre las tarjetas registradas, movimientos de la tarjeta seleccionada, y un formulario para registrar transacciones (compra o pago).

## Descripción del Proyecto

Este sistema permite a los usuarios ver el estado de cuenta de sus tarjetas de crédito, los movimientos asociados a cada tarjeta, y realizar nuevas transacciones como compras o pagos. El reporte final se genera en formato PDF, el cual incluye imágenes y detalles importantes.

### Funcionalidades

- **Registro de Tarjetas**: El sistema muestra todas las tarjetas registradas en un formato visual.
- **Estado de Cuenta**: Genera un PDF con el estado de cuenta de la tarjeta seleccionada.
- **Movimientos de la Tarjeta**: Muestra los movimientos realizados con la tarjeta de crédito seleccionada.
- **Formulario de Transacciones**: Permite al usuario registrar una transacción, ya sea una compra o un pago.

## Imágenes Incluidas en el Reporte

A continuación se describen las imágenes que serán incluidas en el reporte PDF generado:

1. **Tarjetas Registradas**
   - **Imagen**:
     ![Tarjetas Registradas](Doc/imag1.png)
   - **Descripción**: Lista de todas las tarjetas de crédito registradas en el sistema.

2. **Estado de Cuenta**
   - **Imagen**:
     ![Estado de Cuenta](Doc/imag2.png)
   - **Descripción**: Imagen que representa el estado de cuenta de la tarjeta seleccionada.

3. **Movimientos de la Tarjeta**
   - **Imagen**:
     ![Movimientos de la Tarjeta](Doc/imag3.png)
   - **Descripción**: Detalle de los movimientos realizados con la tarjeta de crédito seleccionada.

4. **Formulario de Transacciones**
   - **Imagen**:
     ![Formulario de Transacciones](Doc/imag4.png)
   - **Descripción**: Formulario para registrar una transacción (compra o pago).


## Cómo Funciona

1. **Generación del Reporte**:
   - El reporte PDF se genera con la información de las tarjetas registradas, el estado de cuenta, los movimientos de la tarjeta seleccionada, y un formulario para registrar transacciones.
   
2. **Flujo del Reporte**:
   - El documento PDF comienza con el nombre del usuario (en este caso, "Franklin Gonzalez").
   - Luego, se lista la información de todas las tarjetas registradas.
   - Posteriormente, se detalla el estado de cuenta de la tarjeta seleccionada.
   - Después, se muestran los movimientos de la tarjeta de crédito seleccionada.
   - Finalmente, se incluye un formulario para registrar una nueva transacción (compra o pago).







# Frank2025V2# CreditCard.Api

La API `CreditCard.Api` es un servicio web RESTful que permite interactuar con información relacionada con tarjetas de crédito, incluyendo estados de cuenta, transacciones y detalles de tarjetas. La implementación sigue los patrones de diseño **Repositorio**, **UnitOfWork** y **CQRS** para facilitar la escalabilidad, mantenimiento y pruebas de la aplicación.

## Estructura de la API

Esta API está estructurada bajo los siguientes patrones:

- **Repositorio**: Encapsula el acceso a la base de datos y proporciona una interfaz de consulta unificada.
- **UnitOfWork**: Gestiona transacciones y asegura que los cambios en múltiples repositorios sean consistentes.
- **CQRS (Command Query Responsibility Segregation)**: Separa las operaciones de lectura (Queries) y escritura (Commands), optimizando el rendimiento y la escalabilidad.

## Endpoints

### 1. `/api/AccountStatement`

**GET**: Obtiene el estado de cuenta de una tarjeta de crédito específica.

- **Parámetros**:
  - `CardNumber` (query parameter): Número de tarjeta de crédito (tipo: string).
- **Respuestas**:
  - **200 OK**: Devuelve los detalles del estado de cuenta en formato JSON.
  - **404 Not Found**: Si no se encuentra la tarjeta.
  - **500 Internal Server Error**: Si ocurre un error en el servidor.

### 2. `/api/CreditCard`

**GET**: Obtiene la lista de todas las tarjetas de crédito disponibles.

- **Respuestas**:
  - **200 OK**: Devuelve una lista de tarjetas de crédito en formato JSON.
  - **404 Not Found**: Si no se encuentran tarjetas.
  - **500 Internal Server Error**: Si ocurre un error en el servidor.

### 3. `/api/Smoke`

**GET**: Endpoint de prueba para verificar que la API está funcionando correctamente.

- **Respuestas**:
  - **200 OK**: Si el servicio está funcionando.

### 4. `/api/Transaction`

**POST**: Crea una nueva transacción en una tarjeta de crédito.

- **Cuerpo de la solicitud**:
  - `creditCardID` (integer): ID de la tarjeta de crédito.
  - `type` (integer): Tipo de transacción.
  - `amount` (double): Monto de la transacción.
  - `transactionDate` (string): Fecha de la transacción en formato ISO 8601.
  - `description` (string, opcional): Descripción de la transacción.
- **Respuestas**:
  - **200 OK**: Devuelve el ID de la transacción creada.
  - **400 Bad Request**: Si los datos de la transacción son inválidos.
  - **500 Internal Server Error**: Si ocurre un error en el servidor.

### 5. `/api/Transaction/ByCard`

**GET**: Obtiene las transacciones asociadas a una tarjeta de crédito específica.

- **Parámetros**:
  - `CardNumber` (query parameter): Número de tarjeta de crédito (tipo: string).
- **Respuestas**:
  - **200 OK**: Devuelve una lista de transacciones en formato JSON.
  - **404 Not Found**: Si no se encuentran transacciones.
  - **500 Internal Server Error**: Si ocurre un error en el servidor.

### 6. `/WeatherForecast`

**GET**: Obtiene un pronóstico del clima (solo como ejemplo).

- **Respuestas**:
  - **200 OK**: Devuelve un pronóstico del clima.

## Respuestas Comunes

Las respuestas comunes de la API incluyen las siguientes propiedades:

- **isSuccess**: Indica si la operación fue exitosa (booleano).
- **data**: Datos devueltos por la operación (puede ser un objeto o una lista).
- **totalRecords**: Número total de registros (opcional).
- **message**: Mensaje adicional (opcional).
- **validationFailure**: Errores de validación, si los hay.
- **errors**: Errores generales en formato clave-valor.

## Ejemplo de Respuesta Exitosa

```json
{
  "isSuccess": true,
  "data": {
    "cardHolderName": "John Doe",
    "cardNumber": "1234-5678-9012-3456",
    "creditLimit": 5000.00,
    "availableCredit": 2500.00,
    "totalBalance": 1200.00
  },
  "totalRecords": 1,
  "message": "Operación exitosa",
  "validationFailure": [],
  "errors": {}
}
