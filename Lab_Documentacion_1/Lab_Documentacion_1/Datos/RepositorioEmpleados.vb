Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Linq

''' <summary>
''' LAB_DOCUMENTACION_1 (Escenario 1) - SEPARACION DE RESPONSABILIDADES.
'''
''' Toda la logica de negocio (validar, evitar duplicados, calcular totales)
''' vive aqui. El formulario SOLO se encarga de mostrar y recoger datos.
''' Si manana esta lista se cambia por una base de datos SQL, el formulario
''' no se modifica: solo esta clase. (Mantenibilidad / bajo acoplamiento.)
'''
''' COLECCIONES GENERICAS usadas:
'''  - BindingList(Of Empleado) : coleccion enlazada al DataGridView; avisa
'''                               automaticamente al control de altas/bajas.
'''  - List(Of Empleado)        : resultados de busquedas con LINQ.
'''  - Dictionary(Of String,...): resumen agrupado por departamento.
''' </summary>
Public Class RepositorioEmpleados

    Private ReadOnly _datos As New BindingList(Of Empleado)()

    ''' <summary>Coleccion generica que se enlaza al DataGridView.</summary>
    Public ReadOnly Property Datos As BindingList(Of Empleado)
        Get
            Return _datos
        End Get
    End Property

    Public ReadOnly Property Cantidad As Integer
        Get
            Return _datos.Count
        End Get
    End Property

    ' =====================================================================
    '  OPERACIONES (CRUD)
    ' =====================================================================

    Public Sub Agregar(nuevo As Empleado)
        If nuevo Is Nothing Then
            Throw New ArgumentNullException(NameOf(nuevo))
        End If

        Validar(nuevo, -1)
        _datos.Add(nuevo)
    End Sub

    ''' <summary>
    ''' Reemplaza el elemento de la posicion indicada. Se usa un reemplazo
    ''' completo (y no solo cambiar propiedades) para permitir que un
    ''' Empleado pase a ser Gerente o viceversa.
    ''' </summary>
    Public Sub Actualizar(indice As Integer, modificado As Empleado)
        If modificado Is Nothing Then
            Throw New ArgumentNullException(NameOf(modificado))
        End If
        If indice < 0 OrElse indice >= _datos.Count Then
            Throw New ExcepcionNegocio("Debe seleccionar un registro valido de la tabla.")
        End If

        Validar(modificado, indice)
        _datos(indice) = modificado
    End Sub

    Public Sub Eliminar(indice As Integer)
        If indice < 0 OrElse indice >= _datos.Count Then
            Throw New ExcepcionNegocio("Debe seleccionar el registro que desea eliminar.")
        End If
        _datos.RemoveAt(indice)
    End Sub

    Public Sub Limpiar()
        _datos.Clear()
    End Sub

    ' =====================================================================
    '  REGLAS DE NEGOCIO
    ' =====================================================================

    ''' <summary>
    ''' Valida un empleado antes de guardarlo. Lanza ExcepcionNegocio con
    ''' un mensaje claro para el usuario (lo atrapa el formulario).
    ''' </summary>
    Private Sub Validar(emp As Empleado, indiceQueSeEdita As Integer)

        If Not ReglasNegocio.EsCedulaValida(emp.Cedula) Then
            Throw New ExcepcionNegocio(
                "La cedula no tiene un formato valido. Ejemplo: 8-1234-56789.", "Cedula")
        End If

        If Not ReglasNegocio.EsNombreValido(emp.Nombre) Then
            Throw New ExcepcionNegocio(
                "El nombre solo admite letras y debe tener al menos 3 caracteres.", "Nombre")
        End If

        If Not ReglasNegocio.EsNombreValido(emp.Apellido) Then
            Throw New ExcepcionNegocio(
                "El apellido solo admite letras y debe tener al menos 3 caracteres.", "Apellido")
        End If

        If Not ReglasNegocio.EsDepartamentoPermitido(emp.Departamento) Then
            Throw New ExcepcionNegocio(
                "El departamento no esta en la lista autorizada del sistema.", "Departamento")
        End If

        If Not ReglasNegocio.EsSalarioValido(emp.Salario) Then
            Dim minimo As Decimal = ReglasNegocio.SalarioMinimo
            Dim maximo As Decimal = ReglasNegocio.SalarioMaximo
            Throw New ExcepcionNegocio(
                String.Format("El salario debe estar entre {0:C2} y {1:C2}.",
                              minimo, maximo), "Salario")
        End If

        If emp.FechaIngreso.Date > Date.Today Then
            Throw New ExcepcionNegocio(
                "La fecha de ingreso no puede ser futura.", "FechaIngreso")
        End If

        If ExisteCedula(emp.Cedula, indiceQueSeEdita) Then
            Throw New ExcepcionNegocio(
                "Ya existe un empleado registrado con la cedula " & emp.Cedula & ".", "Cedula")
        End If
    End Sub

    ''' <summary>
    ''' True si la cedula ya esta usada por OTRO registro.
    ''' indiceExcluido = -1 cuando se trata de un alta nueva.
    ''' </summary>
    Public Function ExisteCedula(cedula As String, indiceExcluido As Integer) As Boolean
        For i As Integer = 0 To _datos.Count - 1
            If i = indiceExcluido Then Continue For
            If String.Equals(_datos(i).Cedula, cedula, StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function

    ' =====================================================================
    '  CONSULTAS CON LINQ
    ' =====================================================================

    ''' <summary>Busqueda por nombre, cedula o departamento.</summary>
    Public Function Filtrar(criterio As String) As List(Of Empleado)
        If String.IsNullOrWhiteSpace(criterio) Then
            Return _datos.ToList()
        End If

        Dim texto As String = criterio.Trim()

        ' El predicado se pone en un metodo aparte para que la consulta
        ' LINQ quede legible.
        Return _datos.Where(Function(emp) Coincide(emp, texto)).ToList()
    End Function

    ''' <summary>True si el empleado contiene el texto buscado.</summary>
    Private Function Coincide(emp As Empleado, texto As String) As Boolean
        If emp.NombreCompleto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
        If emp.Cedula.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
        If emp.Departamento.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
        Return False
    End Function

    Public Function TotalPlanilla() As Decimal
        If _datos.Count = 0 Then Return 0D
        Return _datos.Where(Function(e) e.Activo).Sum(Function(e) e.Salario)
    End Function

    Public Function PromedioSalario() As Decimal
        Dim activos As List(Of Empleado) = _datos.Where(Function(e) e.Activo).ToList()
        If activos.Count = 0 Then Return 0D
        Return activos.Average(Function(e) e.Salario)
    End Function

    Public Function CantidadActivos() As Integer
        ' Nota: se usa Where(...).Count() porque en VB "_datos.Count" es una
        ' propiedad de la coleccion y no admite parametros.
        Return _datos.Where(Function(e) e.Activo).Count()
    End Function

    ''' <summary>Agrupacion: cuantos empleados hay por departamento.</summary>
    Public Function ConteoPorDepartamento() As Dictionary(Of String, Integer)
        Return _datos.GroupBy(Function(e) e.Departamento).
                      ToDictionary(Function(g) g.Key, Function(g) g.Count())
    End Function

    ' =====================================================================
    '  DATOS DE PRUEBA
    ' =====================================================================

    ''' <summary>Carga registros de ejemplo para la demostracion en clase.</summary>
    Public Sub CargarDatosDemo()
        _datos.Clear()

        Dim deptos As List(Of String) = ReglasNegocio.Departamentos
        Dim d0 As String = If(deptos.Count > 0, deptos(0), "Sistemas")
        Dim d1 As String = If(deptos.Count > 1, deptos(1), d0)
        Dim d2 As String = If(deptos.Count > 2, deptos(2), d0)

        _datos.Add(New Empleado("8-1234-56789", "Ana", "Gomez", d0, 1250D, New Date(2021, 3, 15), True))
        _datos.Add(New Empleado("9-0876-54321", "Luis", "Perez", d1, 980.5D, New Date(2019, 8, 1), True))
        _datos.Add(New Gerente("4-0555-11122", "Marta", "Rodriguez", d0, 2600D, New Date(2016, 1, 10), True))
        _datos.Add(New Empleado("2-0741-85296", "Carlos", "Sanchez", d2, 750D, New Date(2023, 6, 20), False))
    End Sub

End Class
