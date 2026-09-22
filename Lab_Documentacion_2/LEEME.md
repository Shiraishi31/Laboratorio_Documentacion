# Lab_Documentacion_2 — Validación y Robustez

**Escenario 2 de la Investigación #1** — *Herramientas de la Programación Aplicada III (.Net)*
Proyecto independiente en **Visual Basic .NET + Windows Forms**.

> Implementación de validaciones defensivas usando `ErrorProvider`, eventos de
> teclado (`KeyPress`) y captura de excepciones con bloques `Try-Catch` para
> evitar caídas del sistema.

---

## Cómo ejecutarlo

1. Abrir **`Lab_Documentacion_2.sln`** con Visual Studio 2022.
2. Pulsar **F5**.

Está configurado para .NET 8 (`net8.0-windows`). Para .NET Framework, cambia
en el `.vbproj`: `<TargetFramework>net48</TargetFramework>`.

---

## Estructura

```
Lab_Documentacion_2/
├── Program.vb                     Sub Main + manejador global de errores
├── Utilidades/
│   ├── ValidadorEntradas.vb       Clase estática: regex, rangos, fortaleza de clave
│   └── ExcepcionNegocio.vb        Excepción personalizada
└── Formularios/
    ├── FrmValidacion.vb
    └── FrmValidacion.Designer.vb  (se abre con el diseñador visual)
```

---

## Las tres capas de defensa

**Capa 1 — Prevención (el error nunca llega a escribirse)**

| Técnica | Dónde |
|---|---|
| `KeyPress` | Nombre solo letras; cédula solo dígitos y guion; edad y teléfono solo dígitos; salario con un único punto decimal (`e.Handled = True`) |
| `KeyDown` | Bloquea `Ctrl+V` en la cédula con `e.SuppressKeyPress` |
| `KeyUp` | Muestra el texto **ya modificado** (diferencia clave con KeyPress) |
| `MaxLength` | Edad = 3, teléfono = 8, contraseña = 20 |
| `PasswordChar` | Se activa y desactiva en caliente con la casilla *Mostrar contraseña* |
| `ReadOnly` | Campo *Código interno*, generado por el sistema |

**Capa 2 — Verificación (`Validating` + `ErrorProvider`)**

Cada campo tiene su evento `Validating` que marca el icono rojo con su mensaje,
sin interrumpir con `MessageBox`. El botón *Validar y guardar* dispara
`ValidateChildren(ValidationConstraints.Enabled)` para revisarlos todos de una
vez. Las conversiones usan **`TryParse`**, nunca `CInt` ni `CDec` directos.
El formulario usa `AutoValidate.EnableAllowFocusChange` para marcar el error
sin secuestrar el foco del usuario.

**Capa 3 — Contención (`Try-Catch-Finally`)**

El *Laboratorio de excepciones* provoca a propósito:

1. `DivideByZeroException` 2. `InvalidCastException` 3. `IndexOutOfRangeException`
4. `NullReferenceException` 5. `FileNotFoundException` 6. `OverflowException`
7. `ExcepcionNegocio` (personalizada) 8. Sin error (solo `Try` y `Finally`)

Los `Catch` están ordenados **del más específico al más general** y el
`Finally` se ejecuta siempre. Todo queda escrito en una bitácora en pantalla
con la hora, ideal para proyectar durante la exposición.

---

## Guion de demostración (3–4 min)

1. Intentar escribir números en *Nombre* y letras en *Edad*: no entran (Capa 1).
2. Escribir una contraseña: ver el medidor de fortaleza y marcar
   *Mostrar contraseña* (`PasswordChar` en caliente).
3. Pulsar *Validar y guardar* con campos vacíos o mal escritos → iconos rojos
   del `ErrorProvider` (Capa 2).
4. Corregir todo y guardar → la bitácora registra el alta.
5. Provocar 3 excepciones distintas y leer la bitácora: señalar que el
   `Finally` aparece **siempre** y que la aplicación nunca se cierra (Capa 3).
