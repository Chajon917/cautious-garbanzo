# cautious-garbanzo
# 🗂️ Control de Planilla - UMG

Sistema de escritorio en **Visual Basic .NET** para control de planillas de empleados con CRUD y generación de cheques.

---

## ✅ Requisitos

- [Visual Studio 2019 o superior](https://visualstudio.microsoft.com/)
- [MySQL / MariaDB](https://dev.mysql.com/downloads/)
- [MySQL Connector/NET](https://dev.mysql.com/downloads/connector/net/)

---

## ⚙️ Configuración

### 1. Clona el repositorio

```bash
git clone https://github.com/Chajon917/cautious-garbanzo.git
```

### 2. Importa la base de datos

Abre **phpMyAdmin** o **MySQL Workbench**, crea una base de datos nueva y luego importa el archivo:

```
basedatos/planilla.sql
```

### 3. Configura la conexión

Abre `CConexion.vb` y cambia estos valores con los de tu MySQL:

```vb
Dim servidor As String = "localhost"
Dim baseDatos As String = "planillaumg"
Dim usuario As String = "tu_usuario"
Dim contrasena As String = "tu_contraseña"
```

### 4. Ejecuta el proyecto

Abre `ProyectoPlanillaUMG1.sln` en Visual Studio y presiona **F5**.

---

> Proyecto académico — Universidad Mariano Gálvez de Guatemala (UMG)
