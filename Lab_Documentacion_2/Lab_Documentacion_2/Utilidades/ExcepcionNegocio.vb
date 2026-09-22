Option Strict On
Option Explicit On

''' <summary>
''' Excepcion personalizada para errores de REGLA DE NEGOCIO
''' (cedula duplicada, salario fuera de rango, departamento invalido...).
'''
''' Separarla de las excepciones del sistema permite que la interfaz
''' distinga entre "el usuario se equivoco" (mensaje amable) y
''' "fallo la aplicacion" (error tecnico), tal como se explica en el
''' Escenario 2.
''' </summary>
Public Class ExcepcionNegocio
    Inherits ApplicationException

    ''' <summary>Campo/control relacionado con el error, si aplica.</summary>
    Public Property Campo As String = String.Empty

    Public Sub New()
        MyBase.New("Se violo una regla de negocio.")
    End Sub

    Public Sub New(mensaje As String)
        MyBase.New(mensaje)
    End Sub

    Public Sub New(mensaje As String, campo As String)
        MyBase.New(mensaje)
        Me.Campo = campo
    End Sub

    Public Sub New(mensaje As String, innerException As Exception)
        MyBase.New(mensaje, innerException)
    End Sub

End Class
