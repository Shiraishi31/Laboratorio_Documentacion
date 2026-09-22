Option Strict On
Option Explicit On

''' <summary>
''' Estructura simple para mostrar en pantalla cada parametro leido
''' del archivo config.xml (Lab_Documentacion_3).
''' </summary>
Public Class ParametroConfig

    Public Property Seccion As String = String.Empty
    Public Property Clave As String = String.Empty
    Public Property Valor As String = String.Empty

    Public Sub New()
    End Sub

    Public Sub New(seccion As String, clave As String, valor As String)
        Me.Seccion = seccion
        Me.Clave = clave
        Me.Valor = valor
    End Sub

    Public Overrides Function ToString() As String
        Return Clave & " = " & Valor
    End Function

End Class
