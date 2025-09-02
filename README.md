# Proyecto Backend - EcosystemManagerApp

Aplicación Backend para gestión de productos (prueba técnica).  
Incluye **backend en .NET 9.0**.

---

## 🚀 Tecnologías y Herramientas utilizadas

- C# - .Net Core - Framework .Net9
- VisualStudio 2022
- REST API (simulada o real)
---

## 🛠️ Características del sistema

- Inicio en plataforma Swagger
- Ingreso de datos formato Json.
- Sistema valida los datos, consult5ando la base de datos en memoria.
- Actualización de datos.
- Eliminación de datos.

---

## 📂 Estructura del proyecto

/EcosystemManagerApp
	|- EcosystemManagerApp/ # API .NET (Clean Architecture)
		|- EcosystemManager.Api/
    |- EcosystemManager.Application/
    |- EcosystemManager.Domain/
    |- EcosystemManager.Infrastructure/
	|- README.md

 ---


## ⚙️ Backend (.NET 8)

### 📌 Requisitos previos
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- 
---

### Pasos:

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/edwsilme/EcosystemManagerApp.git

2. Cambiar a Rama develop:
   ```bash
   git switch develop

3. Dirijirse a la carpeta WebApi
   ```bash
   cd EcosystemManagerApp/EcosystemManager.Api

4. Ejecutar la API:
   ```bash
   dotnet run --launch-profile https

---
Enlaces:

Api Swagger: https://localhost:7232/swagger/index.html

---

### Screenshot

:arrow_forward: Pantalla de inicio de la aplicación Swagger:<p>
<img src="https://github.com/edwsilme/raw/blob/main/img-ecosystem/swagger1.png" width="500">

:arrow_forward: Pantalla de Post de la aplicación Swagger:<p>
<img src="https://github.com/edwsilme/raw/blob/main/img-ecosystem/Post.png" width="500">

:arrow_forward: Pantalla de Get de la aplicación Swagger:<p>
<img src="https://github.com/edwsilme/raw/blob/main/img-ecosystem/Get.png" width="500">


