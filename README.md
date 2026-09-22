# Investigación #1 — Arquitectura, Buenas Prácticas y Calidad en Aplicaciones de Escritorio

**Universidad Tecnológica de Panamá** · Facultad de Ingeniería en Sistemas Computacionales
Campus Víctor Levis Sasso
**Herramientas de la Programación Aplicada III (.Net)** · II Semestre 2026

| | |
|---|---|
| **Estudiante** | *(tu nombre completo)* |
| **Cédula** | *(tu cédula)* |
| **Grupo** | *(tu grupo)* |
| **Profesora** | Ing. Irina Fong |
| **Lenguaje** | Visual Basic .NET (Windows Forms) |

---

## Sobre este repositorio

Contiene los **tres escenarios prácticos** exigidos por la investigación,
implementados como **tres proyectos independientes** de escritorio. Cada uno
tiene su propia solución de Visual Studio, se abre y se ejecuta por separado,
y demuestra un bloque distinto de la teoría.

| Proyecto | Escenario | Tema central |
|---|---|---|
| [`Lab_Documentacion_1`](./Lab_Documentacion_1) | Estructura y Datos | Colecciones genéricas `List(Of T)` enlazadas a un `DataGridView` + clase de modelo orientada a objetos |
| [`Lab_Documentacion_2`](./Lab_Documentacion_2) | Validación y Robustez | `ErrorProvider`, eventos de teclado (`KeyPress`) y `Try-Catch-Finally` |
| [`Lab_Documentacion_3`](./Lab_Documentacion_3) | Calidad y Seguridad | Parámetros externos en `config.xml` + clases estáticas de utilidades y validación segura |

Cada carpeta incluye su propio **`LEEME.md`** con el detalle técnico y un guion
corto de demostración para la exposición.

---

## Requisitos

- **Visual Studio 2022** con la carga de trabajo *Desarrollo de escritorio de .NET*
- **.NET 8 SDK** (los proyectos apuntan a `net8.0-windows`)
- Windows 10 u 11

> **¿Solo tienes .NET Framework?** Abre el archivo `.vbproj` del laboratorio y
> cambia una sola línea:
> ```xml
> <TargetFramework>net48</TargetFramework>
> ```
> No hay que tocar nada más: el código no usa APIs exclusivas de .NET 8.

---

## Cómo ejecutar

```bash
git clone https://github.com/<usuario>/<repositorio>.git
```

Luego, para cualquiera de los tres:

1. Abrir `Lab_Documentacion_N/Lab_Documentacion_N.sln` con Visual Studio.
2. Pulsar **F5**.

En `Lab_Documentacion_3`, el archivo `config.xml` se copia solo a
`bin\Debug\net8.0-windows\`. Puedes editarlo ahí y pulsar **Recargar
config.xml** dentro de la aplicación para ver el cambio **sin recompilar**.

---

## Estructura del repositorio

```
.
├── README.md                   Este archivo
├── .gitignore                  Excluye bin/, obj/, .vs/ y archivos temporales
│
├── Lab_Documentacion_1/        ESCENARIO 1 — Estructura y Datos
│   ├── Lab_Documentacion_1.sln
│   ├── LEEME.md
│   └── Lab_Documentacion_1/
│       ├── Lab_Documentacion_1.vbproj
│       ├── Program.vb
│       ├── Modelo/             Persona (abstracta) → Empleado → Gerente
│       ├── Datos/              RepositorioEmpleados (lógica de negocio)
│       ├── Utilidades/         ReglasNegocio, ExcepcionNegocio
│       └── Formularios/        FrmEmpleados (+ .Designer.vb)
│
├── Lab_Documentacion_2/        ESCENARIO 2 — Validación y Robustez
│   ├── Lab_Documentacion_2.sln
│   ├── LEEME.md
│   └── Lab_Documentacion_2/
│       ├── Program.vb
│       ├── Utilidades/         ValidadorEntradas, ExcepcionNegocio
│       └── Formularios/        FrmValidacion (+ .Designer.vb)
│
└── Lab_Documentacion_3/        ESCENARIO 3 — Calidad y Seguridad
    ├── Lab_Documentacion_3.sln
    ├── LEEME.md
    └── Lab_Documentacion_3/
        ├── config.xml          Parámetros externos
        ├── Program.vb
        ├── Utilidades/         ConfiguracionManager, ValidadorSeguro,
        │                       ParametroConfig, ExcepcionNegocio
        └── Formularios/        FrmSeguridad (+ .Designer.vb)
```

Los tres proyectos compilan con **`Option Strict On`** y **`Option Explicit On`**:
no se permite ninguna conversión implícita de tipos ni variables sin declarar.

---

## Escenario 1 — Estructura y Datos

Registro de empleados con separación en capas.

- **Colecciones genéricas:** `BindingList(Of Empleado)` como fuente de datos,
  `List(Of Empleado)` para los resultados de búsqueda y
  `Dictionary(Of String, Integer)` para el conteo por departamento.
- **Enlace a datos:** `BindingSource` → `DataGridView` con
  `AutoGenerateColumns = False` y columnas declaradas con `DataPropertyName`;
  no se llenan filas a mano.
- **Modelo orientado a objetos:** `Persona` es `MustInherit` (abstracta) e
  implementa `INotifyPropertyChanged`; `Empleado` hereda de ella y `Gerente`
  hereda de `Empleado` sobrescribiendo `SalarioAnual` → **polimorfismo** visible
  en la propia tabla.
- **Separación de responsabilidades:** todas las reglas viven en
  `RepositorioEmpleados`; el formulario solo muestra y recoge datos.
- **LINQ:** `Where`, `Sum`, `Average`, `GroupBy` para el panel de resumen.

## Escenario 2 — Validación y Robustez

Formulario de registro con tres capas de defensa:

1. **Prevención** — `KeyPress` descarta caracteres inválidos (`e.Handled`),
   `KeyDown` bloquea `Ctrl+V` (`e.SuppressKeyPress`), `KeyUp` muestra el texto
   ya modificado. Propiedades `MaxLength`, `PasswordChar` (conmutable en
   caliente) y `ReadOnly`.
2. **Verificación** — evento `Validating` + **`ErrorProvider`** (icono y mensaje
   por campo, sin `MessageBox`), `ValidateChildren` para revisar todo de una
   vez y `TryParse` en lugar de `CInt`/`CDec`.
3. **Contención** — laboratorio que provoca a propósito `DivideByZeroException`,
   `InvalidCastException`, `IndexOutOfRangeException`, `NullReferenceException`,
   `FileNotFoundException`, `OverflowException` y la excepción personalizada
   `ExcepcionNegocio`, con los `Catch` ordenados **del más específico al más
   general** y un `Finally` que siempre se ejecuta. Todo queda en una bitácora
   en pantalla.

## Escenario 3 — Calidad y Seguridad / Mantenimiento

- **Configuración externa:** `ConfiguracionManager` (clase estática,
  `NotInheritable` con constructor `Private`) lee `config.xml` con
  **LINQ to XML** (`XDocument`) y guarda los valores en caché. Si el archivo
  falta o está dañado, usa valores por defecto y avisa: **la aplicación no se
  cae**.
- **Validación segura:** `ValidadorSeguro` concentra expresiones regulares,
  lista blanca de departamentos, lista negra de patrones de inyección
  (SQL y `<script>`) y saneamiento de texto.
- **Credenciales:** hashing **SHA-256 con salt** generado por
  `RandomNumberGenerator`; la contraseña nunca se guarda en texto plano.
  La comparación de hashes es en **tiempo constante** (evita *timing attacks*),
  el mensaje de error es genérico y hay bloqueo por `MaximoIntentos`.

---

## Impacto en los atributos de calidad (ISO/IEC 25010)

| Atributo (*-ilidad*) | Evidencia en el código |
|---|---|
| **Mantenibilidad** | Separación en capas (Modelo / Datos / Utilidades / Formularios). Cambiar la regla de salario no obliga a tocar ningún formulario. |
| **Confiabilidad** | `Try-Catch-Finally`, `TryParse`, excepciones personalizadas y un manejador global en `Program.vb`. |
| **Usabilidad** | `ErrorProvider`, filtrado de teclado, medidor de fortaleza de contraseña y mensajes en lenguaje claro. |
| **Seguridad** | Hashing con salt, prevención de inyección y principio de mínimo privilegio (campos `Private` + propiedades públicas). |
| **Portabilidad** | `config.xml` externo: el despliegue en otra máquina no exige recompilar. |

Etapas del SDLC impactadas: **codificación** (menos deuda técnica por el tipado
estricto y las colecciones genéricas), **pruebas** (los errores se aíslan sin
que la aplicación colapse), **despliegue** (configuración externa) y
**mantenimiento**, la fase más larga y costosa del software.

---

## Notas

- El enunciado plantea los escenarios en C#; aquí están resueltos en
  **Visual Basic .NET**, que corre sobre el mismo .NET y aplica exactamente los
  mismos conceptos (POO, colecciones genéricas, LINQ, `ErrorProvider`,
  manejo de excepciones y `System.Security.Cryptography`).
- Las carpetas `bin/`, `obj/` y `.vs/` están excluidas por `.gitignore`: se
  regeneran solas al compilar y no deben subirse al repositorio.
