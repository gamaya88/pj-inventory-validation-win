# PJ - Inventory Validation (Windows)

<div align="center">

  <!-- Tech stack badges (HTML dentro de Markdown) -->
  <img alt="C#" src="https://img.shields.io/badge/C%23-100%25-512BD4?style=for-the-badge&logo=csharp&logoColor=white" />
  <img alt=".NET" src="https://img.shields.io/badge/.NET-8.0%20Windows-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img alt="WinForms" src="https://img.shields.io/badge/Windows%20Forms-WinForms-0078D4?style=for-the-badge&logo=windows11&logoColor=white" />
  <img alt="SQL Server" src="https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
  <img alt="EF Core" src="https://img.shields.io/badge/Entity%20Framework%20Core-7.x-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img alt="QuestPDF" src="https://img.shields.io/badge/QuestPDF-PDF%20Reports-111827?style=for-the-badge" />
  <img alt="MaterialSkin" src="https://img.shields.io/badge/MaterialSkin.2-UI-00BCD4?style=for-the-badge" />
  <img alt="AutoMapper" src="https://img.shields.io/badge/AutoMapper-Mapping-F59E0B?style=for-the-badge" />

</div>

---

## 📦El proyecto incluye

- Aplicación **Windows Forms** (`net8.0-windows`) para **validación / levantamiento de inventario** por colaboradores.
- Pantalla principal `frmMain` como punto de entrada del flujo.
- Servicios para consulta/actualización de información (marcas, modelos, bienes, actas, parámetros, usuario, personas).
- Generación de **Acta de asignación** en PDF (QuestPDF).
- Carga/descarga de actas PDF a una carpeta configurada (tipo “carpeta compartida”).
- Envío de correo cuando un bien se marca como **no coincidente / observado** (según configuración).
- Archivos de datos en `data/*.json` (catálogos auxiliares).

---

## ✨Características

- ✅ Detección de usuario al iniciar (validación de acceso al sistema).
- ✅ Búsqueda de bien por **código patrimonial** (Enter / al salir del campo).
- ✅ Validación de campos obligatorios (dependencia, oficina interna, trabajador).
- ✅ Control de **serie duplicada** antes de guardar.
- ✅ Inventariado:
  - **SIN_INVENTARIAR**
  - **INVENTARIADO**
  - **REPORTADO_POR_REVISAR** (observado)
- ✅ Gestión de actas por trabajador:
  - Generar PDF
  - Subir PDF (acta impresa/firma)
  - Descargar PDF
  - Aprobar / liberar según estado
- ✅ Paneles/pestañas con visibilidad por perfil (lista de **usuarios admin** configurable).

---

## 🤖¿Qué hace este proyecto?

Permite que un colaborador registre y valide bienes patrimoniales asignados a trabajadores:

- Consulta un bien por **código patrimonial**.
- Registra datos de validación (estado, serie, observación, asignación a persona/oficina).
- Mantiene el control de estados del inventario y de las **actas** asociadas.
- Genera un **acta PDF** de asignación de bienes.
- Facilita el flujo de firma/carga/descarga de actas mediante una carpeta configurada.
- Cuando un bien no coincide, lo marca como observado y **notifica por email** a destinatarios configurados.

---

## 🔁Flujo general

1. **Inicio**
   - Se detecta el usuario del sistema.
   - Se cargan parámetros (emails, credenciales, carpeta de actas, usuarios admin).
   - Se cargan combos (marcas, colores, estados, dependencias, trabajadores).
2. **Inventariado**
   - Se ingresa/escanea el **código patrimonial**.
   - Si existe, se cargan datos del bien en el formulario.
   - Se completa estado/serie/observación y se guarda:
     - Cambia a **INVENTARIADO**
     - Asigna persona, oficina y usuario inventoriante
     - Crea/actualiza acta asociada a la persona
3. **Generación y manejo de actas**
   - Genera acta PDF (QuestPDF) y registra impresión.
   - Se sube el acta PDF a la carpeta configurada (estado SUBIDA / FIRMADA).
   - Administradores pueden aprobar/liberar según estado.
4. **Observaciones**
   - Si un bien “no coincide”, pasa a **REPORTADO_POR_REVISAR** y se envía correo.

---

## 🧠¿Cómo funciona?

### Arquitectura (simple y práctica)
- **Views (UI)**: Formularios WinForms (`frmMain`, búsquedas, edición).
- **Services**: encapsulan lógica de consulta/actualización y acciones (persistencia, parámetros, correo).
- **Model**: entidades y vistas (DTO/ViewModels) para mostrar datos en la UI.
- **Report**: composición/generación de PDFs (ActaInventario con QuestPDF).
- **Utils**: helpers (teclas, validaciones, envío de correos, enums, extensiones).

---

## 🧩Componentes principales

- `Program.cs`
  - Inicializa la app y abre `frmMain`.
- `frmMain`
  - Orquesta el flujo: carga usuario/parámetros/combos, inventariado, actas, observaciones.
- `config.json`
  - Configuración base: `ConnectionString` y `User`.
- `Service/*`
  - Servicios como `UsuarioService`, `BienPatrimonialService`, `ActaBienPatrimonialService`, `ParametroService`, etc.
- `Report/*`
  - Reporte de acta en PDF (QuestPDF).
- `data/*.json`
  - Catálogos auxiliares (Bien, Marca, Modelo, Color, Estado, etc.).

---

## 🛠️Configuración

### Archivo `config.json`
Ubicación: `PJ.Inf.InventoryValidation.Win/config.json`

Ejemplo:
```json
{
  "ConnectionString": "Server=localhost\\SQLEXPRESS2022;Database=HELPDESK_PROD;Trusted_Connection=False;uid=sa;password=***;TrustServerCertificate=True",
  "User": "usuario@correo.com"
}
```

#### Recomendación de seguridad
- Evita commitear credenciales reales.
- Opciones recomendadas:
  - usar variables de entorno,
  - usar Secret Manager (en desarrollo),
  - o un `config.local.json` ignorado por Git.

---

## ✅Requisitos

- Windows 10/11
- .NET SDK **8.x**
- SQL Server (por ejemplo **SQL Server Express 2022**) + acceso a la BD configurada
- Visual Studio 2022 (recomendado) con workload de **.NET desktop development**
- Permisos de lectura/escritura en la carpeta configurada para actas (si aplica)

---

## 🧪Tecnologías (Dependencias principales)

- **AutoMapper** (mapeo de entidades a vistas)
- **MaterialSkin.2** (UI estilo Material Design)
- **Entity Framework Core** + **SqlServer** (acceso a datos)
- **Newtonsoft.Json** (JSON)
- **QuestPDF** (reportes PDF)

---

## 🗃️Persistencia (tablas esperadas)

> Nota: los nombres exactos dependen de tu modelo/DbContext, pero por el uso en la UI/servicios se esperan estructuras equivalentes a:

- **BienPatrimonial**
  - Id, Código patrimonial, Serie (original/nueva), Estado conservación (actual/nuevo), Color, Observación
  - Asignación: Persona/Oficina
  - Estado inventario: SIN_INVENTARIAR / INVENTARIADO / REPORTADO_POR_REVISAR
  - Relación con Acta (AbpId)
- **ActaBienPatrimonial**
  - Persona, estado de acta (CREADA/IMPRESA/SUBIDA/FIRMADA/APROBADA…)
  - Archivos (subido/firmado), última impresión, impresiones, auditoría
- **Persona / Trabajador**
- **Usuario**
- Catálogos:
  - **Marca**, **Modelo**
  - Definiciones/valores (colores, estados, estados de acta, etc.)
- Estructuras de organización:
  - Sede, DependenciaJudicial, OficinaInterna, etc.

---

## 🚀Instalación / Ejecución

1. Clona el repositorio
2. Abre la solución:
   - `PJ.Inf.InventoryValidation.Win/PJ.Inf.InventoryValidation.Win.sln`
3. Configura `PJ.Inf.InventoryValidation.Win/config.json` (cadena de conexión y usuario)
4. Restaura paquetes NuGet
5. Ejecuta el proyecto `PJ.Inf.InventoryValidation.Win` (WinExe)

---

## 🧯Solución de problemas

- **“Usuario no detectado, saldrá del sistema”**
  - Revisa la lógica/consulta de `UsuarioService.Get()` y que el usuario actual exista en la fuente de datos.
- **No se puede subir/descargar actas**
  - Verifica el parámetro de **carpeta de subida** (debe existir o poder crearse).
  - Confirma permisos de lectura/escritura.
- **Errores de conexión a BD**
  - Revisa `ConnectionString` en `config.json`.
  - Valida instancia SQL y credenciales.
  - Si usas certificados, `TrustServerCertificate=True` puede ser necesario en dev.
- **No genera PDF**
  - Confirma que la ruta seleccionada sea válida.
  - Revisa dependencias de QuestPDF y permisos de escritura.
- **Validación no permite guardar**
  - Asegura que se haya seleccionado:
    - Dependencia judicial
    - Oficina interna
    - Trabajador

---

## 🗺️Roadmap

- [ ] Documentar el modelo de datos real (DbContext + entidades) y mapear tablas definitivas
- [ ] Agregar modo “offline” con sincronización (si aplica)
- [ ] Agregar logging (Serilog/NLog) + visor de errores
- [ ] Manejo seguro de secretos (sin credenciales en repositorio)
- [ ] Pipeline de build (CI) y versión instalable (MSIX/ClickOnce)

---

## 📄Licencia

Este proyecto no tiene licencia declarada actualmente.  
Recomendación: agrega un archivo `LICENSE` (MIT / Apache-2.0 / Proprietary, según corresponda).
