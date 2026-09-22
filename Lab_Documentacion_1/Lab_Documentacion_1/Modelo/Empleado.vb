Option Strict On
Option Explicit On

''' <summary>
''' LAB_DOCUMENTACION_1 (Escenario 1) - Clase de modelo concreta.
''' Hereda de Persona y agrega los datos laborales.
''' Es la clase que se almacena dentro de la coleccion generica
''' List(Of Empleado) / BindingList(Of Empleado) enlazada al DataGridView.
''' </summary>
Public Class Empleado
    Inherits Persona

    Private _departamento As String = String.Empty
    Private _salario As Decimal
    Private _fechaIngreso As Date = Date.Today
    Private _activo As Boolean = True

    ' ---------- Constructores ----------

    ''' <summary>Constructor vacio: requerido por el enlace a datos.</summary>
    Public Sub New()
    End Sub

    Public Sub New(cedula As String, nombre As String, apellido As String,
                   departamento As String, salario As Decimal,
                   fechaIngreso As Date, activo As Boolean)

        Me.Cedula = cedula
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Departamento = departamento
        Me.Salario = salario
        Me.FechaIngreso = fechaIngreso
        Me.Activo = activo
    End Sub

    ' ---------- Propiedades ----------

    Public Property Departamento As String
        Get
            Return _departamento
        End Get
        Set(value As String)
            _departamento = If(value, String.Empty).Trim()
            NotificarCambio(NameOf(Departamento))
        End Set
    End Property

    Public Property Salario As Decimal
        Get
            Return _salario
        End Get
        Set(value As Decimal)
            ' Regla de negocio dentro del modelo: nunca un salario negativo.
            _salario = If(value < 0D, 0D, value)
            NotificarCambio(NameOf(Salario))
            NotificarCambio(NameOf(SalarioAnual))
        End Set
    End Property

    Public Property FechaIngreso As Date
        Get
            Return _fechaIngreso
        End Get
        Set(value As Date)
            _fechaIngreso = value
            NotificarCambio(NameOf(FechaIngreso))
            NotificarCambio(NameOf(AntiguedadAnios))
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return _activo
        End Get
        Set(value As Boolean)
            _activo = value
            NotificarCambio(NameOf(Activo))
        End Set
    End Property

    ' ---------- Propiedades calculadas ----------

    Public ReadOnly Property AntiguedadAnios As Integer
        Get
            Dim dias As Double = (Date.Today - _fechaIngreso.Date).TotalDays
            If dias < 0 Then Return 0
            Return CInt(Math.Floor(dias / 365.25))
        End Get
    End Property

    ''' <summary>
    ''' Overridable: las clases hijas pueden cambiar el calculo.
    ''' (Ver la clase Gerente = polimorfismo.)
    ''' </summary>
    Public Overridable ReadOnly Property SalarioAnual As Decimal
        Get
            Return _salario * 12D
        End Get
    End Property

    Public Overrides ReadOnly Property Rol As String
        Get
            Return "Empleado"
        End Get
    End Property

End Class
