Option Strict On
Option Explicit On

''' <summary>
''' LAB_DOCUMENTACION_1 (Escenario 1) - Demostracion de HERENCIA y POLIMORFISMO.
''' Un Gerente ES un Empleado, pero su salario anual incluye un bono.
''' Como la coleccion es List(Of Empleado), un Gerente puede guardarse
''' en la misma lista y el DataGridView mostrara automaticamente su
''' propio calculo gracias al Overrides.
''' </summary>
Public Class Gerente
    Inherits Empleado

    ''' <summary>Porcentaje de bonificacion anual (0.15 = 15%).</summary>
    Public Property PorcentajeBono As Decimal = 0.15D

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(cedula As String, nombre As String, apellido As String,
                   departamento As String, salario As Decimal,
                   fechaIngreso As Date, activo As Boolean)

        MyBase.New(cedula, nombre, apellido, departamento, salario, fechaIngreso, activo)
    End Sub

    ''' <summary>Salario anual + bono de responsabilidad.</summary>
    Public Overrides ReadOnly Property SalarioAnual As Decimal
        Get
            Return MyBase.SalarioAnual * (1D + PorcentajeBono)
        End Get
    End Property

    Public Overrides ReadOnly Property Rol As String
        Get
            Return "Gerente"
        End Get
    End Property

End Class
