# Lab_Documentacion_3 — Calidad y Seguridad / Mantenimiento

**Escenario 3 de la Investigación #1** — *Herramientas de la Programación Aplicada III (.Net)*
Proyecto independiente en **Visual Basic .NET + Windows Forms**.

> Lectura externa de parámetros desde un archivo de configuración
> (`config.xml`) y aplicación de filtros/métodos de validación segura
> (clases estáticas de utilidades y manejo de propiedades de control).

---

## Cómo ejecutarlo

1. Abrir **`Lab_Documentacion_3.sln`** con Visual Studio 2022.
2. Pulsar **F5**.

Está configurado para .NET 8 (`net8.0-windows`). Para .NET Framework, cambia
en el `.vbproj`: `<TargetFramework>net48</TargetFramework>`.

> `config.xml` se copia solo a `bin\Debug\...` al compilar. Puedes editarlo ahí
> y pulsar **Recargar config.xml** para que los cambios apliquen **sin cerrar
> ni recompilar** la aplicación.

---

## Estructura

```
Lab_Documentacion_3/
├── config.xml                     Parámetros externos (nada quemado en código)
├── Program.vb                     Carga la configuración antes de abrir el form
├── Utilidades/
│   ├── ConfiguracionManager.vb    Clase estática: LINQ to XML + caché en Dictionary
│   ├── ValidadorSeguro.vb         Clase estática: regex, saneamiento, SHA-256 + salt
│   ├── ParametroConfig.vb         Modelo simple para mostrar los parámetros
│   └── ExcepcionNegocio.vb        Excepción personalizada
└── Formularios/
    ├── FrmSeguridad.vb
    └── FrmSeguridad.Designer.vb   (se abre con el diseñador visual)
```

---

## Qué demuestra

| Requisito del enunciado | Dónde está |
|---|---|
| Lectura externa de parámetros | `ConfiguracionManager` lee `config.xml` con `XDocument` (LINQ to XML) y cachea en `Dictionary(Of String, String)` |
| Clases estáticas de utilidades | `ConfiguracionManager` y `ValidadorSeguro`: `NotInheritable` + constructor `Private` |
| Filtros / validación segura | Lista blanca de departamentos, expresiones regulares, lista negra de patrones de inyección y `Sanitizar()` |
| Manejo de propiedades de control | `ReadOnly`, `MaxLength` y `PasswordChar` tomados del XML |

**Seguridad (OWASP aplicado a .NET):**

- *Inyección SQL / script*: detección por lista negra + saneamiento. En la
  interfaz se aclara que la defensa real son las **consultas parametrizadas**
  (`cmd.Parameters.AddWithValue`), nunca la concatenación de cadenas.
- *Exposición de datos sensibles*: la contraseña **nunca** se guarda en texto
  plano — se almacena `SHA-256(salt + clave)` y el salt se genera con
  `RandomNumberGenerator`.
- *Fallas de autenticación*: comparación de hashes en **tiempo constante**
  (evita *timing attacks*), mensaje de error genérico que no revela si falló
  el usuario o la contraseña, y bloqueo tras `MaximoIntentos`.
- *Confiabilidad*: si `config.xml` falta o está dañado, la aplicación usa
  valores por defecto y avisa, en vez de caerse.

---

## Parámetros que puedes cambiar en `config.xml`

`SalarioMinimo`, `SalarioMaximo`, `EdadMinima`, `EdadMaxima`,
`LongitudMinimaClave`, `LongitudMaximaClave`, `MaximoIntentos`,
los patrones `PatronCorreo` / `PatronCedula` / `PatronNombre`,
la lista de `<departamento>` y la lista de `<patronPeligroso>`.

---

## Guion de demostración (3–4 min)

1. Mostrar la tabla con todos los parámetros leídos y la ruta del archivo.
2. En el analizador de entradas, probar `admin' OR 1=1 --` y
   `Robert'); DROP TABLE alumnos;--` → **rechazados**, y comparar con el texto
   saneado.
3. Registrar un usuario: aparecen el salt y el hash; la contraseña original
   se descarta.
4. Verificar el acceso con la clave correcta (concedido) y con una incorrecta
   (denegado) hasta que se bloquee la cuenta por `MaximoIntentos`.
5. **El remate:** abrir `config.xml` en el Bloc de notas, bajar
   `MaximoIntentos` a 1, pulsar *Recargar config.xml* y repetir el paso 4.
   Cambió el comportamiento del sistema **sin recompilar** → Portabilidad y
   Mantenibilidad (ISO/IEC 25010).
