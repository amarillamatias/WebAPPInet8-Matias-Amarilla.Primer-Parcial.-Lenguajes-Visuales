# WebAPPInet8

## Descripción del proyecto
Aplicación web desarrollada en .NET 8 que implementa autenticación JWT, buenas prácticas REST y gestión de al menos 5 entidades: Customer, Product, Order, Category y User.

## Instrucciones de instalación y ejecución

1. Clona el repositorio:
   ```
   git clone https://github.com/amarillamatias/WebAPPInet8-Matias-Amarilla.Primer-Parcial.-Lenguajes-Visuales.git
   ```
2. Abre la solución en Visual Studio 2022 o superior.
3. Restaura los paquetes NuGet:
   - Visual Studio lo hace automáticamente al abrir el proyecto.
4. Configura la cadena de conexión en `appsettings.Development.json` según tu entorno SQL Server.
5. Compila y ejecuta el proyecto (`F5` o `Ctrl+F5`).
6. Accede a la API usando Swagger en `/swagger` o prueba los endpoints con Postman/cURL.

## Datos de prueba para login

Utiliza el endpoint:
```
POST /api/auth/login
```
Con el siguiente JSON:
```
{
  "username": "admin",
  "password": "password"
}
```

Esto te devolverá un token JWT válido para acceder a los endpoints protegidos.

---

Puedes agregar más usuarios en la base de datos si lo deseas.
