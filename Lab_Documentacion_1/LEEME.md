# Lab_Documentacion_1 — Estructura y Datos

**Escenario 1 de la Investigación #1** — *Herramientas de la Programación Aplicada III (.Net)*
Proyecto independiente en **Visual Basic .NET + Windows Forms**.

> Uso de colecciones genéricas (`List(Of T)`) enlazadas a un `DataGridView`
> junto con una clase de modelo orientada a objetos.

---

## Cómo ejecutarlo

1. Abrir **`Lab_Documentacion_1.sln`** con Visual Studio 2022.
2. Pulsar **F5**.

Está configurado para .NET 8 (`net8.0-windows`). Si tu Visual Studio solo tiene
.NET Framework, abre `Lab_Documentacion_1.vbproj` y cambia esa línea por
`<TargetFramework>net48</TargetFramework>`.

---

## Estructura

```
Lab_Documentacion_1/
├── Program.vb                     Sub Main + manejador global de errores
├── Modelo/
│   ├── Persona.vb                 MustInherit (abstracta), INotifyPropertyChanged
│   ├── Empleado.vb                Hereda de Persona
│   └── Gerente.vb                 Hereda de Empleado → polimorfismo
├── Datos/
│   └── RepositorioEmpleados.vb    Colecciones genéricas + reglas de negocio
├── Utilidades/
│   ├── ReglasNegocio.vb           Clase estática con la lista blanca y los rangos
│   └── ExcepcionNegocio.vb        Excepción personalizada
└── Formularios/
    ├── FrmEmpleados.vb
    └── FrmEmpleados.Designer.vb   (se abre con el diseñador visual)
```

---

## Qué demuestra

| Requisito del enunciado | Dónde está |
|---|---|
| Colección genérica `List(Of T)` | `BindingList(Of Empleado)` en `RepositorioEmpleados`; `List(Of Empleado)` en las búsquedas; `Dictionary(Of String, Integer)` en el resumen por departamento |
| Enlazada a un `DataGridView` | `BindingSource` → `dgvEmpleados`, con `AutoGenerateColumns = False` y columnas con `DataPropertyName` |
| Clase de modelo orientada a objetos | `Persona` (abstracta) → `Empleado` → `Gerente` |
| Separación de responsabilidades | El formulario **no valida ni calcula**; solo muestra y recoge datos |

**Extras técnicos:** herencia y polimorfismo (`SalarioAnual` sobrescrito en
`Gerente`), encapsulamiento con campos `Private` y propiedades públicas,
`INotifyPropertyChanged` para que la grilla se refresque sola, propiedades
calculadas (`NombreCompleto`, `Edad`, `AntiguedadAnios`) y consultas LINQ
(`Where`, `Sum`, `Average`, `GroupBy`) para el panel de resumen.

---

## Guion de demostración (3–4 min)

1. Arranca con 4 registros de ejemplo (botón *Cargar datos demo*).
2. Agregar un empleado nuevo y marcar **Es gerente**: comparar la columna
   *Salario anual* con la de un empleado normal → **polimorfismo**.
3. Intentar guardar una **cédula repetida**: el error lo lanza el
   `RepositorioEmpleados` (capa de negocio), no el formulario.
4. Escribir en el buscador → filtrado con LINQ y el resumen se recalcula.
5. Seleccionar una fila, cambiar el salario y pulsar *Actualizar*.
