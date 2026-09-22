Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Text.RegularExpressions

''' <summary>
''' LAB_DOCUMENTACION_2 (Escenario 2) - Clase estatica de validacion.
'''
''' Centraliza TODAS las reglas de validacion del formulario. Ningun evento
''' Validating escribe su propia expresion regular: todos preguntan aqui.
''' Asi, si manana cambia el formato de la cedula, se corrige en un solo
''' lugar y no en ocho eventos distintos (Mantenibilidad).
'''
''' Es NotInheritable con constructor Private: es una clase de utilidades,
''' no se hereda ni se instancia.
''' </summary>
Public NotInheritable Class ValidadorEntradas

    Private Sub New()
    End Sub

    ' ---------- Reglas del dominio ----------

    Public Const EdadMinima As Integer = 18
    Public Const EdadMaxima As Integer = 70
    Public Const LongitudMinimaClave As Integer = 8
    Public Const LongitudMaximaClave As Integer = 20
    Public Const SalarioMinimo As Decimal = 325D
    Public Const SalarioMaximo As Decimal = 9500D

    Private Const PatronNombre As String = "^[\p{L} ]{3,40}$"
    Private Const PatronCedula As String = "^\d{1,2}-\d{1,4}-\d{1,6}$"
    Private Const PatronCorreo As String = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"

    ' ---------- Validaciones de formato ----------

    Public Shared Function EsNombreValido(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Return Regex.IsMatch(texto.Trim(), PatronNombre)
    End Function

    Public Shared Function EsCedulaValida(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Return Regex.IsMatch(texto.Trim(), PatronCedula)
    End Function

    Public Shared Function EsCorreoValido(texto As String) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then Return False
        Return Regex.IsMatch(texto.Trim(), PatronCorreo)
    End Function

    ' ---------- Validaciones de rango ----------

    Public Shared Function EsEdadValida(valor As Integer) As Boolean
        Return valor >= EdadMinima AndAlso valor <= EdadMaxima
    End Function

    Public Shared Function EsSalarioValido(valor As Decimal) As Boolean
        Return valor >= SalarioMinimo AndAlso valor <= SalarioMaximo
    End Function

    ' ---------- Fortaleza de la contrasena ----------

    ''' <summary>
    ''' Puntua la clave de 0 a 5 y devuelve en 'detalle' que le falta.
    ''' El parametro detalle es ByRef: asi se devuelven dos resultados
    ''' sin necesidad de crear una clase solo para eso.
    ''' </summary>
    Public Shared Function EvaluarFortalezaClave(clave As String, ByRef detalle As String) As Integer

        If clave Is Nothing Then clave = String.Empty

        Dim faltantes As New List(Of String)()
        Dim puntos As Integer = 0

        If clave.Length >= LongitudMinimaClave Then
            puntos += 1
        Else
            faltantes.Add("al menos " & LongitudMinimaClave.ToString() & " caracteres")
        End If

        If clave.Any(Function(c) Char.IsUpper(c)) Then
            puntos += 1
        Else
            faltantes.Add("una mayuscula")
        End If

        If clave.Any(Function(c) Char.IsLower(c)) Then
            puntos += 1
        Else
            faltantes.Add("una minuscula")
        End If

        If clave.Any(Function(c) Char.IsDigit(c)) Then
            puntos += 1
        Else
            faltantes.Add("un numero")
        End If

        If clave.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then
            puntos += 1
        Else
            faltantes.Add("un simbolo")
        End If

        If faltantes.Count = 0 Then
            detalle = "Clave fuerte."
        Else
            detalle = "Le falta: " & String.Join(", ", faltantes) & "."
        End If

        Return puntos
    End Function

End Class
