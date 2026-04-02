# ✈️ FNViajes - Sistema de Gestión de Viajes

FNViajes es un proyecto grupal que consiste en un sistema de gestión de viajes conectado a una base de datos en **MongoDB local**.

El proyecto incluye dos partes principales:

- 🖥️ **Aplicación de escritorio (Windows Forms)** destinada a administradores.
- 🌐 **Página web** destinada a usuarios finales.

Ambos sistemas se conectan a la misma base de datos para compartir información de viajes, usuarios y compras.

---

## 🎮 Características principales

### 🖥️ Aplicación de escritorio (Administración)

- 🔐 **Inicio de sesión de administradores**.
- 👤 **Gestión de usuarios** (cambio de nivel de acceso).
- 🧳 **Gestión de viajes**:
  - ➕ Agregar viajes.
  - ✏️ Modificar viajes.
  - 🗑️ Eliminar viajes.
- 🛒 **Visualización de compras** registradas en la base de datos.
- 📋 Visualización de datos mediante **DataGridView**.
- 🔒 Restricción de acciones según nivel de acceso:
  - Solo usuarios con `acceso == 2` pueden modificar viajes y permisos.

---

### 🌐 Página web (Usuarios)

- 🧳 Visualización de todos los viajes disponibles.
- 🔎 Visualización de un viaje específico.
- 👤 Registro de usuarios.
- 🔐 Inicio de sesión de usuarios.
- 🛒 Carrito de compras:
  - Agregar viajes al carrito.
  - Quitar viajes del carrito.
  - Ver monto total.
  - Realizar compra.
- 👋 Saludo personalizado mostrando el nombre y apellido del usuario.

---

## 🛠️ Tecnologías utilizadas

### 🖥️ Aplicación de escritorio

- C#
- Windows Forms
- MongoDB.Driver
- DataGridView

### 🌐 Página Web / Frontend

- HTML
- CSS
- JavaScript
- Fetch API

### 🖥️ Backend / API

- Node.js
- Express.js
- MongoDB
- Mongoose
- dotenv
- cors

---

## 📌 Funcionalidades del sistema web

- Registro de usuarios con validaciones:
  - Contraseña mínima de 4 caracteres
  - Confirmación de contraseña
  - Validación de formato de mail con regex
- Inicio de sesión mediante validación de usuario y contraseña
- Listado dinámico de viajes obtenido desde la API
- Página de detalle de viaje obtenida por ID
- Agregado y eliminación de viajes del carrito
- Compra de viajes desde el carrito
- Inserción automática de compras en base de datos
- Limpieza del carrito al realizar una compra

---

## 📂 Estructura del proyecto

El proyecto se divide en tres partes:

- 🖥️ **App de Escritorio**: administración de viajes, usuarios y compras.
- 🌐 **Frontend Web**: navegación, carrito, registro e inicio de sesión.
- 🖥️ **Backend API**: rutas y conexión a MongoDB para usuarios, viajes y compras.

---

## 🗄️ Base de Datos

El proyecto utiliza una base de datos MongoDB llamada:

**fnviajes**

Colecciones utilizadas:

**viajes**
**usuarios**
**compras**

---

## 📌 Esquemas utilizados (MongoDB)

Viajes

```JavaScript
{
  id: Number,
  nombre: String,
  lugar: String,
  desc: String,
  duracion: Number,
  img: String,
  precio: Number
}
```

Usuarios

```JavaScript
{
  id: Number,
  nombre: String,
  apellido: String,
  mail: String,
  acceso: Number,
  password: String,
  carrito: [Number],
  compras: [Number]
}
```

Compras

```JavaScript
{
  id: Number,
  usuario: Number,
  articulos: [Number],
  monto: Number
}
```

---

## ⚙️ Variables de entorno

El backend utiliza un archivo .env con las siguientes variables:

```env
PORT=2006
URI=mongodb://localhost:27017/fnviajes
```
---

## 📌 Rutas principales de la API

### 🧳 Viajes

- **GET /api/viajes/:id** → obtener viaje por ID
- **GET /api/viaje/todos** → obtener todos los viajes

### 👤 Usuarios

- **GET /api/usuarios/:id** → obtener usuario por ID
- **GET /api/usuario/todos** → obtener todos los usuarios
- **POST /api/registro** → registrar usuario

### 🛒 Carrito

- **GET /api/agregarAlCarrito/:idUsuario/:idViaje** → agregar viaje al carrito
- **GET /api/borrarDelCarrito/:idUsuario/:posicion** → eliminar un elemento del carrito por posición
- **GET /api/borrarCarrito/:idUsuario/:idNuevaCompra** → vaciar carrito y guardar compra en el usuario

### 💳 Compras

- **GET /api/compra/todos** → obtener todas las compras
- **GET /api/insertarCompra/:id/:usuario/:articulos/:monto** → insertar una compra nueva

---

# ⚙️ Instalación del Backend

## 1. Descargar repositorio

Descargar el zip del repositorio desde el botón "<> code"

## 2. Instalar dependencias

```bash
npm install
```

## 3. Crear archivo .env

```env
PORT=2006
URI=mongodb://localhost:27017/fnviajes
```

## 4. Ejecutar servidor

```bash
node app.js
```

Servidor disponible en:

```
http://localhost:2006/api
```

---

# 🌐 Instalación del Frontend (Web)

## 📌 El frontend está hecho en HTML, CSS y JavaScript.

Para ejecutarlo se puede abrir directamente el archivo **index.html** o levantarlo con un servidor local como **Live Server** en Visual Studio Code.

Ejemplo:

* Abrir **index.html**
* Ejecutar con Live Server

---

# 🖥️ Instalación de la Aplicación de Escritorio

## 1. Abrir el proyecto

* Abrir Visual Studio
* Seleccionar "Open Project"
* Elegir la carpeta del proyecto FNviajes

## 2. Ejecutar el programa

* Presionar Start / F5
* Se abrirá el formulario principal FormInicio

---

## ⚠️ Consideraciones

MongoDB debe estar corriendo en local:

```
mongodb://localhost:27017/fnviajes

```

El backend utiliza conexión por .env mediante process.env.URI.
El sistema de permisos se basa en el campo acceso del usuario.

En la app de escritorio, las acciones de administración solo se permiten si:

```
acceso == 2
```

En la web, el usuario activo se maneja mediante parámetros en la URL:

```
?usuario=ID
```

---

## 👨‍💻 Autores

Proyecto grupal desarrollado por Mateo Noba, Tobias Noba y Agustin Casal como práctica académica para las materias: Desarrollo de sistemas orientados a objetos (Aplicación de escritorio) y Programación (Página web). Las implementaciones del sistema completo son:

Aplicación de escritorio (administración)
Página web (usuarios)
Backend API
Base de datos MongoDB compartida

---

## 📄 Licencia

Uso educativo y demostrativo.
